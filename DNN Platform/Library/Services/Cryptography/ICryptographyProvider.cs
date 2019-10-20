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
namespace DotNetNuke.Services.Cryptography
{
    public interface ICryptographyProvider
    {
        /// <summary>
        ///     simple method that uses basic encryption to safely encode parameters
        /// </summary>
        /// <param name="message">the text to be encrypted (encoded)</param>
        /// <param name="passphrase">the key to perform the encryption</param>
        /// <returns>encrypted string</returns>
        string EncryptParameter(string message, string passphrase);

        /// <summary>
        ///     simple method that uses basic encryption to safely decode parameters
        /// </summary>
        /// <param name="message">the text to be decrypted (decoded)</param>
        /// <param name="passphrase">the key to perform the decryption</param>
        /// <returns>decrypted string</returns>
        string DecryptParameter(string message, string passphrase);

        /// <summary>
        ///     safely encrypt sensitive data
        /// </summary>
        /// <param name="message">the text to be encrypted</param>
        /// <param name="passphrase">the key to perform the encryption</param>
        /// <returns>encrypted string</returns>
        string EncryptString(string message, string passphrase);

        /// <summary>
        ///     safely decrypt sensitive data
        /// </summary>
        /// <param name="message">the text to be decrypted</param>
        /// <param name="passphrase">the key to perform the decryption</param>
        /// <returns>decrypted string</returns>
        string DecryptString(string message, string passphrase);
    }
}
