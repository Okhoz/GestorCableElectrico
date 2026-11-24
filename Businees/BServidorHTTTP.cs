using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Businees
{
    public class BServidorHTTTP
    {
        private Socket socket;
        private Socket socketCliente;
        private IPAddress iPAddress;
        private IPEndPoint iPEndPoint;
        private bool sevidorArrancado = false;
        private byte[] infomacionRecivida;
        private Action<String> rellenarLog;
        private BCableElectricoAsync bCableElectricoAsync;
        private string ficheroHTML = File.ReadAllText("..\\..\\..\\PaginasWebsDelServidor\\MenuCable.html");
        private string ficheroErrorHTML = File.ReadAllText("..\\..\\..\\PaginasWebsDelServidor\\Error.html");
        private string ficheroAñadirHTML = File.ReadAllText("..\\..\\..\\PaginasWebsDelServidor\\Fomulario.html");
        private string ficheroModificarCableHTML = File.ReadAllText("..\\..\\..\\PaginasWebsDelServidor\\ModificarCable.html");
        private string ficheroCableCreado = File.ReadAllText("..\\..\\..\\PaginasWebsDelServidor\\CableCreado.html");
        private string ficheroCableExistente = File.ReadAllText("..\\..\\..\\PaginasWebsDelServidor\\CableExistente.html");


        public BServidorHTTTP(Action<String> rellenarLog)
        {
            this.rellenarLog = rellenarLog;
            this.bCableElectricoAsync = new BCableElectricoAsync();
        }


        public void IniciarServior()
        {
            this.iPAddress = IPAddress.Parse("127.0.0.1");

            try
            {
                if (sevidorArrancado == false)
                {
                    sevidorArrancado = true;
                    this.iPEndPoint = new IPEndPoint(iPAddress, 8080);
                    this.socket = new Socket(this.iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    this.socket.Bind(iPEndPoint);
                    this.socket.Listen(10);

                    AceptarPeticiones();
                }
            }
            catch { }

        }

        private void AceptarPeticiones()
        {
            Task.Run(async () =>
            {
                try
                {
                    while (this.sevidorArrancado == true)
                    {
                        this.socketCliente = this.socket.Accept();
                        if (this.socketCliente != null)
                        {
                            await RecivirPeticiones(this.socketCliente);
                        }
                        Thread.Sleep(100);
                    }
                }
                catch
                {
                }
            });
        }
        private async Task RecivirPeticiones(Socket socketRecibido)
        {
            CableElectrico cable;
            string texto = "";
            try
            {
                if (socketRecibido != null)
                {
                    infomacionRecivida = new byte[8192];
                    socketRecibido.Receive(infomacionRecivida);
                    //Log
                    this.rellenarLog(Encoding.UTF8.GetString(infomacionRecivida) + Environment.NewLine.ToString());
                    string[] peticionCliente = (Encoding.UTF8.GetString(infomacionRecivida).Split('\n'));
                    string parametro = peticionCliente[0];
                    string peticion = parametro.Split(' ')[1];

                    Uri url = new Uri("http://0.0.0.0" + $"{peticion}");

                    string accion = HttpUtility.ParseQueryString(url.Query).Get("accion");
                    if (accion == "star")
                    {
                        MostrarTodaLaTabla(texto);
                    }
                    else if (accion == "getelements")
                    {
                        MostrarTodaLaTabla(texto);

                    }
                    else if (accion == "editelement")
                    {
                        cable = AddElement(url);
                        if (cable == null)
                        {
                            this.CargarDatosAModificar((HttpUtility.ParseQueryString(url.Query).Get("id")));
                        }
                        else if (cable != null && !string.IsNullOrEmpty(HttpUtility.ParseQueryString(url.Query).Get("id")) && bCableElectricoAsync.ModificarCable(cable).Result)
                        {
                            texto = ficheroCableCreado;
                            this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
                        }
                        else
                        {
                            texto = ficheroErrorHTML;
                            this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
                        }

                    }
                    else if (accion == "getelement")
                    {
                        if (!string.IsNullOrEmpty(HttpUtility.ParseQueryString(url.Query).Get("id")))
                        {
                            string id = HttpUtility.ParseQueryString(url.Query).Get("id");
                            MostrarCable(texto, id);
                        }
                        else if (!string.IsNullOrEmpty(HttpUtility.ParseQueryString(url.Query).Get("fechaCompra")))
                        {
                            string fechaCompra = HttpUtility.ParseQueryString(url.Query).Get("fechaCompra");
                            MostrarPorFechaDeCompra(texto, fechaCompra);
                        }
                        else if (!string.IsNullOrEmpty(HttpUtility.ParseQueryString(url.Query).Get("metros")))
                        {
                            string metros = HttpUtility.ParseQueryString(url.Query).Get("metros");
                            MostrarPorMetros(texto, metros);
                        }
                        else
                        {
                            texto = ficheroErrorHTML;
                            this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
                        }


                    }
                    else if (accion == "addelement")
                    {
                        cable = AddElement(url);
                        if (cable == null)
                        {
                            texto = ficheroAñadirHTML;
                            this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));

                        }
                        else if (cable != null && bCableElectricoAsync.AñadirCable(cable).Result == true)
                        {
                            texto = ficheroCableCreado;
                            this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
                        }
                        else if (cable != null && bCableElectricoAsync.AñadirCable(cable).Result == false)
                        {
                            texto = ficheroCableExistente;
                            this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
                        }
                    }
                    else if (accion == "deleteelement")
                    {
                        string id = HttpUtility.ParseQueryString(url.Query).Get("id");
                        if (!string.IsNullOrEmpty(HttpUtility.ParseQueryString(url.Query).Get("id")))
                        {
                            BorrarCable(texto, id);
                        }
                    }
                    else
                    {
                        texto = ficheroErrorHTML;
                        this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
                    }
                    this.socketCliente.Close();
                }
            }
            catch
            {
            }
        }

        public void ParrarServidor()
        {
            if (this.socket != null)
            {
                if (this.socketCliente != null)
                {
                    this.socketCliente.Close();
                }
                this.socket.Close();
                this.sevidorArrancado = false;
            }
        }

        private CableElectrico AddElement(Uri url)
        {
            if (int.TryParse(HttpUtility.ParseQueryString(url.Query).Get("id"), out int id))
            {
                if (int.TryParse(HttpUtility.ParseQueryString(url.Query).Get("cantidadDeConductores"), out int conductores))
                {
                    if (float.TryParse(HttpUtility.ParseQueryString(url.Query).Get("metros"), out float metro))
                    {
                        if (char.TryParse(HttpUtility.ParseQueryString(url.Query).Get("seccionDelCable").Substring(0, 1), out char seccion))
                        {
                            if (bool.TryParse(HttpUtility.ParseQueryString(url.Query).Get("libreDeHalogenos"), out bool halogenos))
                            {
                                if (bool.TryParse(HttpUtility.ParseQueryString(url.Query).Get("fachadaOVivienda"), out bool lugar))
                                {
                                    if (DateTime.TryParse(HttpUtility.ParseQueryString(url.Query).Get("fechaDeCompra"), out DateTime compra))
                                    {
                                        if (DateTime.TryParse(HttpUtility.ParseQueryString(url.Query).Get("fechaDeVencimiento"), out DateTime vencimiento))
                                        {
                                            if (!string.IsNullOrEmpty(HttpUtility.ParseQueryString(url.Query).Get("marcaDelCable")))
                                            {
                                                int numeroDeSerie = id;
                                                int cantidadDeConductores = conductores;
                                                String marcaDelCable = HttpUtility.ParseQueryString(url.Query).Get("marcaDelCable");
                                                float metros = metro;
                                                char seccionDelCable = seccion;
                                                bool libreDeHalogenos = halogenos;
                                                bool fachadaOVivienda = lugar;
                                                DateTime fechaDeCompra = compra;
                                                DateTime fechaDeVencimiento = vencimiento;
                                                CableElectrico cable = new CableElectrico(numeroDeSerie, cantidadDeConductores, marcaDelCable, metros, seccionDelCable, libreDeHalogenos, fachadaOVivienda, fechaDeCompra, fechaDeVencimiento);
                                                return cable;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        private String HTTPResponse(int size)
        {
            return $"HTTP/1.1  200 OK\nContent-Length: {size}\nContent-Type: text/html\n\n";
        }

        private void BorrarCable(string texto, string id)
        {
            string cambiarDatos = "";
            List<CableElectrico> listaDeCable = bCableElectricoAsync.MostrarTodoElCable().Result;
            texto = ficheroHTML;
            if (!string.IsNullOrEmpty(id))
            {
                bCableElectricoAsync.BorrarCable(int.Parse(id)).Wait();
                listaDeCable = bCableElectricoAsync.MostrarTodoElCable().Result;
            }
            foreach (CableElectrico list in listaDeCable)
            {
                cambiarDatos += "\r\n <tr>" +
                                $"\r\n    <td>{list.NumeroDeSerie}</td>" +
                                $"\r\n    <td>{list.CantidadDeConductores}</td>" +
                                $"\r\n    <td>{list.MarcaDelCable}</td>" +
                                $"\r\n    <td>{list.Metros}</td>" +
                                $"\r\n    <td>{list.SeccionDelCable}</td>" +
                                $"\r\n    <td>{list.LibreDeHalogenos}</td>" +
                                $"\r\n    <td>{list.FachadaOVivienda}</td>" +
                                $"\r\n    <td>{list.FechaDeCompra.ToString("dd/MM/yyyy")}</td>" +
                                $"\r\n    <td>{list.FechaDeVencimiento.ToString("dd/MM/yyyy")}</td>\r\n  " +
                                "</tr>\r\n ";
            }
            if (listaDeCable.Count >= 0)
            {
                texto = texto.Replace("            {{{tabla}}}\r\n", cambiarDatos);
                string s = texto;

                this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
            }
            else
            {
                texto = ficheroErrorHTML;
                this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
            }
        }
        private void MostrarCable(string texto, string id)
        {
            CableElectrico cable = bCableElectricoAsync.MostrarPorNumeroDeSerie(int.Parse(id)).Result;
            string cambiarDatos = "";
            List<CableElectrico> listaDeCable = bCableElectricoAsync.MostrarTodoElCable().Result;
            texto = ficheroHTML;
            if (!string.IsNullOrEmpty(id) && cable.ToString() != "0  |  0  |    |  0  |  -  |  No  |  No  |  01-01-1000  |  01-01-1000")
            {
                cambiarDatos += "\r\n <tr>" +
                                    $"\r\n    <td>{cable.NumeroDeSerie}</td>" +
                                    $"\r\n    <td>{cable.CantidadDeConductores}</td>" +
                                    $"\r\n    <td>{cable.MarcaDelCable}</td>" +
                                    $"\r\n    <td>{cable.Metros}</td>" +
                                    $"\r\n    <td>{cable.SeccionDelCable}</td>" +
                                    $"\r\n    <td>{cable.LibreDeHalogenos}</td>" +
                                    $"\r\n    <td>{cable.FachadaOVivienda}</td>" +
                                    $"\r\n    <td>{cable.FechaDeCompra.ToString("dd/MM/yyyy")}</td>" +
                                    $"\r\n    <td>{cable.FechaDeVencimiento.ToString("dd/MM/yyyy")}</td>\r\n  " +
                                    "</tr>\r\n ";
            }
            else
            {
                foreach (CableElectrico list in listaDeCable)
                {
                    cambiarDatos += "\r\n <tr>" +
                                    $"\r\n    <td>{list.NumeroDeSerie}</td>" +
                                    $"\r\n    <td>{list.CantidadDeConductores}</td>" +
                                    $"\r\n    <td>{list.MarcaDelCable}</td>" +
                                    $"\r\n    <td>{list.Metros}</td>" +
                                    $"\r\n    <td>{list.SeccionDelCable}</td>" +
                                    $"\r\n    <td>{list.LibreDeHalogenos}</td>" +
                                    $"\r\n    <td>{list.FachadaOVivienda}</td>" +
                                    $"\r\n    <td>{list.FechaDeCompra.ToString("dd/MM/yyyy")}</td>" +
                                    $"\r\n    <td>{list.FechaDeVencimiento.ToString("dd/MM/yyyy")}</td>\r\n  " +
                                    "</tr>\r\n ";
                }
            }

            if (listaDeCable.Count != 0)
            {
                texto = texto.Replace("            {{{tabla}}}\r\n", cambiarDatos);
                string s = texto;

                this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
            }
            else
            {
                texto = ficheroErrorHTML;
                this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
            }
        }

        private void MostrarTodaLaTabla(string texto)
        {
            string cambiarDatos = "";
            List<CableElectrico> listaDeCable = bCableElectricoAsync.MostrarTodoElCable().Result;
            texto = ficheroHTML;
            foreach (CableElectrico list in listaDeCable)
            {
                cambiarDatos += "\r\n <tr>" +
                                $"\r\n    <td>{list.NumeroDeSerie}</td>" +
                                $"\r\n    <td>{list.CantidadDeConductores}</td>" +
                                $"\r\n    <td>{list.MarcaDelCable}</td>" +
                                $"\r\n    <td>{list.Metros}</td>" +
                                $"\r\n    <td>{list.SeccionDelCable}</td>" +
                                $"\r\n    <td>{list.LibreDeHalogenos}</td>" +
                                $"\r\n    <td>{list.FachadaOVivienda}</td>" +
                                $"\r\n    <td>{list.FechaDeCompra.ToString("dd/MM/yyyy")}</td>" +
                                $"\r\n    <td>{list.FechaDeVencimiento.ToString("dd/MM/yyyy")}</td>\r\n  " +
                                "</tr>\r\n ";
            }
            if (listaDeCable.Count >= 0)
            {
                texto = texto.Replace("            {{{tabla}}}\r\n", cambiarDatos);
                string s = texto;

                this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
            }
            else
            {
                texto = ficheroErrorHTML;
                this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
            }
        }
        private void MostrarPorMetros(string texto, string metros)
        {
            string cambiarDatos = "";
            List<CableElectrico> listaDeCable = bCableElectricoAsync.MostrarTodoElCable().Result;
            texto = ficheroHTML;
            if (!string.IsNullOrEmpty(metros))
            {
                listaDeCable = bCableElectricoAsync.MostrarPorCantidadDeMetros(int.Parse(metros)).Result;
                foreach (CableElectrico list in listaDeCable)
                {
                    cambiarDatos += "\r\n <tr>" +
                                    $"\r\n    <td>{list.NumeroDeSerie}</td>" +
                                    $"\r\n    <td>{list.CantidadDeConductores}</td>" +
                                    $"\r\n    <td>{list.MarcaDelCable}</td>" +
                                    $"\r\n    <td>{list.Metros}</td>" +
                                    $"\r\n    <td>{list.SeccionDelCable}</td>" +
                                    $"\r\n    <td>{list.LibreDeHalogenos}</td>" +
                                    $"\r\n    <td>{list.FachadaOVivienda}</td>" +
                                    $"\r\n    <td>{list.FechaDeCompra.ToString("dd/MM/yyyy")}</td>" +
                                    $"\r\n    <td>{list.FechaDeVencimiento.ToString("dd/MM/yyyy")}</td>\r\n  " +
                                    "</tr>\r\n ";
                }
            }
            else
            {
                foreach (CableElectrico list in listaDeCable)
                {
                    cambiarDatos += "\r\n <tr>" +
                                    $"\r\n    <td>{list.NumeroDeSerie}</td>" +
                                    $"\r\n    <td>{list.CantidadDeConductores}</td>" +
                                    $"\r\n    <td>{list.MarcaDelCable}</td>" +
                                    $"\r\n    <td>{list.Metros}</td>" +
                                    $"\r\n    <td>{list.SeccionDelCable}</td>" +
                                    $"\r\n    <td>{list.LibreDeHalogenos}</td>" +
                                    $"\r\n    <td>{list.FachadaOVivienda}</td>" +
                                    $"\r\n    <td>{list.FechaDeCompra.ToString("dd/MM/yyyy")}</td>" +
                                    $"\r\n    <td>{list.FechaDeVencimiento.ToString("dd/MM/yyyy")}</td>\r\n  " +
                                    "</tr>\r\n ";
                }
            }

            if (listaDeCable.Count != 0)
            {
                texto = texto.Replace("            {{{tabla}}}\r\n", cambiarDatos);
                string s = texto;

                this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
            }
            else
            {
                texto = ficheroErrorHTML;
                this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
            }
        }

        private void CargarDatosAModificar(string id)
        {
            string texto = "";
            CableElectrico cable = bCableElectricoAsync.MostrarPorNumeroDeSerie(int.Parse(id)).Result;
            if (cable.ToString() != "0  |  0  |    |  0  |  -  |  No  |  No  |  01-01-1000  |  01-01-1000")
            {
                texto = ficheroModificarCableHTML;
                texto = texto.Replace("${id}", cable.NumeroDeSerie.ToString());
                texto = texto.Replace("${cantidadDeConductores}", cable.CantidadDeConductores.ToString());
                texto = texto.Replace("${marcaDelCable}", cable.MarcaDelCable.ToString());
                texto = texto.Replace("${metros}", cable.Metros.ToString());
                texto = texto.Replace("${seccionDelCable}", cable.SeccionDelCable.ToString().Substring(0, 1));

                string seleccionadoSi = cable.LibreDeHalogenos ? "selected" : "";
                string seleccionadoNo = !cable.LibreDeHalogenos ? "selected" : "";

                texto = texto.Replace("${selectedLibreSi}", seleccionadoSi);
                texto = texto.Replace("${selectedLibreNo}", seleccionadoNo);

                string fachadaOViviendaSi = cable.FachadaOVivienda ? "selected" : "";
                string fachadaOViviendaNo = !cable.FachadaOVivienda ? "selected" : "";

                texto = texto.Replace("${fachadaOViviendaSi}", fachadaOViviendaSi);
                texto = texto.Replace("${fachadaOViviendaNo}", fachadaOViviendaNo);

                texto = texto.Replace("${fechaDeCompra}", cable.FechaDeCompra.ToString("yyyy-MM-dd"));
                texto = texto.Replace("${fechaDeVencimiento}", cable.FechaDeVencimiento.ToString("yyyy-MM-dd"));
                this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));

            }
            else
            {
                MostrarTodaLaTabla(texto);
            }

        }
        private void MostrarPorFechaDeCompra(string texto, string fechaCompra)
        {
            string cambiarDatos = "";
            List<CableElectrico> listaDeCable = bCableElectricoAsync.MostrarTodoElCable().Result;
            texto = ficheroHTML;
            if (!string.IsNullOrEmpty(fechaCompra))
            {
                listaDeCable = bCableElectricoAsync.MostrarCableEnBaseAUnCriterioDeFecha(DateTime.Parse(fechaCompra)).Result;
                foreach (CableElectrico list in listaDeCable)
                {
                    cambiarDatos += "\r\n <tr>" +
                                    $"\r\n    <td>{list.NumeroDeSerie}</td>" +
                                    $"\r\n    <td>{list.CantidadDeConductores}</td>" +
                                    $"\r\n    <td>{list.MarcaDelCable}</td>" +
                                    $"\r\n    <td>{list.Metros}</td>" +
                                    $"\r\n    <td>{list.SeccionDelCable}</td>" +
                                    $"\r\n    <td>{list.LibreDeHalogenos}</td>" +
                                    $"\r\n    <td>{list.FachadaOVivienda}</td>" +
                                    $"\r\n    <td>{list.FechaDeCompra.ToString("dd/MM/yyyy")}</td>" +
                                    $"\r\n    <td>{list.FechaDeVencimiento.ToString("dd/MM/yyyy")}</td>\r\n  " +
                                    "</tr>\r\n ";
                }
            }
            else
            {
                foreach (CableElectrico list in listaDeCable)
                {
                    cambiarDatos += "\r\n <tr>" +
                                    $"\r\n    <td>{list.NumeroDeSerie}</td>" +
                                    $"\r\n    <td>{list.CantidadDeConductores}</td>" +
                                    $"\r\n    <td>{list.MarcaDelCable}</td>" +
                                    $"\r\n    <td>{list.Metros}</td>" +
                                    $"\r\n    <td>{list.SeccionDelCable}</td>" +
                                    $"\r\n    <td>{list.LibreDeHalogenos}</td>" +
                                    $"\r\n    <td>{list.FachadaOVivienda}</td>" +
                                    $"\r\n    <td>{list.FechaDeCompra.ToString("dd/MM/yyyy")}</td>" +
                                    $"\r\n    <td>{list.FechaDeVencimiento.ToString("dd/MM/yyyy")}</td>\r\n  " +
                                    "</tr>\r\n ";
                }
            }

            if (listaDeCable.Count != 0)
            {
                texto = texto.Replace("            {{{tabla}}}\r\n", cambiarDatos);
                string s = texto;

                this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
            }
            else
            {
                texto = ficheroErrorHTML;
                this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponse(texto.Length) + texto));
            }
        }
    }
}
