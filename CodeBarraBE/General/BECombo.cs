using System;
namespace CodeBarraBE
{
     public class BECombo
    {
        private string _Codigo;
        private string _Descripcion;


        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

    }
}
