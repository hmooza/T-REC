using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for SHA256
/// </summary>
public class SHA256
{
    public SHA256()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string EcryptPassword(string pwd, string salt)
    {
        //Encode by UTF8
        UTF8Encoding pt = new UTF8Encoding();
        byte[] ptByte = pt.GetBytes(pwd);
        UTF8Encoding s = new UTF8Encoding();
        byte[] sByte = s.GetBytes(salt);

        //'Mix plaintext + salt
        //Reserver array to mix plain and salt
        int numbytes = ptByte.Length + sByte.Length - 1;
        byte[] ptSBytes = new byte[numbytes]; // { (byte)numbytes };

        for (int num = 0; num < ptByte.Length; num++)
        {
            ptSBytes[num] = ptByte[num];
        }

        //'Copy salt bytes to array.
        for (int num = 0; num < sByte.Length - 1; num++)
        {
            ptSBytes[ptByte.Length + num] = sByte[num];
        }

        HashAlgorithm hash;
        hash = new SHA256Managed();

        // Compute hash
        byte[] hashBytes = hash.ComputeHash(ptSBytes);

        // Convert into a base64-encoded string.
        string hashValue;
        hashValue = Convert.ToBase64String(hashBytes);

        return hashValue;
    }
}