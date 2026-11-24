using Businees;
using Model;
using System;
using System.Collections.Generic;

namespace ViewConsola
{
    internal class Program
    {
        public static void Main(string[] args)
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
            BCableElectrico bCableElectrico = new BCableElectrico();
            CableElectrico cable;

            int opcion = -1;
            Console.WriteLine("|||                 ¡¡¡Bienvenido!!!                 |||");
            Console.WriteLine("|||                                                  |||");
            TextoDeInicio();
            opcion = int.Parse(Console.ReadLine());
            while (true)
            {
                if (opcion == 0)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Saliendo....");
                    Console.WriteLine();

                    break;
                }
                else if (opcion == 1)
                {
                    Console.Clear();
                    cable = CrearCable();
                    if (bCableElectrico.AñadirCable(cable) == true)
                    {
                        Console.WriteLine();

                        Console.WriteLine("|||Añadido|||");
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine();

                        Console.WriteLine("Error");
                        Console.WriteLine();

                    }
                }
                else if (opcion == 2)
                {
                    Console.Clear();
                    Console.WriteLine("|||Introduce el numero de serie|||");
                    int numeroDeSerie = int.Parse(Console.ReadLine());
                    if (bCableElectrico.BorrarCable(numeroDeSerie) == true)
                    {
                        Console.WriteLine();

                        Console.WriteLine("|||Borrado|||");
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine();

                        Console.WriteLine("Error");
                        Console.WriteLine();

                    }
                }
                else if (opcion == 3)
                {

                    List<CableElectrico> texto = bCableElectrico.MostrarTodoElCable();
                    if (texto.Count > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine(elementos);
                        texto.ForEach(x => Console.WriteLine("Numero De serie:" + x.NumeroDeSerie + ",Metros: " + x.Metros + ", seccion: " + x.SeccionDelCable + ", Fechada o vivienda: " + x.FachadaOVivienda));
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine();

                        Console.WriteLine("Error");
                        Console.WriteLine();

                    }
                }
                else if (opcion == 4)
                {
                    Console.Clear();
                    Console.WriteLine("|||Introduce el numero de serie|||");
                    int numeroDeSerie = int.Parse(Console.ReadLine());
                    CableElectrico cableElectrico = bCableElectrico.MostrarPorNumeroDeSerie(numeroDeSerie);
                    if (cableElectrico != null && cableElectrico.ToString().Trim() != "0  |  0  |    |  0  |  -  |  No  |  No  |  1000-01-01  |  1000-01-01")
                    {
                        Console.WriteLine();
                        Console.WriteLine(elementos);
                        Console.WriteLine(cableElectrico.ToString());
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine();

                        Console.WriteLine("Error");
                        Console.WriteLine();

                    }
                }
                else if (opcion == 5)
                {
                    Console.Clear();
                    CableElectrico cablecito = CrearCable(); ;
                    if (bCableElectrico.ModificarCable(cablecito) == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("¡¡Cambio efectuado!!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("!!!Error¡¡¡");
                        Console.WriteLine();
                    }
                }
                else if (opcion == 6)
                {
                    Console.Clear();
                    Console.WriteLine("|||Introduce la fecha de busqueda|||");
                    String fechaDeCompra = Console.ReadLine();
                    List<CableElectrico> listaDeCable = bCableElectrico.MostrarCableEnBaseAUnCriterioDeFecha(DateTime.Parse(fechaDeCompra));
                    if (listaDeCable.Count == 0 || fechaDeCompra == null || fechaDeCompra == string.Empty)
                    {
                        Console.WriteLine();

                        Console.WriteLine("!!!Error¡¡¡¡");
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine(elementos);
                        listaDeCable.ForEach(x => Console.WriteLine(x.ToString()));
                        Console.WriteLine();

                    }
                }
                else if (opcion == 7)
                {
                    Console.Clear();
                    Console.WriteLine("|||Introduce la cantidad de metros|||");
                    int cantidadDeMetros = int.Parse(Console.ReadLine());
                    List<CableElectrico> listaDeMetros = bCableElectrico.MostrarPorCantidadDeMetros(cantidadDeMetros);
                    if (listaDeMetros.Count > 0 && cantidadDeMetros != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine(elementos);
                        listaDeMetros.ForEach(x => Console.WriteLine(x.ToString()));
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine();

                        Console.WriteLine("!!!Error¡¡¡");
                        Console.WriteLine();

                    }
                }


                else
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("!Opcion no valida vuelve a intentarlo¡");
                    Console.WriteLine();

                }
                TextoDeInicio();
                opcion = int.Parse(Console.ReadLine());
            }

        }

        public static CableElectrico CrearCable()
        {
            CableElectrico cable;
            Console.WriteLine("|||Introduce el numero de serie                                         |||");
            int numeroDeSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("|||Introduce la cantidad de conductores                                 |||");
            int cantidadDeConductores = int.Parse(Console.ReadLine());
            Console.WriteLine("|||Introduce la marca del cable                                         |||");
            String marcaDelCable = Console.ReadLine();
            Console.WriteLine("|||Introduce el numero de metros                                        |||");
            float metros = int.Parse(Console.ReadLine());
            Console.WriteLine("|||Introduce la seccion del cable                                       |||");
            char seccionDelCable = char.Parse(Console.ReadLine());
            Console.WriteLine("|||Introduce si es libre de Halogenos (true->si/false->no)              |||");
            bool libreDeHalogenos = bool.Parse(Console.ReadLine());
            Console.WriteLine("|||Introduce si es de fachada o vivienda (true->vivienda/false->fachada)|||");
            bool fachadaOVivienda = bool.Parse(Console.ReadLine());
            Console.WriteLine("|||Introduce la fecha de compra                                         |||");
            DateTime fechaDeCompra = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("|||Introduce el numero de vencimiento del aislante                      |||");
            DateTime fechaDeVencimiento = DateTime.Parse(Console.ReadLine());
            cable = new CableElectrico(numeroDeSerie, cantidadDeConductores, marcaDelCable, metros,
                                        seccionDelCable, libreDeHalogenos, fachadaOVivienda, fechaDeCompra,
                                        fechaDeVencimiento
                                        );
            return cable;
        }

        public static void TextoDeInicio()
        {

            Console.WriteLine("|||              Selecciona una opcion:              |||");
            Console.WriteLine("|||                                                  |||");
            Console.WriteLine("|||0.--> Salir                                       |||");
            Console.WriteLine("|||1.--> Añadir Cables                               |||");
            Console.WriteLine("|||2.--> Borrar Cable                                |||");
            Console.WriteLine("|||3.--> Mostrar todo                                |||");
            Console.WriteLine("|||4.--> Mostrar por numero de serie                 |||");
            Console.WriteLine("|||5.--> Cambiar cantidad de metros de un cable      |||");
            Console.WriteLine("|||6.--> Mostrar en base a fecha de compra ascendete |||");
            Console.WriteLine("|||7.--> Mostrar por cantidad de metros              |||");
        }
    }
}
