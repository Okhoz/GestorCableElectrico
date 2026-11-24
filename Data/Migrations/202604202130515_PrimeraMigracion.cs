namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CablesElectricos",
                c => new
                    {
                        NumeroDeSerie = c.Int(nullable: false, identity: true),
                        CantidadDeConductores = c.Int(nullable: false),
                        MarcaDelCable = c.String(),
                        Metros = c.Single(nullable: false),
                        SeccionDelCableAxu = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        LibreDeHalogenos = c.Boolean(nullable: false),
                        FachadaOVivienda = c.Boolean(nullable: false),
                        FechaDeCompra = c.DateTime(nullable: false),
                        FechaDeVencimiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NumeroDeSerie);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CablesElectricos");
        }
    }
}
