using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CodeBarraBL.Securidad
{
    public class Hashing
    {
        #region Enum y Variables Globales

        public enum TipoHash
        {
            SHA,
            SHA256,
            SHA384,
            SHA512,
            MD5
        }

        #endregion

        #region Encriptación

        public string Encriptar(string _strCadena)
        {
            return CalcularHash(_strCadena, TipoHash.MD5);
        }

        public string Encriptar(string _strCadena, TipoHash Tipo)
        {
            return CalcularHash(_strCadena, Tipo);
        }

        public bool IgualHash(string _strCadena, string _strHash)
        {
            return (this.Encriptar(_strCadena) == _strHash);
        }

        public bool IgualHash(string _strCadena, string _strHash, TipoHash Tipo)
        {
            return (this.Encriptar(_strCadena, Tipo) == _strHash);
        }
        #endregion

        #region Calcular Hashing

        private string CalcularHash(string _strCadena, TipoHash Tipo)
        {
            HashAlgorithm HA = GetHashAlgoritmo(Tipo);
            byte[] intputByte = System.Text.Encoding.UTF8.GetBytes(_strCadena);

            byte[] Baffer = HA.ComputeHash(intputByte);

            return Convert.ToBase64String(Baffer);
        }

        private HashAlgorithm GetHashAlgoritmo(TipoHash Tipo)
        {
            switch (Tipo)
            {
                case TipoHash.MD5:
                    return new MD5CryptoServiceProvider();
                case TipoHash.SHA:
                    return new SHA1CryptoServiceProvider();
                case TipoHash.SHA256:
                    return new SHA256Managed();
                case TipoHash.SHA384:
                    return new SHA384Managed();
                case TipoHash.SHA512:
                    return new SHA512Managed();
                default:
                    return new MD5CryptoServiceProvider();
            }
        }
        #endregion
    }
}
