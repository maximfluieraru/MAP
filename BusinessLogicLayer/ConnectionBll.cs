using System;
using Common.DataTransferObject;
using Common.Exceptions;
using DataAccessLayer;

namespace BusinessLogicLayer
{

    /// <summary>
    /// Cette classe contient les méthodes utilisées pour la connexion de l'usager.
    /// </summary>
    public static class ConnectionBll
    {

        public static Employee LoadEmployee(String emp_login)
        {
            return EmployeeDal.Load(emp_login);
        }

        public static String GetRoleName(UInt32 rol_id)
        {
            return RoleDal.Load(rol_id).rol_name;
        }

        /// <summary>
        /// Vérifie la validité du mot de passe en le comparant avec celui de
        /// la base de données.
        /// </summary>
        /// <param name="input_pw">
        /// Le mot de passe à évaluer.
        /// </param>
        /// <param name="db_pw">
        /// Le mot de passe déjà encodé dans la base de données.
        /// </param>
        /// <returns>
        /// Retourne true si le mot de passe est bon ou false dans le cas contraire.
        /// </returns>
        public static Boolean ValidatePassword(String input_pw, String db_pw)
        {
            String enc_pw = UtilsBll.ComputeSha1(input_pw);
            return enc_pw.Equals(db_pw, StringComparison.OrdinalIgnoreCase);
        }

    }

}
