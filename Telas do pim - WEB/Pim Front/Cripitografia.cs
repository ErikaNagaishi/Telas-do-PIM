using System.Security.Cryptography;
using System.Text;
using System;

public static class Criptografia
{
    public static string Encrypt(string value)
    {
        //Using MD5 to encrypt a string
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            //Hash data
            byte[] data = md5.ComputeHash(utf8.GetBytes(value));
            return Convert.ToBase64String(data);
        }
    }
}