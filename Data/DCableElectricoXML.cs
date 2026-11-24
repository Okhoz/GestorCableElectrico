using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Data
{
    public class DCableElectricoXML : ICableElectricoFichero
    {
        private string direccionXML = "..\\..\\..\\AlmacenXML.xml";
        private XmlDocument xmlDoc;
        public DCableElectricoXML()
        {
            this.xmlDoc = new XmlDocument();
            this.CrearFichero();
        }
        private bool CrearFichero()
        {
            if (!File.Exists(direccionXML))
            {
                /*
                 * Creamos la declaracion del documento con "XmlDeclaration" mediante el metodo
                 * "CreateXmlDeclaration" de la clase "XmlDocument" añadiendo asi la codificacion del archivo
                 */
                XmlDeclaration declaracion = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);

                /*
                 * Añadimos la declaracion al documento
                 */
                xmlDoc.AppendChild(declaracion);

                /*
                 * Creamos el elemento raiz
                 */
                XmlElement xmlElement = xmlDoc.CreateElement("Cables");

                /*
                 * Lo añadimos al documento
                 */
                xmlDoc.AppendChild(xmlElement);

                /*
                 * Guardamos la informacion del documento xml en el directorio anteriormente creado con la propia
                 * inicializacion del metodo
                 * 
                 * ejemplo:
                 *  this.xmlDoc = new XmlDocument();
                 *  
                 * con el .save() se le asigna el nombre si ese documento no existe 
                 */
                xmlDoc.Save(direccionXML);

                return true;
            }

            return false;

        }

        public bool AñadirCable(CableElectrico cableElectrico)
        {
            if (File.Exists(direccionXML))
            {
                this.xmlDoc.Load(direccionXML);
                List<CableElectrico> listaRecuperada = this.RecuperarListaDeCableDelXML();

                if (listaRecuperada.Exists(l => l.NumeroDeSerie == cableElectrico.NumeroDeSerie) == false)
                {
                    XmlElement cable = xmlDoc.CreateElement("Cable_electrico");
                    cable.SetAttribute("Numero_de_serie", $"{cableElectrico.NumeroDeSerie}");

                    XmlNode cantidadDeConductores = xmlDoc.CreateElement("Cantidad_de_conductores");
                    cantidadDeConductores.InnerText = cableElectrico.CantidadDeConductores.ToString();
                    cable.AppendChild(cantidadDeConductores);

                    XmlNode marcaDelCable = xmlDoc.CreateElement("Marca_del_cable");
                    marcaDelCable.InnerText = cableElectrico.MarcaDelCable.ToString();
                    cable.AppendChild(marcaDelCable);

                    XmlNode metros = xmlDoc.CreateElement("Metros");
                    metros.InnerText = cableElectrico.Metros.ToString();
                    cable.AppendChild(metros);

                    XmlNode seccionDelCable = xmlDoc.CreateElement("Seccion_del_cable");
                    seccionDelCable.InnerText = cableElectrico.SeccionDelCable.ToString().Substring(0, 1);
                    cable.AppendChild(seccionDelCable);

                    XmlNode libreDeHalogenos = xmlDoc.CreateElement("Libre_de_Halogenos");
                    libreDeHalogenos.InnerText = cableElectrico.LibreDeHalogenos.ToString();
                    cable.AppendChild(libreDeHalogenos);

                    XmlNode fachadaOVivienda = xmlDoc.CreateElement("Fachada_o_Vivienda");
                    fachadaOVivienda.InnerText = cableElectrico.FachadaOVivienda.ToString();
                    cable.AppendChild(fachadaOVivienda);

                    XmlNode fechaDeCompra = xmlDoc.CreateElement("Fecha_de_compra");
                    fechaDeCompra.InnerText = cableElectrico.FechaDeCompra.ToString("dd,MM,yyyy");
                    cable.AppendChild(fechaDeCompra);

                    XmlNode fechaDeVencimiento = xmlDoc.CreateElement("Fecha_de_vencimiento");
                    fechaDeVencimiento.InnerText = cableElectrico.FechaDeVencimiento.ToString("dd,MM,yyyy");
                    cable.AppendChild(fechaDeVencimiento);

                    XmlNode contenedorDeCables = xmlDoc.DocumentElement;
                    contenedorDeCables.AppendChild(cable);

                    xmlDoc.Save(direccionXML);
                    return true;
                }
            }
            return false;
        }

        private List<CableElectrico> RecuperarListaDeCableDelXML()
        {
            List<CableElectrico> listaRecuperada = new List<CableElectrico>();
            int numeroDeSerie;
            int cantidadDeConductores;
            String marcaDelCable;
            float metros;
            char seccionDelCable;
            bool libreDeHalogenos;
            bool fachadaOVivienda;
            DateTime fechaDeCompra;
            DateTime fechaDeVencimiento;
            CableElectrico cable;

            if (File.Exists(direccionXML))
            {
                this.xmlDoc.Load(direccionXML);
                XmlNodeList listaDeNodosDeCables = xmlDoc.SelectNodes("/Cables/Cable_electrico");

                foreach (XmlNode lista in listaDeNodosDeCables)
                {
                    numeroDeSerie = int.Parse(lista.Attributes[0].Value);
                    cantidadDeConductores = int.Parse(lista.ChildNodes[0].InnerText);
                    marcaDelCable = lista.ChildNodes[1].InnerText;
                    metros = float.Parse(lista.ChildNodes[2].InnerText);
                    seccionDelCable = char.Parse(lista.ChildNodes[3].InnerText.Substring(0, 1));
                    libreDeHalogenos = bool.Parse(lista.ChildNodes[4].InnerText);
                    fachadaOVivienda = bool.Parse(lista.ChildNodes[5].InnerText);
                    fechaDeCompra = DateTime.Parse(lista.ChildNodes[6].InnerText);
                    fechaDeVencimiento = DateTime.Parse(lista.ChildNodes[7].InnerText);

                    cable = new CableElectrico(numeroDeSerie, cantidadDeConductores, marcaDelCable, metros,
                                               seccionDelCable, libreDeHalogenos, fachadaOVivienda, fechaDeCompra,
                                               fechaDeVencimiento
                                                );
                    listaRecuperada.Add(cable);
                }
            }
            return listaRecuperada;
        }

        public bool BorrarCable(int numeroDeSerie)
        {
            if (File.Exists(direccionXML))
            {
                this.xmlDoc.Load(direccionXML);
                List<CableElectrico> listaRecuperada = this.RecuperarListaDeCableDelXML();

                if (listaRecuperada.Exists(l => l.NumeroDeSerie == numeroDeSerie))
                {
                    XmlNode elemtoABorrar = xmlDoc.SelectSingleNode($"*/Cable_electrico[@Numero_de_serie={numeroDeSerie}]");
                    elemtoABorrar.ParentNode.RemoveChild(elemtoABorrar);
                    xmlDoc.Save(direccionXML);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarCable(CableElectrico cableElectrico)
        {
            if (File.Exists(direccionXML))
            {
                this.xmlDoc.Load(direccionXML);
                List<CableElectrico> listaRecuperada = this.RecuperarListaDeCableDelXML();

                if (listaRecuperada.Exists(l => l.NumeroDeSerie == cableElectrico.NumeroDeSerie))
                {
                    XmlNode nodoAModificar = xmlDoc.SelectSingleNode($"*/Cable_electrico[@Numero_de_serie='{cableElectrico.NumeroDeSerie}']");
                    nodoAModificar.ChildNodes[0].InnerText = cableElectrico.CantidadDeConductores.ToString();
                    nodoAModificar.ChildNodes[1].InnerText = cableElectrico.MarcaDelCable.ToString();
                    nodoAModificar.ChildNodes[2].InnerText = cableElectrico.Metros.ToString();
                    nodoAModificar.ChildNodes[3].InnerText = cableElectrico.SeccionDelCable.ToString();
                    nodoAModificar.ChildNodes[4].InnerText = cableElectrico.LibreDeHalogenos.ToString();
                    nodoAModificar.ChildNodes[5].InnerText = cableElectrico.FachadaOVivienda.ToString();
                    nodoAModificar.ChildNodes[6].InnerText = cableElectrico.FechaDeCompra.ToString("dd,MM,yyyy");
                    nodoAModificar.ChildNodes[7].InnerText = cableElectrico.FechaDeVencimiento.ToString("dd,MM,yyyy");
                    xmlDoc.Save(direccionXML);
                    return true;
                }
            }
            return false;
        }

        public List<CableElectrico> MostrarCablePorFechaDeCompraAscendente(DateTime fecha)
        {
            List<CableElectrico> listaRecuperada = new List<CableElectrico>();
            int numeroDeSerie;
            int cantidadDeConductores;
            String marcaDelCable;
            float metros;
            char seccionDelCable;
            bool libreDeHalogenos;
            bool fachadaOVivienda;
            DateTime fechaDeCompra;
            DateTime fechaDeVencimiento;
            CableElectrico cable;

            if (File.Exists(direccionXML))
            {
                this.xmlDoc.Load(direccionXML);
                XmlNodeList listaDeNodosDeCables = xmlDoc.SelectNodes($"*/Cable_electrico");

                foreach (XmlNode lista in listaDeNodosDeCables)
                {
                    if (DateTime.Parse(lista.ChildNodes[6].InnerText) >= fecha)
                    {
                        numeroDeSerie = int.Parse(lista.Attributes[0].Value);
                        cantidadDeConductores = int.Parse(lista.ChildNodes[0].InnerText);
                        marcaDelCable = lista.ChildNodes[1].InnerText;
                        metros = float.Parse(lista.ChildNodes[2].InnerText);
                        seccionDelCable = char.Parse(lista.ChildNodes[3].InnerText);
                        libreDeHalogenos = bool.Parse(lista.ChildNodes[4].InnerText);
                        fachadaOVivienda = bool.Parse(lista.ChildNodes[5].InnerText);
                        fechaDeCompra = DateTime.Parse(lista.ChildNodes[6].InnerText);
                        fechaDeVencimiento = DateTime.Parse(lista.ChildNodes[7].InnerText);

                        cable = new CableElectrico(numeroDeSerie, cantidadDeConductores, marcaDelCable, metros,
                                                   seccionDelCable, libreDeHalogenos, fachadaOVivienda, fechaDeCompra,
                                                   fechaDeVencimiento
                                                    );
                        listaRecuperada.Add(cable);
                    }
                }
            }
            return listaRecuperada;
        }

        public List<CableElectrico> MostrarPorCantidadDeMetros(int metros)
        {
            List<CableElectrico> listaRecuperada = new List<CableElectrico>();
            int numeroDeSerie;
            int cantidadDeConductores;
            String marcaDelCable;
            float metrosDeCable;
            char seccionDelCable;
            bool libreDeHalogenos;
            bool fachadaOVivienda;
            DateTime fechaDeCompra;
            DateTime fechaDeVencimiento;
            CableElectrico cable;

            if (File.Exists(direccionXML))
            {
                this.xmlDoc.Load(direccionXML);
                XmlNodeList listaDeNodosDeCables = xmlDoc.SelectNodes($"*/Cable_electrico");

                foreach (XmlNode lista in listaDeNodosDeCables)
                {

                    if (int.Parse(lista.ChildNodes[2].InnerText) >= metros)
                    {
                        numeroDeSerie = int.Parse(lista.Attributes[0].Value);
                        cantidadDeConductores = int.Parse(lista.ChildNodes[0].InnerText);
                        marcaDelCable = lista.ChildNodes[1].InnerText;
                        metrosDeCable = float.Parse(lista.ChildNodes[2].InnerText);
                        seccionDelCable = char.Parse(lista.ChildNodes[3].InnerText);
                        libreDeHalogenos = bool.Parse(lista.ChildNodes[4].InnerText);
                        fachadaOVivienda = bool.Parse(lista.ChildNodes[5].InnerText);
                        fechaDeCompra = DateTime.Parse(lista.ChildNodes[6].InnerText);
                        fechaDeVencimiento = DateTime.Parse(lista.ChildNodes[7].InnerText);

                        cable = new CableElectrico(numeroDeSerie, cantidadDeConductores, marcaDelCable, metrosDeCable,
                                                   seccionDelCable, libreDeHalogenos, fachadaOVivienda, fechaDeCompra,
                                                   fechaDeVencimiento
                                                    );
                        listaRecuperada.Add(cable);
                    }
                }
            }
            return listaRecuperada;
        }

        public CableElectrico MostrarPorNumeroDeSerie(int numeroDeSerie)
        {
            int numeroDeSerieDelCable;
            int cantidadDeConductores;
            String marcaDelCable;
            float metrosDeCable;
            char seccionDelCable;
            bool libreDeHalogenos;
            bool fachadaOVivienda;
            DateTime fechaDeCompra;
            DateTime fechaDeVencimiento;
            CableElectrico cable = new CableElectrico();

            if (File.Exists(direccionXML))
            {
                this.xmlDoc.Load(direccionXML);
                XmlNode cableRecuperado = xmlDoc.SelectSingleNode($"*/Cable_electrico[@Numero_de_serie='{numeroDeSerie}']");

                if (cableRecuperado != null)
                {
                    numeroDeSerieDelCable = int.Parse(cableRecuperado.Attributes[0].Value);
                    cantidadDeConductores = int.Parse(cableRecuperado.ChildNodes[0].InnerText);
                    marcaDelCable = cableRecuperado.ChildNodes[1].InnerText;
                    metrosDeCable = float.Parse(cableRecuperado.ChildNodes[2].InnerText);
                    seccionDelCable = char.Parse(cableRecuperado.ChildNodes[3].InnerText);
                    libreDeHalogenos = bool.Parse(cableRecuperado.ChildNodes[4].InnerText);
                    fachadaOVivienda = bool.Parse(cableRecuperado.ChildNodes[5].InnerText);
                    fechaDeCompra = DateTime.Parse(cableRecuperado.ChildNodes[6].InnerText);
                    fechaDeVencimiento = DateTime.Parse(cableRecuperado.ChildNodes[7].InnerText);

                    cable = new CableElectrico(numeroDeSerieDelCable, cantidadDeConductores, marcaDelCable, metrosDeCable,
                                                seccionDelCable, libreDeHalogenos, fachadaOVivienda, fechaDeCompra,
                                                fechaDeVencimiento
                                                );
                }
            }
            return cable;
        }

        public List<CableElectrico> MostrarTodoElCable()
        {
            return this.RecuperarListaDeCableDelXML();
        }
    }
}
