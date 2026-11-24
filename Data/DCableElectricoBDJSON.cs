using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Data
{
    public class DCableElectricoBDJSON : ICableElectricoFichero
    {
        string nombreFicheroJSON = "..\\..\\..\\AlamacenDeCableJSON";


        private FileStream fichero;
        private StreamReader sr;
        private StreamWriter sw;
        public DCableElectricoBDJSON()
        {
            this.CrearFichero();
        }

        private bool CrearFichero()
        {
            if (File.Exists(nombreFicheroJSON) == false)
            {
                this.fichero = new FileStream(nombreFicheroJSON, FileMode.Create, FileAccess.Write);
                this.fichero.Close();
                return true;
            }
            return false;
        }

        private List<CableElectrico> RecuperarFichero()
        {
            List<CableElectrico> listaDeCable;

            if (File.Exists(nombreFicheroJSON) == true)
            {
                listaDeCable = JsonConvert.DeserializeObject<List<CableElectrico>>(File.ReadAllText(nombreFicheroJSON));
                if (listaDeCable != null)
                {
                    return listaDeCable;
                }
            }

            return listaDeCable = new List<CableElectrico>();
        }

        public bool AñadirCable(CableElectrico cableElectrico)
        {
            if (File.Exists(nombreFicheroJSON) == true)
            {
                List<CableElectrico> cables = this.RecuperarFichero();

                fichero = new FileStream(nombreFicheroJSON, FileMode.Create, FileAccess.Write);
                this.sw = new StreamWriter(fichero);
                foreach (CableElectrico cable in cables)
                {
                    if (cable.NumeroDeSerie == cableElectrico.NumeroDeSerie)
                    {
                        sw.Write(JsonConvert.SerializeObject(cables));
                        sw.Close();
                        fichero.Close();
                        return false;
                    }
                }
                if (cableElectrico.ToString().Trim() != "0  |  0  |    |  0  |  -  |  No  |  No  |  01-01-1000  |  01-01-1000".Trim())
                {
                    cables.Add(cableElectrico);
                    sw.Write(JsonConvert.SerializeObject(cables));
                    sw.Close();
                    fichero.Close();
                    return true;
                }
            }
            sw.Close();
            fichero.Close();
            return false;
        }

        public bool BorrarCable(int numeroDeSerie)
        {
            List<CableElectrico> listaDeCable = this.RecuperarFichero();
            bool borrar = false;

            if (File.Exists(nombreFicheroJSON) == true && listaDeCable.Exists(cable => cable.NumeroDeSerie == numeroDeSerie))
            {
                FileStream fichero = new FileStream(nombreFicheroJSON, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fichero);

                foreach (CableElectrico cable in listaDeCable)
                {
                    if (cable.NumeroDeSerie == numeroDeSerie)
                    {
                        if (cable.ToString().Trim() != "0  |  0  |    |  0  |  -  |  No  |  No  |  01-01-1000  |  01-01-1000".Trim())
                        {
                            listaDeCable.Remove(cable);
                            sw.Write(JsonConvert.SerializeObject(listaDeCable));
                            sw.Close();
                            fichero.Close();
                            borrar = true;
                            return borrar;
                        }
                    }
                }
                sw.Close();
                fichero.Close();

            }
            return borrar;
        }

        public List<CableElectrico> MostrarPorCantidadDeMetros(int metros)
        {
            List<CableElectrico> cableElectrico = this.RecuperarFichero();
            List<CableElectrico> nuevaLista = new List<CableElectrico>();

            if (File.Exists(nombreFicheroJSON))
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

        public List<CableElectrico> MostrarTodoElCable()
        {
            List<CableElectrico> listaDeCable = this.RecuperarFichero();
            return listaDeCable;
        }

        public CableElectrico MostrarPorNumeroDeSerie(int numeroDeSerie)
        {
            CableElectrico cableElectrico = new CableElectrico();

            if (File.Exists(nombreFicheroJSON))
            {
                List<CableElectrico> listaDecable = this.RecuperarFichero();

                return cableElectrico = listaDecable.Find(cable => cable.NumeroDeSerie == numeroDeSerie);
            }
            return cableElectrico;
        }

        public bool ModificarCable(CableElectrico cable)
        {
            List<CableElectrico> listaDeCable = this.RecuperarFichero();
            this.BorrarCable(cable.NumeroDeSerie);
            bool añadido = false;
            int cont = 0;
            foreach (CableElectrico cablecito in listaDeCable)
            {
                if (cablecito.NumeroDeSerie == cable.NumeroDeSerie && cable.ToString().Trim() != "0  |  0  |    |  0  |  -  |  No  |  No  |  01-01-1000  |  01-01-1000".Trim())
                {
                    FileStream fichero = new FileStream(nombreFicheroJSON, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fichero);
                    listaDeCable[cont] = cable;
                    sw.Write(JsonConvert.SerializeObject(listaDeCable));
                    sw.Close();
                    fichero.Close();
                    añadido = true;
                    return añadido;

                }
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
