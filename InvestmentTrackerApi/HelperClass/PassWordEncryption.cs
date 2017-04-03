/*
 * this class is used to get encrypt password to MD5 format
 * */
using System.Text;
using System.Security.Cryptography;

namespace InvestmentTrackerApi.HelperClass
{
    public static class PassWordEncryption
    {
        /// <summary>
        /// password encyption to MD5
        /// </summary>
        /// <param name="password"></param>
        public static string EncryptPassword( string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return GetMD5Hash(md5Hash, password);
            }
        }

        private static string GetMD5Hash(MD5 mdHash,string originalstring)
        {
            byte[] data = mdHash.ComputeHash(Encoding.UTF8.GetBytes(originalstring));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();

        }
    }
}