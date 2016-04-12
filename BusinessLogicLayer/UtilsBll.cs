using System;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogicLayer
{
    internal static class UtilsBll
    {

        /// <summary>
        /// Calcule la valeur de hachage SHA-1 pour une chaîne de caractères.
        /// Le SHA1-1 retourne une chaîne de 40 caractères.
        /// </summary>
        /// <param name="str">
        /// La chaîne de caractères à évaluer.
        /// </param>
        /// <returns>
        /// La valeur de hachage SHA-1.
        /// </returns>
        public static String ComputeSha1(String str)
        {
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                Byte[] bytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(str));
                String hash = String.Empty;
                foreach (Byte b in bytes)
                {
                    hash += b.ToString("x2");
                }
                return hash;
            }
        }

    }
}
