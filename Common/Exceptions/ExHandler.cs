using System;
using System.IO;
using MySql.Data.MySqlClient;
using System.Text;

namespace Common.Exceptions
{

    /// <summary>
    /// Cette classe est utilisée pour relancer les exceptions qui sont gérées et écrire dans un fichier log les informations
    /// des exception qui ne le sont pas. Ainsi on peut faire remonter une exception en écrivant un log qu'une seule fois.
    /// </summary>
    public static class ExHandler
    {

        /// <summary>
        /// Permet d'identifier les exceptions gérées et d'écrire dans un log celles qui ne le sont pas.
        /// </summary>
        /// <param name="ex">
        /// L'exception à évaluer.
        /// </param>
        /// <param name="ex">
        /// Information supplémentaire pouvant être spécifiée (peut être laissé null).
        /// </param>
        public static void Parse(Exception ex, String info)
        {
            int? err_number = null;
            string info_string = null;
            if (ex is MySqlException)
            {
                MySqlException e = (MySqlException)ex;
                switch (e.Number)
                {
                    //case 0:
                    //    throw new ConnectionException();  //Authentication to host 'localhost' for user 'root' using method 'mysql_native_password' failed with message: Access denied for user 'root'@'localhost' (using password: YES).
                    //case 1041:
                    //    throw new ConnectionException();  // Unable to connect to any of the specified MySQL hosts.
                    //case 1045:
                    //    throw new CredentialException();
                    //case 1042:
                    //    throw new ConnectionException();  //Unable to connect to any of the specified MySQL hosts.
                    case 1406:
                        throw new ManagedException(ex.Message);     // Constraint exception
                    default:
                        err_number = e.Number;
                        if (info != null) info_string = info;
                        break;
                }
            }
            else if (ex is ManagedException)    // On fait remonter notre exception d'un niveau à l'autre.
            {
                throw ex;
            }
            else if (ex is UnmanagedException)  // On fait remonter notre exception d'un niveau à l'autre.
            {
                throw ex;
            }

            // L'écriture du log peut lui-même lancer une exception. Dans ce cas nous aurons une application qui plante
            // sans avoir un log pour consulter les détails de l'exception.
            // TODO : On pourrait avoir un mécanisme alternatif comme l'envoi d'un courriel à l'administrateur. C'est
            // pourquoi la méthode qui construit la chaîne du log a été isolé (envoyer un courriel en cas de problème).
            try
            {
                String log = BuildLog(ex, err_number, info_string);
                String path = GetLogFilePath(FolderPath);
                if (!Directory.Exists(FolderPath)) Directory.CreateDirectory(FolderPath);
                ExHandler.WriteLog(path, log);
            }
            finally
            {
                // C'est ici, une fois le log écrit, que l'on envoit un UnmanagedException pour indiquer aux autres Layer
                // que l'exception ne doit pas être écrit dans un fichier log encore. C'est une exception qui doit faire
                // planter notre application car l'état du système est maintenant inconnu.
                throw new UnmanagedException(ex.Message);
            }
        }

        private static String BuildLog(Exception ex, int? err_number, String info_string)
        {
            String type = String.Format("Exception...{0}   {1}{0}", Environment.NewLine, ex.GetType().ToString());
            String number = err_number != null ? String.Format("ErrNumber...{0}   {1}{0}", Environment.NewLine, err_number) : String.Empty;
            String sql = info_string != null ? String.Format("InfoString...{0}   {1}{0}", Environment.NewLine, info_string) : String.Empty;
            String message = String.Format("Message...{0}   {1}{0}", Environment.NewLine, ex.Message);
            String source = String.Format("Source...{0}   {1}{0}", Environment.NewLine, ex.Source);
            String target = String.Format("TargetSite...{0}   {1}{0}", Environment.NewLine, ex.TargetSite);
            String stack = String.Format("StackTrace...{0}{1}{0}", Environment.NewLine, ex.StackTrace);
            String log = type + number + sql + message + source + target + stack;
            return log;
        }

        private static String GetLogFilePath(String folder_path)
        {
            String stamp1 = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff");
            String stamp2 = Guid.NewGuid().ToString();
            String file_name = String.Format("{0}_{1}.log", stamp1, stamp2);
            String file_path = Path.Combine(folder_path, file_name);
            return file_path;
        }

        private static void WriteLog(String path, String log)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(log);
            }
        }

        private const string FolderPath = "C:\\MapExceptionLogs";

    }

}
