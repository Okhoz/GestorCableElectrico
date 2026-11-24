using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Businees
{
    public class BServidorAPIRest
    {
        private Socket socket;
        private Socket socketCliente;
        private IPAddress iPAddress;
        private IPEndPoint iPEndPoint;
        private bool sevidorArrancado = false;
        private byte[] infomacionRecivida;
        private BCableElectricoAsync bCableElectricoAsync;

        public BServidorAPIRest()
        {
            this.bCableElectricoAsync = new BCableElectricoAsync();
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
        public void IniciarServior()
        {
            this.iPAddress = IPAddress.Parse("127.0.0.1");

            try
            {
                if (sevidorArrancado == false)
                {
                    sevidorArrancado = true;
                    this.iPEndPoint = new IPEndPoint(iPAddress, 15000);
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

                    string[] peticionCliente = (Encoding.UTF8.GetString(infomacionRecivida).Split('\n'));
                    string parametro = peticionCliente[0];
                    string peticion = parametro.Split(' ')[1];
                    string peticionRecivida = parametro.Split('/')[0].Trim();

                    string[] elementosSolicitado = peticion.Split('/');

                    //Uri url = new Uri("http://0.0.0.0" + $"{peticion}");
                    //string añadir = ((HttpUtility.ParseQueryString(url.Query).Get("add"))).ToLower();

                    switch (peticionRecivida.ToLower())
                    {
                        case "delete":
                            if (elementosSolicitado[1] == "cable" && elementosSolicitado.Length <= 3)
                            {
                                EnviarPeticioBorrarCable(elementosSolicitado[2]).Wait();
                            }
                            else
                            {
                                EnviarPeticioBorrarCable("-1").Wait();
                            }
                            break;
                        case "post":

                            cable = JsonConvert.DeserializeObject<CableElectrico>(peticionCliente[10]);
                            EnviarPeticioAñadiendoUnCable(cable).Wait();

                            break;

                        case "put":

                            cable = JsonConvert.DeserializeObject<CableElectrico>(peticionCliente[10]);
                            EnviarPeticioModificarCable(cable, elementosSolicitado[1]).Wait();

                            break;

                        case "get":

                            if (elementosSolicitado[1] == "listaDeCables" && elementosSolicitado.Length <= 2)
                            {
                                EnviarPeticionConTodosLosCables();
                            }
                            else if (elementosSolicitado[1] == "cable" && elementosSolicitado.Length <= 3)
                            {
                                enviarPeticionDeUnCablePorId(int.Parse(elementosSolicitado[2]));
                            }
                            else
                            {
                                EnviarPeticionErronea();
                            }
                            break;

                        default:
                            EnviarPeticionErronea();
                            break;
                    }
                }
            }
            catch
            {

            }
            this.socketCliente.Shutdown(SocketShutdown.Both);
            this.socketCliente.Close();
        }

        public void EnviarPeticionErronea()
        {
            this.socketCliente.Send(Encoding.UTF8.GetBytes($"HTTP/1.1 404 Not Found\r\n" +
                                               $"Content-Type : application/json" +
                                               $"\r\n\r\n"));
        }

        public async Task EnviarPeticioAñadiendoUnCable(CableElectrico cable)
        {
            string repuesta;
            if (cable.ToString() != "0  |  0  |    |  0  |  -  |  No  |  No  |  01-01-1000  |  01-01-1000")
            {
                if (await bCableElectricoAsync.AñadirCable(cable))
                {
                    repuesta = $"HTTP/1.1 201 OK\r\n" +
                $"Content-Type : application/json\r\n\r\n";
                    this.socketCliente.Send(Encoding.UTF8.GetBytes(repuesta));
                }
                else
                {
                    repuesta = $"HTTP/1.1 400 Bad Request\r\n" +
                                $"Content-Type : application/json\r\n\r\n";
                    this.socketCliente.Send(Encoding.UTF8.GetBytes(repuesta));
                }
            }
        }

        public async Task EnviarPeticioModificarCable(CableElectrico cable, string id)
        {
            string repuesta;

            if (await bCableElectricoAsync.ModificarCable(cable) && cable.NumeroDeSerie == int.Parse(id))
            {
                repuesta = $"HTTP/1.1 200 OK\r\n" +
                            $"Content-Type : application/json\r\n\r\n";
                this.socketCliente.Send(Encoding.UTF8.GetBytes(repuesta));
            }
            else
            {
                repuesta = $"HTTP/1.1 404 Not Found\r\n" +
                            $"Content-Type : application/json\r\n\r\n";
                this.socketCliente.Send(Encoding.UTF8.GetBytes(repuesta));
            }

        }
        public async Task EnviarPeticioBorrarCable(string id)
        {
            string repuesta;

            if (await bCableElectricoAsync.BorrarCable(int.Parse(id)) && int.Parse(id) >= 0)
            {
                repuesta = $"HTTP/1.1 204 No Content\r\n" +
            $"Content-Type : application/json\r\n\r\n";
                this.socketCliente.Send(Encoding.UTF8.GetBytes(repuesta));
            }
            else
            {
                repuesta = $"HTTP/1.1 404 Not Found\r\n" +
                            $"Content-Type : application/json\r\n\r\n";
                this.socketCliente.Send(Encoding.UTF8.GetBytes(repuesta));
            }

        }
        private void EnviarPeticionConTodosLosCables()
        {
            List<CableElectrico> lista = bCableElectricoAsync.MostrarTodoElCable().Result;
            this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponseGETParaTodos(lista)));
        }
        private bool enviarPeticionDeUnCablePorId(int id)
        {
            CableElectrico cableElectrico = new CableElectrico();
            foreach (CableElectrico cable in bCableElectricoAsync.MostrarTodoElCable().Result)
            {
                if (cable.NumeroDeSerie == id)
                {
                    cableElectrico = cable;
                    this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponseGETParaUnCable(cableElectrico)));
                    return true;
                }
            }

            this.socketCliente.Send(Encoding.UTF8.GetBytes(HTTPResponseGETParaUnCable(cableElectrico) + JsonConvert.SerializeObject(404)));
            return false;
        }

        private string HTTPResponseGETParaUnCable(CableElectrico cable)
        {
            String repuesta = (cable.ToString() != "0  |  0  |    |  0  |  -  |  No  |  No  |  01-01-1000  |  01-01-1000") ?
                $"HTTP/1.1 200 OK\r\n" +
                $"Content-Type : application/json\r\n\r\n" +
                $"{JsonConvert.SerializeObject(cable)}"
                 :
                $"HTTP/1.1 404 Not Found\r\n" +
                $"Content-Type : application/json\r\n\r\n";
            return repuesta;
        }
        private String HTTPResponseGETParaTodos(List<CableElectrico> cables)
        {
            String repuesta = (cables.Count > 0) ?
                $"HTTP/1.1 200 OK\r\n" +
                $"Content-Type : application/json\r\n\r\n" +
                $"{JsonConvert.SerializeObject(cables)}"
                 :
                $"HTTP/1.1 404 Not Found\r\n" +
                $"Content-Type : application/json\r\n\r\n";

            return repuesta;
        }
    }
}
