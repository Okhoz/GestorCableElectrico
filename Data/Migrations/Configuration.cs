namespace Data.Migrations
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.CablesElectricosDbContext>
    {
        public Configuration()
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Data");
            basePath = Path.GetFullPath(basePath);
            AppDomain.CurrentDomain.SetData("DataDirectory", basePath);

            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.CablesElectricosDbContext context)
        {
            IList<CableElectrico> listaDeCable = new List<CableElectrico>();

            listaDeCable.Add(new CableElectrico(
                                numeroDeSerie: 1001,
                                cantidadDeConductores: 3,
                                marcaDelCable: "Prysmian",
                                metros: 50.5f,
                                seccionDelCable: 'A',
                                libreDeHalogenos: true,
                                fachadaOVivienda: false,
                                fechaDeComprea: new DateTime(2024, 1, 15),
                                fechaDeVencimiento: new DateTime(2029, 1, 15)
                            ));

            listaDeCable.Add(new CableElectrico(
                    numeroDeSerie: 1002,
                    cantidadDeConductores: 6,
                    marcaDelCable: "Siemens",
                    metros: 90.5f,
                    seccionDelCable: 'A',
                    libreDeHalogenos: true,
                    fachadaOVivienda: false,
                    fechaDeComprea: new DateTime(2024, 1, 15),
                    fechaDeVencimiento: new DateTime(2029, 1, 15)
                ));

            context.CablesElectricos.AddRange(listaDeCable);

            base.Seed(context);
        }
    }
}
