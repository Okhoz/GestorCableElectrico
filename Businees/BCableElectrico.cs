using Data;
using Model;
using System;
using System.Collections.Generic;

namespace Businees
{
    public class BCableElectrico
    {
        private DCableElectricoFicheros dCableElectricoFicheros;
        private DCableBDFichAleat dCableBDFichAleat;
        public BCableElectrico()
        {
            //this.dCableElectricoFicheros = new DCableElectricoFicheros();
            //this.dCableBDFichAleat=new DCableBDFichAleat();
        }
        public bool BorrarCable(int numeroDeSerie)
        {
            return this.dCableBDFichAleat.BorrarCable(numeroDeSerie);
            //return this.dCableElectricoFicheros.BorrarCable(numeroDeSerie);
        }
        public bool AñadirCable(CableElectrico cableElectrico)
        {
            return dCableBDFichAleat.AñadirCable(cableElectrico);
            //return dCableElectricoFicheros.AñadirCable( cableElectrico); 
        }

        public List<CableElectrico> MostrarTodoElCable()
        {
            List<CableElectrico> list = new List<CableElectrico>();
            return list = this.dCableBDFichAleat.MostrarTodoElCable();
            //List<CableElectrico> list = new List<CableElectrico>();
            //return list= this.dCableElectricoFicheros.MostrarTodoElCable();
        }

        public bool ModificarCable(CableElectrico cableElectrico)
        {
            return dCableBDFichAleat.ModificarCable(cableElectrico);
            //return  this.dCableElectricoFicheros.ModificarCable(cableElectrico);
        }

        public CableElectrico MostrarPorNumeroDeSerie(int numeroDeSerie)
        {
            //CableElectrico Cable = new CableElectrico();
            //return Cable=this.dCableElectricoFicheros.MostrarPorNumeroDeSerie(numeroDeSerie);
            return dCableBDFichAleat.MostrarPorNumeroDeSerie(numeroDeSerie);
        }

        public List<CableElectrico> MostrarCableEnBaseAUnCriterioDeFecha(DateTime fecha)
        {
            List<CableElectrico> cableElectricos = new List<CableElectrico>();
            return cableElectricos = this.dCableBDFichAleat.MostrarCablePorFechaDeCompraAscendente(fecha);
            //List<CableElectrico> cableElectricos=new List<CableElectrico>();
            //return cableElectricos= this.dCableElectricoFicheros.MostrarCablePorFechaDeCompraAscendente(fecha);
        }

        public List<CableElectrico> MostrarPorCantidadDeMetros(int metros)
        {
            List<CableElectrico> nuevaLista = this.dCableBDFichAleat.MostrarPorCantidadDeMetros(metros);
            return nuevaLista;
            //List<CableElectrico> nuevaLista = this.dCableElectricoFicheros.MostrarPorCantidadDeMetros(metros);
            //return nuevaLista;
        }

    }

}
