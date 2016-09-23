using System;
namespace CodeBarraBE
{
    public class BEUsuario
    {
        #region Variables
        private Int32 _usucodigo;
        private Int32 _clicodigo;
        private Int32 _percodigo;
        private Int32 _pflcodigo;
        private string _usulogin;
        private string _usuclave;
        private string _usuestado;
        private string _ususuccodigo;
        private string _usupercargo;
        private string _ususucnombre;
        private string _cliruc;
        private string _clinombre;
        private Nullable<DateTime> _usultimoacceso;
        private Nullable<DateTime> _usucaduca;
        private Nullable<Int32> _usucontador;
        private Nullable<Int32> _tiempocaduca;
        private string _audPro;
        private string _usuario;
        private string _terminal;
        private Nullable<Int32> _usuprimerlogeo;

        #endregion

        #region Propiedades
        public Int32 UsuCodigo
        {
            get { return _usucodigo; }
            set { _usucodigo = value; }
        }
        public Int32 PerCodigo
        {
            get { return _percodigo; }
            set { _percodigo = value; }
        }
        public Int32 CliCodigo
        {
            get { return _clicodigo; }
            set { _clicodigo = value; }
        }
        public Int32 PflCodigo
        {
            get { return _pflcodigo; }
            set { _pflcodigo = value; }
        }
        public string UsuLogin
        {
            get { return _usulogin; }
            set { _usulogin = value; }
        }
        public string UsuClave
        {
            get { return _usuclave; }
            set { _usuclave = value; }
        }


        public string CliRuc
        {
            get { return _cliruc; }
            set { _cliruc = value; }
        }

        public string CliNombre
        {
            get { return _clinombre; }
            set { _clinombre = value; }
        }

        public string UsuEstado
        {
            get { return _usuestado; }
            set { _usuestado = value; }
        }
        public Nullable<DateTime> UsUltimoAcceso
        {
            get { return _usultimoacceso; }
            set { _usultimoacceso = value; }
        }
        public Nullable<DateTime> UsuCaduca
        {
            get { return _usucaduca; }
            set { _usucaduca = value; }
        }
        public Nullable<Int32> TiempoCaduca
        {
            get { return _tiempocaduca; }
            set { _tiempocaduca = value; }
        }
        public Nullable<Int32> UsuContador
        {
            get { return _usucontador; }
            set { _usucontador = value; }
        }

        public string Programa
        {
            get { return _audPro; }
            set { _audPro = value; }
        }

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public string Terminal
        {
            get { return _terminal; }
            set { _terminal = value; }
        }
        public Nullable<Int32> Primerlogeo
        {
            get { return _usuprimerlogeo; }
            set { _usuprimerlogeo = value; }
        }


        public string UsuSucNombre
        {
            get { return _ususucnombre; }
            set { _ususucnombre = value; }
        }

        public string UsuSucCodigo
        {
            get { return _ususuccodigo; }
            set { _ususuccodigo = value; }
        }

        public string UsuPerCargo
        {
            get { return _usupercargo; }
            set { _usupercargo = value; }
        }
        #endregion
    }
}
