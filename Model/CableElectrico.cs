using System;
using System.Globalization;

namespace Model
{
    public class CableElectrico
    {
        private int numeroDeSerie;
        private int cantidadDeConductores;
        private String marcaDelCable;
        private float metros;
        private char seccionDelCable;
        private bool libreDeHalogenos;
        private bool fachadaOVivienda;
        private DateTime fechaDeCompra;
        private DateTime fechaDeVencimiento;

        /**
         * Cantidad de Bytes por atributo
         * Numero Serie[4]
         * Cantidad conductores[4]
         * Marca[10]
         * Metros de cable[4]
         * Seccion del cable[1]
         * Libre de halogenos[5]
         * Fachada o Vivienda[5]
         * Fecha de compra[8]
         * Fecha de vencimiento[8]
         */
        public CableElectrico(int numeroDeSerie, int cantidadDeConductores,
            string marcaDelCable, float metros, char seccionDelCable,
            bool libreDeHalogenos, bool fachadaOVivienda, DateTime fechaDeComprea,
            DateTime fechaDeVencimiento)
        {
            this.numeroDeSerie = numeroDeSerie;
            this.cantidadDeConductores = cantidadDeConductores;
            this.marcaDelCable = marcaDelCable;
            this.metros = metros;
            this.seccionDelCable = seccionDelCable;
            this.libreDeHalogenos = libreDeHalogenos;
            this.fachadaOVivienda = fachadaOVivienda;
            this.fechaDeCompra = fechaDeComprea;
            this.fechaDeVencimiento = fechaDeVencimiento;
        }
        public CableElectrico(int cantidadDeConductores,
            string marcaDelCable, float metros, char seccionDelCable,
            bool libreDeHalogenos, bool fachadaOVivienda, DateTime fechaDeComprea,
            DateTime fechaDeVencimiento)
        {
            this.cantidadDeConductores = cantidadDeConductores;
            this.marcaDelCable = marcaDelCable;
            this.metros = metros;
            this.seccionDelCable = seccionDelCable;
            this.libreDeHalogenos = libreDeHalogenos;
            this.fachadaOVivienda = fachadaOVivienda;
            this.fechaDeCompra = fechaDeComprea;
            this.fechaDeVencimiento = fechaDeVencimiento;
        }
        public CableElectrico()
        {
            this.numeroDeSerie = 0;
            this.cantidadDeConductores = 0;
            this.marcaDelCable = "";
            this.metros = 0.0f;
            this.seccionDelCable = '-';
            this.libreDeHalogenos = false;
            this.fachadaOVivienda = false;
            this.fechaDeCompra = DateTime.Parse("01/01/1000");
            this.fechaDeVencimiento = DateTime.Parse("01/01/1000");
        }

        public int NumeroDeSerie { get => numeroDeSerie; set { numeroDeSerie = value; } }
        public int CantidadDeConductores { get => cantidadDeConductores; set { cantidadDeConductores = value; } }
        public string MarcaDelCable { get => marcaDelCable; set { marcaDelCable = value; } }
        public float Metros { get => metros; set { metros = value; } }
        public char SeccionDelCable { get => seccionDelCable; set => seccionDelCable = value; }

        public string SeccionDelCableAxu { get => seccionDelCable.ToString(); set => seccionDelCable =  string.IsNullOrEmpty(value)? '\0' : value[0]; }

        public bool LibreDeHalogenos { get => libreDeHalogenos; set => libreDeHalogenos = value; }
        public bool FachadaOVivienda { get => fachadaOVivienda; set => fachadaOVivienda = value; }
        public DateTime FechaDeCompra { get => fechaDeCompra; set => fechaDeCompra = value; }
        public DateTime FechaDeVencimiento { get => fechaDeVencimiento; set => fechaDeVencimiento = value; }


        public override string ToString()
        {
            string libre = "";
            if (this.libreDeHalogenos == true)
            {
                libre = "Si";
            }
            else
            {
                libre = "No";
            }
            string fachadaVivienda = "";
            if (this.fachadaOVivienda == true)
            {
                fachadaVivienda = "Si";
            }
            else
            {
                fachadaVivienda = "No";
            }

            return $"{numeroDeSerie}  |  {cantidadDeConductores}  |  {marcaDelCable}  |  {metros.ToString(CultureInfo.InvariantCulture)}  |  {seccionDelCable}  |  {libre}  |  {fachadaVivienda}  |  {fechaDeCompra:dd-MM-yyyy}  |  {fechaDeVencimiento:dd-MM-yyyy}";
        }

    }
}
