namespace BoatRental.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationBoatRentalV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BoatNumber = c.Int(nullable: false),
                        BoatType = c.Int(nullable: false),
                        Booked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingNumber = c.Int(nullable: false),
                        BoatNumber = c.Int(nullable: false),
                        PersonalNumber = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                        FilingDate = c.DateTime(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rentals");
            DropTable("dbo.Boats");
        }
    }
}
