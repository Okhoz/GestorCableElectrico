using Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Data
{
    public class DCableElectricoFicheros : ICableElectricoFichero
    {
        string nombreFichero = "..\\..\\..\\AlamacenDeCable";
        private FileStream fichero;
        private StreamReader sr;
        private StreamWriter sw;
        public DCableElectricoFicheros()
        {
            this.CrearFichero();
        }

        private bool CrearFichero()
        {
            string elementos = "Numero Serie | Cantidad conductores | Marca | Metros de cable | Seccion del cable | Libre de halogenos | Fachada o Vivienda | Fecha de compra | Fecha de vencimiento\n";
            if (File.Exists(nombreFichero) == false)
            {
                this.fichero = new FileStream(nombreFichero, FileMode.OpenOrCreate, FileAccess.Write);
                this.sw = new StreamWriter(fichero);
                this.sw.Write(elementos);
                sw.Close();
                this.fichero.Close();
                return true;
            }

            return false;
        }

        public bool BorrarCable(int numeroDeSerie)
        {
            string elementos = "Numero Serie | Cantidad conductores | Marca | Metros de cable | Seccion del cable | Libre de halogenos | Fachada o Vivienda | Fecha de compra | Fecha de vencimiento\n";
            List<CableElectrico> listaDeCable = this.RecuperarFichero();
            bool borrar = false;


            if (File.Exists(nombreFichero) == true && listaDeCable.Exists(cable => cable.NumeroDeSerie == numeroDeSerie))
            {
                FileStream fichero = new FileStream(nombreFichero, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fichero);

                sw.WriteLine(elementos); // cabecera sin espacios

                foreach (CableElectrico cable in listaDeCable)
                {
                    if (cable.NumeroDeSerie != numeroDeSerie)
                    {
                        sw.WriteLine(cable.ToString());
                    }
                    else
                    {
                        borrar = true;
                    }
                }
                sw.Close();
                fichero.Close();

            }

            return borrar;
        }

        public bool AñadirCable(CableElectrico cableElectrico)
        {
            if (File.Exists(nombreFichero) == true)
            {
                List<CableElectrico> cables = this.RecuperarFichero();

                fichero = new FileStream(nombreFichero, FileMode.Append, FileAccess.Write);
                this.sw = new StreamWriter(fichero);
                foreach (CableElectrico cable in cables)
                {
                    if (cable.NumeroDeSerie == cableElectrico.NumeroDeSerie)
                    {
                        sw.Close();
                        fichero.Close();
                        return false;
                    }
                }
                sw.WriteLine(cableElectrico.ToString());
                sw.Close();
                fichero.Close();
                return true;
            }
            return false;
        }

        private List<CableElectrico> RecuperarFichero()
        {
            List<CableElectrico> listaDeCable = new List<CableElectrico>();
            CableElectrico cableElectrico;
            List<string> lines = new List<string>();

            string[] caracter;

            int numeroDeSerie;
            int cantidadDeConductores;
            String marcaDelCable;
            float metros;
            char seccionDelCable;
            bool libreDeHalogenos;
            bool fachadaOVivienda;
            DateTime fechaDeCompra;
            DateTime fechaDeVencimiento;

            int cont = 0;

            if (File.Exists(nombreFichero) == true)
            {
                this.fichero = new FileStream((string)nombreFichero, FileMode.Open, FileAccess.Read);
                this.sr = new StreamReader(fichero);

                string texto = sr.ReadLine();

                while (texto != null)
                {
                    lines.Add(texto);
                    texto = sr.ReadLine();
                }

                foreach (string s in lines)
                {
                    if (cont >= 1 && s != string.Empty && s != null)
                    {
                        caracter = s.Split('|');
                        numeroDeSerie = int.Parse(caracter[0]);
                        cantidadDeConductores = int.Parse(caracter[1]);
                        marcaDelCable = caracter[2];
                        metros = float.Parse(caracter[3]);
                        seccionDelCable = char.Parse(caracter[4]);
                        libreDeHalogenos = bool.Parse(caracter[5]);
                        fachadaOVivienda = bool.Parse(caracter[6]);
                        fechaDeCompra = DateTime.Parse(caracter[7]);
                        fechaDeVencimiento = DateTime.Parse(caracter[8]);

                        cableElectrico = new CableElectrico(numeroDeSerie, cantidadDeConductores, marcaDelCable,
                                                           metros, seccionDelCable, libreDeHalogenos,
                                                           fachadaOVivienda, fechaDeCompra, fechaDeVencimiento
                                                           );
                        listaDeCable.Add(cableElectrico);
                    }
                    cont++;
                }
            }

            sr.Close();
            this.fichero.Close();
            return listaDeCable;
        }


        public List<CableElectrico> MostrarTodoElCable()
        {
            List<CableElectrico> listaDeCable = this.RecuperarFichero();

            return listaDeCable;
        }

        public CableElectrico MostrarPorNumeroDeSerie(int numeroDeSerie)
        {

            if (File.Exists(nombreFichero))
            {
                CableElectrico cableElectrico = new CableElectrico();
                List<CableElectrico> listaDecable = this.RecuperarFichero();

                return cableElectrico = listaDecable.Find(cable => cable.NumeroDeSerie == numeroDeSerie);
            }
            return null;

        }

        public List<CableElectrico> MostrarPorCantidadDeMetros(int metros)
        {
            List<CableElectrico> cableElectrico = this.RecuperarFichero();
            List<CableElectrico> nuevaLista = new List<CableElectrico>();

            if (File.Exists(nombreFichero))
            {
                foreach (CableElectrico cable in cableElectrico)
                {
                    if (cable.Metros >= metros)
                    {
                        nuevaLista.Add(cable);
                    }
                }
            }
            return nuevaLista;

        }

        public bool ModificarCable(CableElectrico cable)
        {
            List<CableElectrico> listaDeCable = this.RecuperarFichero();
            this.BorrarCable(cable.NumeroDeSerie);
            bool añadido = false;
            int cont = 0;
            foreach (CableElectrico cablecito in listaDeCable)
            {
                if (cablecito.NumeroDeSerie == cable.NumeroDeSerie)
                {
                    listaDeCable[cont] = cable;
                    añadido = true;
                }
                this.AñadirCable(cablecito);
                cont++;
            }
            return añadido;
        }

        public List<CableElectrico> MostrarCablePorFechaDeCompraAscendente(DateTime fecha)
        {
            List<CableElectrico> listaCableElectricos = this.RecuperarFichero();
            List<CableElectrico> listaFiltrada = new List<CableElectrico>();

            foreach (CableElectrico cable in listaCableElectricos)
            {
                if (cable.FechaDeCompra >= fecha)
                {
                    listaFiltrada.Add(cable);
                }
            }
            return listaFiltrada;

        }
    }
}
