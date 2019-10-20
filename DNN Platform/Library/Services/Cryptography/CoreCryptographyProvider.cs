<<<<<<< HEAD
﻿// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
=======
﻿#region Copyright

// 
// DotNetNuke® - https://www.dnnsoftware.com
// Copyright (c) 2002-2018
// by DotNetNuke Corporation
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
>>>>>>> Merges latest changes from release/9.4.x into development (#3178)
// 
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DotNetNuke.Services.Cryptography
{
    internal class CoreCryptographyProvider : CryptographyProvider
    {
        /// <summary>
        ///     copy of legacy PortalSecurity.Encrypt method
        /// </summary>
        /// <param name="message">string to be encrypted</param>
        /// <param name="passphrase">key for encryption</param>
        /// <returns></returns>
        public override string EncryptParameter(string message, string passphrase)
        {
            string value;
            if (!String.IsNullOrEmpty(passphrase))
            {
                //convert key to 16 characters for simplicity
                if (passphrase.Length < 16)
                {
                    passphrase = passphrase + "XXXXXXXXXXXXXXXX".Substring(0, 16 - passphrase.Length);
                }
                else
                {
                    passphrase = passphrase.Substring(0, 16);
                }

                //create encryption keys
                byte[] byteKey = Encoding.UTF8.GetBytes(passphrase.Substring(0, 8));
                byte[] byteVector = Encoding.UTF8.GetBytes(passphrase.Substring(passphrase.Length - 8, 8));

                //convert data to byte array
                byte[] byteData = Encoding.UTF8.GetBytes(message);

                //encrypt 
                using (var objDes = new DESCryptoServiceProvider())
                using (var objMemoryStream = new MemoryStream())
                using (var objCryptoStream = new CryptoStream(objMemoryStream, objDes.CreateEncryptor(byteKey, byteVector),
                    CryptoStreamMode.Write))
                {
                    objCryptoStream.Write(byteData, 0, byteData.Length);
                    objCryptoStream.FlushFinalBlock();

                    //convert to string and Base64 encode
                    value = Convert.ToBase64String(objMemoryStream.ToArray());
                }
            }
            else
            {
                value = message;
            }
            return value;
        }

        /// <summary>
        ///     copy of legacy PortalSecurity.Decrypt method
        /// </summary>
        /// <param name="message">string to be decrypted</param>
        /// <param name="passphrase">key for decryption</param>
        /// <returns></returns>
        public override string DecryptParameter(string message, string passphrase)
        {
            string strValue = "";
            if (!string.IsNullOrEmpty(passphrase) && !string.IsNullOrEmpty(message))
            {
                try
                {
                    //convert key to 16 characters for simplicity
                    if (passphrase.Length < 16)
                    {
                        passphrase = passphrase + "XXXXXXXXXXXXXXXX".Substring(0, 16 - passphrase.Length);
                    }
                    else
                    {
                        passphrase = passphrase.Substring(0, 16);
                    }

                    //create encryption keys
                    byte[] byteKey = Encoding.UTF8.GetBytes(passphrase.Substring(0, 8));
                    byte[] byteVector = Encoding.UTF8.GetBytes(passphrase.Substring(passphrase.Length - 8, 8));
                    byte[] byteData = Convert.FromBase64String(message);

                    //decrypt
                    using (var objDes = new DESCryptoServiceProvider())
                    using (var objMemoryStream = new MemoryStream())
                    using (var objCryptoStream = new CryptoStream(objMemoryStream,
                        objDes.CreateDecryptor(byteKey, byteVector), CryptoStreamMode.Write))
                    {
                        objCryptoStream.Write(byteData, 0, byteData.Length);
                        objCryptoStream.FlushFinalBlock();

                        //convert to string
                        Encoding objEncoding = Encoding.UTF8;
                        strValue = objEncoding.GetString(objMemoryStream.ToArray());
                    }
                }
                catch //decryption error
                {
                    strValue = "";
                }
            }
            return strValue;
        }

        /// <summary>
        ///     copy of legacy PortalSecurity.EncryptString method
        /// </summary>
        /// <param name="message">string to be encrypted</param>
        /// <param name="passphrase">key for encryption</param>
        /// <returns></returns>
        public override string EncryptString(string message, string passphrase)
        {
            byte[] results;
            var utf8 = new UTF8Encoding();

            //hash the passphrase using MD5 to create 128bit byte array
            using (var hashProvider = new MD5CryptoServiceProvider())
            {
                byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(passphrase));

                var tdesAlgorithm = new TripleDESCryptoServiceProvider
                {
                    Key = tdesKey,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                byte[] dataToEncrypt = utf8.GetBytes(message);

                try
                {
                    ICryptoTransform encryptor = tdesAlgorithm.CreateEncryptor();
                    results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information 
                    tdesAlgorithm.Clear();
                    hashProvider.Clear();
                }
            }

            //Return the encrypted string as a base64 encoded string 
            return Convert.ToBase64String(results);
        }

        /// <summary>
        ///     copy of legacy PortalSecurity.DecryptString method
        /// </summary>
        /// <param name="message">string to be decrypted</param>
        /// <param name="passphrase">key for decryption</param>
        /// <returns></returns>
        public override string DecryptString(string message, string passphrase)
        {
            byte[] results;
            var utf8 = new UTF8Encoding();

            //hash the passphrase using MD5 to create 128bit byte array
            using (var hashProvider = new MD5CryptoServiceProvider())
            {
                byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(passphrase));

                var tdesAlgorithm = new TripleDESCryptoServiceProvider
                {
                    Key = tdesKey,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };


                byte[] dataToDecrypt = Convert.FromBase64String(message);
                try
                {
                    ICryptoTransform decryptor = tdesAlgorithm.CreateDecryptor();
                    results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
                }
                finally
                {
                    // Clear the TripleDes and Hashprovider services of any sensitive information 
                    tdesAlgorithm.Clear();
                    hashProvider.Clear();
                }
            }

            return utf8.GetString(results);
        }
    }
}
