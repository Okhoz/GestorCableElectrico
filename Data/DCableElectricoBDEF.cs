using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class DCableElectricoBDEF : ICableElectricoFichero
    {

        CablesElectricosDbContext context;

        public DCableElectricoBDEF()
        {
            context = new CablesElectricosDbContext();
        }

        public bool AñadirCable(CableElectrico cableElectrico)
        {
            int filas = 0;
            try
            {
                context.CablesElectricos.Add(cableElectrico);
                filas = context.SaveChanges();
                if (filas > 0)
                {
                    return true;
                }

                return false;
            }catch (Exception ex)
            {
                return false;
            }

        }

        public bool BorrarCable(int numeroDeSerie)
        {
            CableElectrico cable = new CableElectrico();
            try
            {
                if (context.CablesElectricos.Find(numeroDeSerie) != null)
                {
                    cable = context.CablesElectricos.Find(numeroDeSerie);
                    context.CablesElectricos.Remove(cable);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }catch(Exception ex) 
            {
                return false;
            }

        }

        public bool ModificarCable(CableElectrico cable)
        {
            CableElectrico cableBuscado = new CableElectrico();
            try
            {
                if (context.CablesElectricos.Find(cable.NumeroDeSerie) != null)
                {
                    cableBuscado = context.CablesElectricos.Find(cable.NumeroDeSerie);

                    cableBuscado.CantidadDeConductores = cable.CantidadDeConductores;
                    cableBuscado.MarcaDelCable = cable.MarcaDelCable;
                    cableBuscado.Metros = cable.Metros;
                    cableBuscado.SeccionDelCable = cable.SeccionDelCable;
                    cableBuscado.LibreDeHalogenos = cable.LibreDeHalogenos;
                    cableBuscado.FachadaOVivienda = cable.FachadaOVivienda;
                    cableBuscado.FechaDeCompra = cable.FechaDeCompra;
                    cableBuscado.FechaDeVencimiento = cable.FechaDeVencimiento;

                    context.SaveChanges();
                    return true;
                }
                return false;
            }catch (Exception ex) 
            {
                return false; 
            }

        }

        public List<CableElectrico> MostrarCablePorFechaDeCompraAscendente(DateTime fecha)
        {

            List<CableElectrico> listaDeCables = null;
            try
            {
                listaDeCables = context.CablesElectricos
                .Where(c => c.FechaDeCompra >= fecha)
                .OrderBy(c => c.FechaDeCompra)
                .ToList();

                if (listaDeCables != null)
                {
                    return listaDeCables;
                }
                return new List<CableElectrico>();

            }catch (Exception ex)
            {
                return new List<CableElectrico>();
            }
        }

        public List<CableElectrico> MostrarPorCantidadDeMetros(int metros)
        {
            List<CableElectrico> listaDeCables = null;

            try
            {
                listaDeCables = context.CablesElectricos
                                .Where(c => c.Metros >= metros)
                                .OrderBy(c => c.FechaDeCompra)
                                .ToList();

                if (listaDeCables != null)
                {
                    return listaDeCables;
                }

                return new List<CableElectrico>();
            }catch (Exception ex)
            {
                return new List<CableElectrico>();
            }

        }

        public CableElectrico MostrarPorNumeroDeSerie(int numeroDeSerie)
        {
            CableElectrico cableElectrico = null;

            try
            {
                cableElectrico = context.CablesElectricos
                .Where(c => c.NumeroDeSerie >= numeroDeSerie).First();

                if (cableElectrico != null)
                {
                    return cableElectrico;
                }
                return new CableElectrico();

            }
            catch (Exception ex)
            {
                return new CableElectrico();
            }
        }

        public List<CableElectrico> MostrarTodoElCable()
        {
            try
            {
                if (context.CablesElectricos.ToList() != null)
                {
                    return context.CablesElectricos.ToList();

                }
                return new List<CableElectrico>();

            }
            catch (Exception ex)
            {
                return new List<CableElectrico>();
            }

        }
    }
}
