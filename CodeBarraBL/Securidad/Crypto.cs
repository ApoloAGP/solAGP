using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CodeBarraBL.Securidad
{
    public class Crypto
    {
        #region "Enum, y Variables Constantes"

        public enum TipoEncriptacion
        {
            TipoDes = 0,
            TipoRec,
            TipoTripleDes,
            TipoRijndael
        }

        private const string CRYPT_DEFAULT_PASSWORD = "Mst_mula#@23";
        private const TipoEncriptacion CRYPT_DEFAULT_METOD = TipoEncriptacion.TipoRijndael;
        private byte[] _mKey = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        private byte[] _mVI = { 25, 65, 68, 110, 69, 200, 178, 219 };
        private byte[] SalByteArray = { 0x49, 0x76, 0x61, 0x6, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
        private TipoEncriptacion _mEncriptacion = CRYPT_DEFAULT_METOD;
        private string _mPassword = CRYPT_DEFAULT_PASSWORD;

        #endregion

        #region "Constructor"

        public Crypto()
        {
            //
            // TODO: Add constructor logic here
            //
            CalculaNuevoKeyAndVI();
        }

        public Crypto(TipoEncriptacion Tipo)
        {
            this.TipodeEncriptacion = Tipo;
        }

        #endregion

        #region "Propiedades"

        public TipoEncriptacion TipodeEncriptacion
        {
            get { return _mEncriptacion; }
            set
            {
                _mEncriptacion = value;
                CalculaNuevoKeyAndVI();
            }
        }

        public string Password
        {
            get { return _mPassword; }
            set
            {
                _mPassword = value;
                CalculaNuevoKeyAndVI();
            }
        }

        #endregion

        #region "Encriptación"

        public string Encriptar(string _strCadena)
        {
            System.Text.UTF8Encoding Encode = new System.Text.UTF8Encoding();

            byte[] intputByte = System.Text.Encoding.UTF8.GetBytes(_strCadena);

            return Convert.ToBase64String(EncriptarDecencriptar(intputByte, true));
        }

        public string Encriptar(string _strCadena, string _strPassword)
        {
            this.Password = _strPassword;
            return this.Encriptar(_strCadena);
        }

        public string Encriptar(string _strCadena, string _strPassword, TipoEncriptacion Tipo)
        {
            this.TipodeEncriptacion = Tipo;
            return this.Encriptar(_strCadena, _strPassword);
        }

        public string Encriptar(string _strCadena, TipoEncriptacion Tipo)
        {
            this.TipodeEncriptacion = Tipo;
            return this.Encriptar(_strCadena);
        }

        #endregion

        #region "Decencriptar"

        public string Decencriptar(string _strCadena)
        {
            byte[] intputByte = Convert.FromBase64String(_strCadena);

            return System.Text.Encoding.UTF8.GetString(EncriptarDecencriptar(intputByte, false));
        }

        public string Decencriptar(string _strCadena, string _strPassword)
        {
            this.Password = _strPassword;
            return this.Decencriptar(_strCadena);
        }

        public string Decencriptar(string _strCadena, string _strPassword, TipoEncriptacion Tipo)
        {
            this.TipodeEncriptacion = Tipo;
            return this.Decencriptar(_strCadena, _strPassword);
        }

        public string Decencriptar(string _strCadena, TipoEncriptacion Tipo)
        {
            this.TipodeEncriptacion = Tipo;
            return this.Decencriptar(_strCadena);
        }
        #endregion

        #region "Proceso de Encriptación"

        private byte[] EncriptarDecencriptar(byte[] intputByte, bool Estado)
        {
            ICryptoTransform Transform = GetEncriptarTransform(Estado);

            System.IO.MemoryStream _mStream = new System.IO.MemoryStream();

            try
            {
                CryptoStream Cryto = new CryptoStream(_mStream, Transform, CryptoStreamMode.Write);
                Cryto.Write(intputByte, 0, intputByte.Length);
                Cryto.FlushFinalBlock();
                byte[] Bafer = _mStream.ToArray();
                Cryto.Close();
                return Bafer;
            }
            catch (Exception Ex)
            {
                throw new Exception("Error en Encriptación, Error: " + Ex.Message, Ex);
            }

        }

        private ICryptoTransform GetEncriptarTransform(bool Estado)
        {
            SymmetricAlgorithm Sa = SeleccionarAlgoritmo();
            Sa.Key = _mKey;
            Sa.IV = _mVI;
            if (Estado)
            {
                return Sa.CreateEncryptor();
            }
            else
            {
                return Sa.CreateDecryptor();
            }
        }

        private SymmetricAlgorithm SeleccionarAlgoritmo()
        {
            SymmetricAlgorithm Sa;
            switch (_mEncriptacion)
            {
                case TipoEncriptacion.TipoDes:
                    Sa = DES.Create();
                    break;
                case TipoEncriptacion.TipoRec:
                    Sa = RC2.Create();
                    break;
                case TipoEncriptacion.TipoRijndael:
                    Sa = Rijndael.Create();
                    break;
                case TipoEncriptacion.TipoTripleDes:
                    Sa = TripleDES.Create();
                    break;
                default:
                    Sa = TripleDES.Create();
                    break;
            }
            return Sa;
        }

        private void CalculaNuevoKeyAndVI()
        {
            PasswordDeriveBytes _Pas = new PasswordDeriveBytes(_mPassword, SalByteArray);
            SymmetricAlgorithm Algorit = SeleccionarAlgoritmo();
            _mKey = _Pas.GetBytes(Algorit.BlockSize / 8);
            _mVI = _Pas.GetBytes(Algorit.BlockSize / 8);
        }
        #endregion
    }
}
