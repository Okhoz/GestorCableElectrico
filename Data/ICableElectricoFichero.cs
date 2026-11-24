using Model;
using System;
using System.Collections.Generic;

namespace Data
{
    internal interface ICableElectricoFichero
    {
        bool BorrarCable(int numeroDeSerie);

        bool AñadirCable(CableElectrico cableElectrico);

        List<CableElectrico> MostrarPorCantidadDeMetros(int metros);
        List<CableElectrico> MostrarTodoElCable();

        CableElectrico MostrarPorNumeroDeSerie(int numeroDeSerie);

        bool ModificarCable(CableElectrico cable);

        List<CableElectrico> MostrarCablePorFechaDeCompraAscendente(DateTime fecha);


    }
}
