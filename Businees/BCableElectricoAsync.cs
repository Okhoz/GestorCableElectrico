using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Businees
{
    public class BCableElectricoAsync
    {
        private DCableElectricoFicheros dCableElectricoFicheros;
        private DCableBDFichAleat dCableBDFichAleat;
        private DCableElectricoXML DCableElectricoXML;
        private DCableElectricoBDJSON dCableElectricoBDJSON;
        private DCableElectricoBDSQLServer dCableElectricoBDSQLServer;
        private DClienteApiRest clienteApiRest;
        private DCableElectricoBDEF dCableElectricoBDEF;


        public BCableElectricoAsync()
        {
            //this.dCableElectricoFicheros = new DCableElectricoFicheros();
            //this.dCableBDFichAleat = new DCableBDFichAleat();
            //this.dCableElectricoXML=new DCableElectricoXML();
            //this.dCableElectricoBDJSON = new DCableElectricoBDJSON();
            //this.dCableElectricoBDSQLServer = new DCableElectricoBDSQLServer();
            this.clienteApiRest = new DClienteApiRest();
            this.dCableElectricoBDEF = new DCableElectricoBDEF();

        }

        public Task<bool> BorrarCable(int numeroDeSerie)
        {
            //return this.dCableElectricoFicheros.BorrarCable(numeroDeSerie);
            //this.dCableBDFichAleat.BorrarCable(numeroDeSerie)
            Task<bool> borrarCable = new Task<bool>(() => this.dCableElectricoBDEF.BorrarCable(numeroDeSerie));
            borrarCable.Start();
            return borrarCable;
        }
        public Task<bool> AñadirCable(CableElectrico cableElectrico)
        {
            //return dCableBDFichAleat.AñadirCable(cableElectrico);
            //return dCableElectricoFicheros.AñadirCable( cableElectrico); 
            Task<bool> añadirCable = new Task<bool>(() => (dCableElectricoBDEF.AñadirCable(cableElectrico)));
            añadirCable.Start();
            return añadirCable;
        }

        public Task<List<CableElectrico>> MostrarTodoElCable()
        {
            //List<CableElectrico> list = new List<CableElectrico>();
            //return list = this.dCableBDFichAleat.MostrarTodoElCable();
            //List<CableElectrico> list = new List<CableElectrico>();
            //return list= this.dCableElectricoFicheros.MostrarTodoElCable();
            Task<List<CableElectrico>> list = new Task<List<CableElectrico>>(() => this.dCableElectricoBDEF.MostrarTodoElCable());
            list.Start();
            return list;
        }

        public Task<bool> ModificarCable(CableElectrico cableElectrico)
        {
            //return dCableBDFichAleat.ModificarCable(cableElectrico);
            //return  this.dCableElectricoFicheros.ModificarCable(cableElectrico);
            Task<bool> modficarCable = new Task<bool>(() => this.dCableElectricoBDEF.ModificarCable(cableElectrico));
            modficarCable.Start();
            return modficarCable;
        }

        public Task<CableElectrico> MostrarPorNumeroDeSerie(int numeroDeSerie)
        {
            //CableElectrico Cable = new CableElectrico();
            //return Cable=this.dCableElectricoFicheros.MostrarPorNumeroDeSerie(numeroDeSerie);
            Task<CableElectrico> mostrarPorNumeroDeSerie = new Task<CableElectrico>(() => dCableElectricoBDEF.MostrarPorNumeroDeSerie(numeroDeSerie));
            mostrarPorNumeroDeSerie.Start();
            return mostrarPorNumeroDeSerie;
        }

        public Task<List<CableElectrico>> MostrarCableEnBaseAUnCriterioDeFecha(DateTime fecha)
        {
            //List<CableElectrico> cableElectricos = new List<CableElectrico>();
            //return cableElectricos = this.dCableBDFichAleat.MostrarCablePorFechaDeCompraAscendente(fecha);
            //List<CableElectrico> cableElectricos=new List<CableElectrico>();
            //return cableElectricos= this.dCableElectricoFicheros.MostrarCablePorFechaDeCompraAscendente(fecha);
            Task<List<CableElectrico>> cableElectricos = new Task<List<CableElectrico>>(() => this.dCableElectricoBDEF.MostrarCablePorFechaDeCompraAscendente(fecha));
            cableElectricos.Start();
            return cableElectricos;
        }

        public Task<List<CableElectrico>> MostrarPorCantidadDeMetros(int metros)
        {
            //List<CableElectrico> nuevaLista = this.dCableBDFichAleat.MostrarPorCantidadDeMetros(metros);
            //return nuevaLista;
            //List<CableElectrico> nuevaLista = this.dCableElectricoFicheros.MostrarPorCantidadDeMetros(metros);
            //return nuevaLista;
            Task<List<CableElectrico>> nuevaLista = new Task<List<CableElectrico>>(() => this.dCableElectricoBDEF.MostrarPorCantidadDeMetros(metros));
            nuevaLista.Start();
            return nuevaLista;
        }

        public Task<String> MostrarProcedimientoAlmacenado(string parametro)
        {
            Task<String> texto = new Task<String>(() => dCableElectricoBDSQLServer.procedimientoAlmacenado(parametro));
            texto.Start();
            return texto;
        }

    }
}
