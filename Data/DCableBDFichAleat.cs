using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Data
{
    public class DCableBDFichAleat : ICableElectricoFichero
    {
        private string nombreFichero = "..\\..\\..\\AlamacenAleat";
        private FileStream fichero;
        private int delay = 3000;


        public DCableBDFichAleat()
        {
            this.CrearFichero();
        }

        private bool CrearFichero()
        {

            if (File.Exists(nombreFichero) == false)
            {
                string elementos = "" +
                "Numero Serie[5]" +
                "Cantidad conductores[4]" +
                "Marca[10]" +
                "Metros de cable[4]" +
                "Seccion del cable[1]" +
                "Libre de halogenos[5]" +
                "Fachada o Vivienda[5]" +
                "Fecha de compra[8]" +
                "Fecha de vencimiento[8]\n";
                byte[] titulo = Encoding.ASCII.GetBytes(elementos);
                this.fichero = new FileStream(nombreFichero, FileMode.OpenOrCreate, FileAccess.Write);
                this.fichero.Seek(0, SeekOrigin.Begin);
                this.fichero.Write(titulo, 0, titulo.Length);
                this.fichero.Close();
                Thread.Sleep(delay);
                return true;
            }
            Thread.Sleep(delay);
            return false;
        }
        public bool AñadirCable(CableElectrico cableElectrico)
        {
            List<CableElectrico> listaRecuperada = this.RecuperarCable();

            if (File.Exists(nombreFichero) == true)
            {
                bool comprobarSiEsta = false;
                foreach (CableElectrico cableRecuperado in listaRecuperada)
                {
                    if (cableRecuperado.NumeroDeSerie == cableElectrico.NumeroDeSerie)
                    {
                        comprobarSiEsta = true;
                    }
                }
                if (comprobarSiEsta == false)
                {
                    this.fichero = new FileStream(nombreFichero, FileMode.Append, FileAccess.Write);
                    this.fichero.Seek(0, SeekOrigin.End);
                    String numeroDeSerie = ("1" + cableElectrico.NumeroDeSerie.ToString()).PadRight(6, ' ');
                    String cantidadDeConductores = cableElectrico.CantidadDeConductores.ToString().PadRight(4, ' ');
                    String marcaDelCable = cableElectrico.MarcaDelCable.PadRight(10, ' ');
                    String metros = cableElectrico.Metros.ToString().PadRight(4, ' ');
                    String seccionDelCable = cableElectrico.SeccionDelCable.ToString();
                    String libreDeHalogenos = cableElectrico.LibreDeHalogenos.ToString().PadRight(5, ' ');
                    String fachadaOVivienda = cableElectrico.FachadaOVivienda.ToString().PadRight(5, ' ');
                    String fechaDeCompra = cableElectrico.FechaDeCompra.ToString("dd/MM/yyyy");
                    String fechaDeVencimiento = cableElectrico.FechaDeVencimiento.ToString("dd/MM/yyyy");

                    String cable = numeroDeSerie + cantidadDeConductores + marcaDelCable + metros + seccionDelCable +
                                libreDeHalogenos + fachadaOVivienda + fechaDeCompra + fechaDeVencimiento;
                    Byte[] bytesCable = Encoding.ASCII.GetBytes(cable);
                    this.fichero.Write(bytesCable, 0, bytesCable.Length);
                    this.fichero.Close();
                    Thread.Sleep(delay);
                    return true;
                }
            }
            Thread.Sleep(delay);
            return false;
        }

        private List<CableElectrico> RecuperarCable()
        {
            CableElectrico cable = new CableElectrico();
            List<CableElectrico> listaDeCableElectricos = new List<CableElectrico>();
            if (File.Exists(nombreFichero))
            {
                int numeroDeSerie;
                int cantidadDeConductores;
                String marcaDelCable;
                float metros;
                char seccionDelCable;
                bool libreDeHalogenos;
                bool fachadaOVivienda;
                DateTime fechaDeCompra;
                DateTime fechaDeVencimiento;

                string cableDeVuelto = "";
                byte[] cableRecuperado = new byte[55];
                this.fichero = new FileStream(nombreFichero, FileMode.Open, FileAccess.Read);
                this.fichero.Seek(169, SeekOrigin.Begin);
                while (this.fichero.Read(cableRecuperado, 0, cableRecuperado.Length) > 0)
                {
                    cableDeVuelto = Encoding.ASCII.GetString(cableRecuperado);
                    numeroDeSerie = int.Parse(cableDeVuelto.Substring(1, 5).Trim());
                    cantidadDeConductores = int.Parse(cableDeVuelto.Substring(6, 4).Trim());
                    marcaDelCable = cableDeVuelto.Substring(10, 10).Trim();
                    metros = float.Parse(cableDeVuelto.Substring(20, 4).Trim());
                    seccionDelCable = char.Parse(cableDeVuelto.Substring(24, 1));
                    libreDeHalogenos = bool.Parse(cableDeVuelto.Substring(25, 5).Trim());
                    fachadaOVivienda = bool.Parse(cableDeVuelto.Substring(30, 5).Trim());
                    fechaDeCompra = DateTime.Parse(cableDeVuelto.Substring(35, 10));
                    fechaDeVencimiento = DateTime.Parse(cableDeVuelto.Substring(45, 10));

                    cable = new CableElectrico(numeroDeSerie, cantidadDeConductores, marcaDelCable,
                                                metros, seccionDelCable, libreDeHalogenos,
                                                fachadaOVivienda, fechaDeCompra,
                                                fechaDeVencimiento
                                              );
                    listaDeCableElectricos.Add(cable);

                }
            }
            this.fichero.Close();
            return listaDeCableElectricos;
        }

        public bool BorrarCable(int numeroDeSerie)
        {
            if (File.Exists(nombreFichero))
            {
                List<CableElectrico> listaRecuperada = this.RecuperarCable();
                int cableBorrar = 1 + listaRecuperada.FindIndex(c => c.NumeroDeSerie == numeroDeSerie);
                this.fichero = new FileStream(nombreFichero, FileMode.Open, FileAccess.Write);
                if (cableBorrar == 1)
                {
                    cableBorrar = 1;
                    this.fichero.Seek(169 * cableBorrar, SeekOrigin.Begin);
                    byte[] bytesBorrar = Encoding.ASCII.GetBytes("0");
                    this.fichero.Write(bytesBorrar, 0, 1);
                    this.fichero.Close();
                    Thread.Sleep(delay);
                    return true;
                }
                else if (cableBorrar >= 2)
                {
                    cableBorrar = (cableBorrar - 1) * 55;
                    this.fichero.Seek(169 + cableBorrar, SeekOrigin.Begin);
                    byte[] bytesBorrar = Encoding.ASCII.GetBytes("0");
                    this.fichero.Write(bytesBorrar, 0, 1);
                    this.fichero.Close();
                    Thread.Sleep(delay);
                    return true;
                }
            }
            Thread.Sleep(delay);
            return false;
        }

        public bool ModificarCable(CableElectrico cableElectrico)
        {
            if (File.Exists(nombreFichero))
            {
                String numeroDeSerie = ("1" + cableElectrico.NumeroDeSerie.ToString()).PadRight(6, ' ');
                String cantidadDeConductores = cableElectrico.CantidadDeConductores.ToString().PadRight(4, ' ');
                String marcaDelCable = cableElectrico.MarcaDelCable.PadRight(10, ' ');
                String metros = cableElectrico.Metros.ToString().PadRight(4, ' ');
                String seccionDelCable = cableElectrico.SeccionDelCable.ToString();
                String libreDeHalogenos = cableElectrico.LibreDeHalogenos.ToString().PadRight(5, ' ');
                String fachadaOVivienda = cableElectrico.FachadaOVivienda.ToString().PadRight(5, ' ');
                String fechaDeCompra = cableElectrico.FechaDeCompra.ToString("dd/MM/yyyy");
                String fechaDeVencimiento = cableElectrico.FechaDeVencimiento.ToString("dd/MM/yyyy");

                String cable = numeroDeSerie + cantidadDeConductores + marcaDelCable + metros + seccionDelCable +
                            libreDeHalogenos + fachadaOVivienda + fechaDeCompra + fechaDeVencimiento;


                List<CableElectrico> listaRecuperada = this.RecuperarCable();
                int metrosACamBiar = 1 + listaRecuperada.FindIndex(c => c.NumeroDeSerie == cableElectrico.NumeroDeSerie);
                this.fichero = new FileStream(nombreFichero, FileMode.Open, FileAccess.Write);
                if (metrosACamBiar == 1)
                {
                    this.fichero.Seek(169, SeekOrigin.Begin);
                    Byte[] bytesCable = Encoding.ASCII.GetBytes(cable);
                    this.fichero.Write(bytesCable, 0, bytesCable.Length);
                    this.fichero.Close();
                    Thread.Sleep(delay);
                    return true;
                }
                else if (metrosACamBiar >= 2)
                {
                    metrosACamBiar = (metrosACamBiar - 1) * 55;
                    this.fichero.Seek(169 + metrosACamBiar, SeekOrigin.Begin);
                    Byte[] bytesCable = Encoding.ASCII.GetBytes(cable);
                    this.fichero.Write(bytesCable, 0, bytesCable.Length);
                    this.fichero.Close();
                    Thread.Sleep(delay);
                    return true;

                }
            }
            this.fichero.Close();
            Thread.Sleep(delay);
            return false;
        }

        public List<CableElectrico> MostrarCablePorFechaDeCompraAscendente(DateTime fecha)
        {
            CableElectrico cable = new CableElectrico();
            List<CableElectrico> listaDeCable = new List<CableElectrico>();
            if (File.Exists(nombreFichero))
            {
                int numeroDeSerieRecuperado;
                int cantidadDeConductores;
                String marcaDelCable;
                float metrosRecuperados;
                char seccionDelCable;
                bool libreDeHalogenos;
                bool fachadaOVivienda;
                DateTime fechaDeCompra;
                DateTime fechaDeVencimiento;
                int cableBorrado;

                string cableDeVuelto = "";
                byte[] cableRecuperado = new byte[55];
                this.fichero = new FileStream(nombreFichero, FileMode.Open, FileAccess.Read);
                this.fichero.Seek(169, SeekOrigin.Begin);
                while (this.fichero.Read(cableRecuperado, 0, cableRecuperado.Length) > 0)
                {
                    cableDeVuelto = Encoding.ASCII.GetString(cableRecuperado);
                    numeroDeSerieRecuperado = int.Parse(cableDeVuelto.Substring(1, 5).Trim());
                    cableBorrado = int.Parse(cableDeVuelto.Substring(0, 1).Trim());
                    cantidadDeConductores = int.Parse(cableDeVuelto.Substring(6, 4).Trim());
                    marcaDelCable = cableDeVuelto.Substring(10, 10).Trim();
                    metrosRecuperados = float.Parse(cableDeVuelto.Substring(20, 4).Trim());
                    seccionDelCable = char.Parse(cableDeVuelto.Substring(24, 1));
                    libreDeHalogenos = bool.Parse(cableDeVuelto.Substring(25, 5).Trim());
                    fachadaOVivienda = bool.Parse(cableDeVuelto.Substring(30, 5).Trim());
                    fechaDeCompra = DateTime.Parse(cableDeVuelto.Substring(35, 10));
                    fechaDeVencimiento = DateTime.Parse(cableDeVuelto.Substring(45, 10));
                    cable = new CableElectrico(numeroDeSerieRecuperado, cantidadDeConductores, marcaDelCable,
                                                    metrosRecuperados, seccionDelCable, libreDeHalogenos,
                                                    fachadaOVivienda, fechaDeCompra,
                                                    fechaDeVencimiento
                                                );
                    if (cableBorrado > 0 && fechaDeCompra >= fecha)
                    {
                        listaDeCable.Add(cable);
                    }

                }
            }
            this.fichero.Close();
            Thread.Sleep(delay);
            return listaDeCable;
        }

        public List<CableElectrico> MostrarPorCantidadDeMetros(int metros)
        {
            CableElectrico cable = new CableElectrico();
            List<CableElectrico> listaDeCable = new List<CableElectrico>();
            if (File.Exists(nombreFichero))
            {
                int numeroDeSerieRecuperado;
                int cantidadDeConductores;
                String marcaDelCable;
                float metrosRecuperados;
                char seccionDelCable;
                bool libreDeHalogenos;
                bool fachadaOVivienda;
                DateTime fechaDeCompra;
                DateTime fechaDeVencimiento;
                int cableBorrado;

                string cableDeVuelto = "";
                byte[] cableRecuperado = new byte[55];
                this.fichero = new FileStream(nombreFichero, FileMode.Open, FileAccess.Read);
                this.fichero.Seek(169, SeekOrigin.Begin);
                while (this.fichero.Read(cableRecuperado, 0, cableRecuperado.Length) > 0)
                {
                    cableDeVuelto = Encoding.ASCII.GetString(cableRecuperado);
                    numeroDeSerieRecuperado = int.Parse(cableDeVuelto.Substring(1, 5).Trim());
                    cableBorrado = int.Parse(cableDeVuelto.Substring(0, 1).Trim());
                    cantidadDeConductores = int.Parse(cableDeVuelto.Substring(6, 4).Trim());
                    marcaDelCable = cableDeVuelto.Substring(10, 10).Trim();
                    metrosRecuperados = float.Parse(cableDeVuelto.Substring(20, 4).Trim());
                    seccionDelCable = char.Parse(cableDeVuelto.Substring(24, 1));
                    libreDeHalogenos = bool.Parse(cableDeVuelto.Substring(25, 5).Trim());
                    fachadaOVivienda = bool.Parse(cableDeVuelto.Substring(30, 5).Trim());
                    fechaDeCompra = DateTime.Parse(cableDeVuelto.Substring(35, 10));
                    fechaDeVencimiento = DateTime.Parse(cableDeVuelto.Substring(45, 10));
                    cable = new CableElectrico(numeroDeSerieRecuperado, cantidadDeConductores, marcaDelCable,
                                                    metrosRecuperados, seccionDelCable, libreDeHalogenos,
                                                    fachadaOVivienda, fechaDeCompra,
                                                    fechaDeVencimiento
                                                );
                    if (cableBorrado > 0 && metrosRecuperados >= metros)
                    {
                        listaDeCable.Add(cable);
                    }

                }
            }
            this.fichero.Close();
            Thread.Sleep(delay);
            return listaDeCable;
        }

        public CableElectrico MostrarPorNumeroDeSerie(int numeroDeSerie)
        {
            CableElectrico cable = new CableElectrico();
            if (File.Exists(nombreFichero))
            {
                int numeroDeSerieRecuperado;
                int cantidadDeConductores;
                String marcaDelCable;
                float metros;
                char seccionDelCable;
                bool libreDeHalogenos;
                bool fachadaOVivienda;
                DateTime fechaDeCompra;
                DateTime fechaDeVencimiento;

                string cableDeVuelto = "";
                byte[] cableRecuperado = new byte[55];
                this.fichero = new FileStream(nombreFichero, FileMode.Open, FileAccess.Read);
                this.fichero.Seek(169, SeekOrigin.Begin);
                while (this.fichero.Read(cableRecuperado, 0, cableRecuperado.Length) > 0)
                {
                    cableDeVuelto = Encoding.ASCII.GetString(cableRecuperado);
                    numeroDeSerieRecuperado = int.Parse(cableDeVuelto.Substring(1, 5).Trim());
                    int cableBorrado = int.Parse(cableDeVuelto.Substring(0, 1).Trim());
                    if (numeroDeSerieRecuperado == numeroDeSerie && cableBorrado != 0)
                    {
                        cantidadDeConductores = int.Parse(cableDeVuelto.Substring(6, 4).Trim());
                        marcaDelCable = cableDeVuelto.Substring(10, 10).Trim();
                        metros = float.Parse(cableDeVuelto.Substring(20, 4).Trim());
                        seccionDelCable = char.Parse(cableDeVuelto.Substring(24, 1));
                        libreDeHalogenos = bool.Parse(cableDeVuelto.Substring(25, 5).Trim());
                        fachadaOVivienda = bool.Parse(cableDeVuelto.Substring(30, 5).Trim());
                        fechaDeCompra = DateTime.Parse(cableDeVuelto.Substring(35, 10));
                        fechaDeVencimiento = DateTime.Parse(cableDeVuelto.Substring(45, 10));
                        cable = new CableElectrico(numeroDeSerieRecuperado, cantidadDeConductores, marcaDelCable,
                                                      metros, seccionDelCable, libreDeHalogenos,
                                                      fachadaOVivienda, fechaDeCompra,
                                                      fechaDeVencimiento
                                                   );
                    }
                }
            }
            this.fichero.Close();
            Thread.Sleep(delay);
            return cable;
        }

        public List<CableElectrico> MostrarTodoElCable()
        {
            CableElectrico cable = new CableElectrico();
            List<CableElectrico> listaDeCable = new List<CableElectrico>();
            if (File.Exists(nombreFichero))
            {
                int numeroDeSerieRecuperado;
                int cantidadDeConductores;
                String marcaDelCable;
                float metros;
                char seccionDelCable;
                bool libreDeHalogenos;
                bool fachadaOVivienda;
                DateTime fechaDeCompra;
                DateTime fechaDeVencimiento;
                int cableBorrado;

                string cableDeVuelto = "";
                byte[] cableRecuperado = new byte[55];
                this.fichero = new FileStream(nombreFichero, FileMode.Open, FileAccess.Read);
                this.fichero.Seek(169, SeekOrigin.Begin);
                while (this.fichero.Read(cableRecuperado, 0, cableRecuperado.Length) > 0)
                {
                    cableDeVuelto = Encoding.ASCII.GetString(cableRecuperado);
                    numeroDeSerieRecuperado = int.Parse(cableDeVuelto.Substring(1, 5).Trim());
                    cableBorrado = int.Parse(cableDeVuelto.Substring(0, 1).Trim());
                    if (cableBorrado > 0)
                    {
                        cantidadDeConductores = int.Parse(cableDeVuelto.Substring(6, 4).Trim());
                        marcaDelCable = cableDeVuelto.Substring(10, 10).Trim();
                        metros = float.Parse(cableDeVuelto.Substring(20, 4).Trim());
                        seccionDelCable = char.Parse(cableDeVuelto.Substring(24, 1));
                        libreDeHalogenos = bool.Parse(cableDeVuelto.Substring(25, 5).Trim());
                        fachadaOVivienda = bool.Parse(cableDeVuelto.Substring(30, 5).Trim());
                        fechaDeCompra = DateTime.Parse(cableDeVuelto.Substring(35, 10));
                        fechaDeVencimiento = DateTime.Parse(cableDeVuelto.Substring(45, 10));
                        cable = new CableElectrico(numeroDeSerieRecuperado, cantidadDeConductores, marcaDelCable,
                                                      metros, seccionDelCable, libreDeHalogenos,
                                                      fachadaOVivienda, fechaDeCompra,
                                                      fechaDeVencimiento
                                                   );

                        listaDeCable.Add(cable);
                    }

                }
            }
            this.fichero.Close();
            Thread.Sleep(delay);
            return listaDeCable;
        }
    }
}
