using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;

namespace Unicamente.Domain.Uteis
{
    public static class CriptografarHash
    {
        //public enum TipoCriptografia
        //{
        //    MD5,
        //    SHA1,
        //    SHA256,
        //    SHA512
        //}

        public static string GerarHashCriptografado(string senha)
        {
            byte[] salt = new byte[(128 / 8)];
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2
                (
                    password: senha!,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8)
                );
            return hashed;
        }


        //public static string GerarHash64(string chave)
        //{
        //    var md5 = RetornarHash(string.Concat(chave, DateTime.Now.ToString()), CriptografarHash.TipoCriptografia.MD5);

        //    var TextoBytes = System.Text.Encoding.UTF8.GetBytes(md5);
        //    var base64 = Convert.ToBase64String(TextoBytes);
        //    return base64;
        //}


        ///// <summary>
        ///// Retornar string criptografada, escolhendo o tipo de criptografia.
        ///// </summary>
        //public static string RetornarHash(string texto, TipoCriptografia tipo)
        //{
        //    string retorno = string.Empty;

        //    switch (tipo)
        //    {
        //        case TipoCriptografia.MD5:
        //            retorno = RetornarMD5(texto);
        //            break;
        //        case TipoCriptografia.SHA1:
        //            retorno = RetornarSHA1(texto);
        //            break;
        //        case TipoCriptografia.SHA256:
        //            retorno = RetornarSHA256(texto);
        //            break;
        //        case TipoCriptografia.SHA512:
        //            retorno = RetornarSHA512(texto);
        //            break;
        //    }
        //    return retorno;
        //}

        //#region Criptografar texto

        //private static string RetornarMD5(string texto)
        //{
        //    byte[] hashValor;
        //    byte[] message;
        //    string msg = string.Empty;

        //    message = Encoding.GetEncoding("ISO8859-1").GetBytes(texto);
        //    MD5 hashString = MD5.Create();
        //    hashValor = hashString.ComputeHash(message);

        //    foreach (byte x in hashValor)
        //    {
        //        msg += String.Format("{0:x2}", x);
        //    }
        //    return msg;
        //}

        //private static string RetornarSHA1(string texto)
        //{
        //    byte[] hashValor;
        //    byte[] message;
        //    string msg = string.Empty;

        //    message = Encoding.ASCII.GetBytes(texto);
        //    SHA1 hashString = SHA1.Create();
        //    hashValor = hashString.ComputeHash(message);

        //    foreach (byte x in hashValor)
        //    {
        //        msg += String.Format("{0:x2}", x);
        //    }
        //    return msg;
        //}

        //private static string RetornarSHA256(string texto)
        //{
        //    byte[] hashValor;
        //    byte[] message;
        //    string msg = string.Empty;

        //    message = Encoding.ASCII.GetBytes(texto);
        //    SHA256 hashString = SHA256.Create();
        //    hashValor = hashString.ComputeHash(message);

        //    foreach (byte x in hashValor)
        //    {
        //        msg += String.Format("{0:x2}", x);
        //    }
        //    return msg;
        //}

        //private static string RetornarSHA512(string texto)
        //{
        //    byte[] hashValor;
        //    byte[] message;
        //    string msg = string.Empty;

        //    message = Encoding.ASCII.GetBytes(texto);
        //    SHA512 hashString = SHA512.Create();
        //    hashValor = hashString.ComputeHash(message);

        //    foreach (byte x in hashValor)
        //    {
        //        msg += String.Format("{0:x2}", x);
        //    }
        //    return msg;
        //}

    }
}
