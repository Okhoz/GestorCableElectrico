using Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace Data
{
    public class DClienteApiRest : ICableElectricoFichero
    {


        public bool AñadirCable(CableElectrico cableElectrico)
        {
            string url = "https://699c7030110b5b738cc2b2f4.mockapi.io/api/cablesElectricos/cablesElectricos";
            CableElectrico cable = new CableElectrico(cableElectrico.CantidadDeConductores, cableElectrico.MarcaDelCable, cableElectrico.Metros, cableElectrico.SeccionDelCable, cableElectrico.LibreDeHalogenos, cableElectrico.FachadaOVivienda, cableElectrico.FechaDeCompra, cableElectrico.FechaDeVencimiento);
            CableElectrico error = new CableElectrico();
            if (error.ToString().Equals(cable.ToString()))
            {
                return false;
            }
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.PostAsJsonAsync(url, cable).Result)
            using (HttpContent content = response.Content)
            {
                if (HttpStatusCode.Created == response.StatusCode)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BorrarCable(int numeroDeSerie)
        {

            string url = "https://699c7030110b5b738cc2b2f4.mockapi.io/api/cablesElectricos/cablesElectricos";
            url += "/" + numeroDeSerie;

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.DeleteAsync(url).Result)
            using (HttpContent content = response.Content)
            {
                if (HttpStatusCode.OK == response.StatusCode)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ModificarCable(CableElectrico cableElectrico)
        {
            string url = "https://699c7030110b5b738cc2b2f4.mockapi.io/api/cablesElectricos/cablesElectricos";
            url += "/" + cableElectrico.NumeroDeSerie;

            CableElectrico cable = new CableElectrico(cableElectrico.CantidadDeConductores, cableElectrico.MarcaDelCable, cableElectrico.Metros, cableElectrico.SeccionDelCable, cableElectrico.LibreDeHalogenos, cableElectrico.FachadaOVivienda, cableElectrico.FechaDeCompra, cableElectrico.FechaDeVencimiento);

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.PutAsJsonAsync(url, cable).Result)
            using (HttpContent content = response.Content)
            {
                if (HttpStatusCode.OK == response.StatusCode)
                {
                    return true;
                }
            }

            return false;
        }

        public List<CableElectrico> MostrarCablePorFechaDeCompraAscendente(DateTime fecha)
        {
            string url = "https://699c7030110b5b738cc2b2f4.mockapi.io/api/cablesElectricos/cablesElectricos";
            List<CableElectrico> listaDeCable = new List<CableElectrico>();
            List<CableElectrico> listaFiltrada = new List<CableElectrico>();

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.GetAsync(url).Result)
            using (HttpContent conten = response.Content)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    listaDeCable = client.GetFromJsonAsync<List<CableElectrico>>(url).Result;
                    foreach (CableElectrico cable in listaDeCable)
                    {
                        if (cable.FechaDeCompra >= fecha)
                        {
                            listaFiltrada.Add(cable);
                        }
                    }
                }
            }

            return listaFiltrada;
        }

        public List<CableElectrico> MostrarPorCantidadDeMetros(int metros)
        {
            string url = "https://699c7030110b5b738cc2b2f4.mockapi.io/api/cablesElectricos/cablesElectricos";
            List<CableElectrico> listaDeCable = new List<CableElectrico>();
            List<CableElectrico> listaFiltrada = new List<CableElectrico>();

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.GetAsync(url).Result)
            using (HttpContent conten = response.Content)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    listaDeCable = client.GetFromJsonAsync<List<CableElectrico>>(url).Result;
                    foreach (CableElectrico cable in listaDeCable)
                    {
                        if (cable.Metros >= metros)
                        {
                            listaFiltrada.Add(cable);
                        }
                    }
                }
            }

            return listaFiltrada;
        }

        public CableElectrico MostrarPorNumeroDeSerie(int numeroDeSerie)
        {
            string url = "https://699c7030110b5b738cc2b2f4.mockapi.io/api/cablesElectricos/cablesElectricos";
            url += "/" + numeroDeSerie;
            CableElectrico cable = new CableElectrico();
            List<CableElectrico> listaDeCable = new List<CableElectrico>();

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.GetAsync(url).Result)
            using (HttpContent conten = response.Content)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    cable = client.GetFromJsonAsync<CableElectrico>(url).Result;
                }
            }

            return cable;
        }

        public List<CableElectrico> MostrarTodoElCable()
        {
            string url = "https://699c7030110b5b738cc2b2f4.mockapi.io/api/cablesElectricos/cablesElectricos";
            List<CableElectrico> listaDeCable = new List<CableElectrico>();

            using (HttpClient client = new HttpClient())
            {
                listaDeCable = client.GetFromJsonAsync<List<CableElectrico>>(url).Result;
            }

            return listaDeCable;
        }
    }
}
