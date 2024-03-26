namespace EmployeeManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Countries : DbMigration
    {

        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Code = c.String(),
                    Name = c.String(),
                    CountryId = c.String(nullable: false), // Change the type to int
        })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true) // Specify the foreign key
                .Index(t => t.CountryId);

            CreateTable(
                "dbo.Countries",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Code = c.String(),
                    Name = c.String(),
                    CreatedById = c.String(),
                    CreatedOn = c.DateTime(nullable: false),
                    ModifieById = c.String(),
                    ModifiedOn = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }



    }
}
