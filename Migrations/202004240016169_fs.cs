namespace mis4200_team15.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.businessUnits",
                c => new
                    {
                        businessUnitsID = c.Int(nullable: false, identity: true),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.businessUnitsID);
            
            CreateTable(
                "dbo.userDetails",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Email = c.String(nullable: false),
                        firstName = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        hireDate = c.DateTime(nullable: false),
                        locationsID = c.Int(nullable: false),
                        businessUnitsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.businessUnits", t => t.businessUnitsID, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.locationsID, cascadeDelete: true)
                .Index(t => t.locationsID)
                .Index(t => t.businessUnitsID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        locationsID = c.Int(nullable: false, identity: true),
                        city = c.String(),
                        state = c.String(),
                    })
                .PrimaryKey(t => t.locationsID);
            
            CreateTable(
                "dbo.coreValues",
                c => new
                    {
                        coreValuesID = c.Int(nullable: false, identity: true),
                        valueName = c.String(),
                        description = c.String(),
                        points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.coreValuesID);
            
            CreateTable(
                "dbo.UserValues",
                c => new
                    {
                        userValueID = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        valueID = c.Int(nullable: false),
                        dateAssigned = c.DateTime(nullable: false),
                        coreValues_coreValuesID = c.Int(),
                        UserDetails_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.userValueID)
                .ForeignKey("dbo.coreValues", t => t.coreValues_coreValuesID)
                .ForeignKey("dbo.userDetails", t => t.UserDetails_ID)
                .Index(t => t.coreValues_coreValuesID)
                .Index(t => t.UserDetails_ID);
            
            CreateTable(
                "dbo.Recognitions",
                c => new
                    {
                        recognitionsID = c.Int(nullable: false, identity: true),
                        userDetailsID = c.Int(nullable: false),
                        recognitionDate = c.DateTime(nullable: false),
                        coreValuesID = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        userDetails_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.recognitionsID)
                .ForeignKey("dbo.coreValues", t => t.coreValuesID, cascadeDelete: true)
                .ForeignKey("dbo.userDetails", t => t.userDetails_ID)
                .Index(t => t.coreValuesID)
                .Index(t => t.userDetails_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recognitions", "userDetails_ID", "dbo.userDetails");
            DropForeignKey("dbo.Recognitions", "coreValuesID", "dbo.coreValues");
            DropForeignKey("dbo.UserValues", "UserDetails_ID", "dbo.userDetails");
            DropForeignKey("dbo.UserValues", "coreValues_coreValuesID", "dbo.coreValues");
            DropForeignKey("dbo.userDetails", "locationsID", "dbo.Locations");
            DropForeignKey("dbo.userDetails", "businessUnitsID", "dbo.businessUnits");
            DropIndex("dbo.Recognitions", new[] { "userDetails_ID" });
            DropIndex("dbo.Recognitions", new[] { "coreValuesID" });
            DropIndex("dbo.UserValues", new[] { "UserDetails_ID" });
            DropIndex("dbo.UserValues", new[] { "coreValues_coreValuesID" });
            DropIndex("dbo.userDetails", new[] { "businessUnitsID" });
            DropIndex("dbo.userDetails", new[] { "locationsID" });
            DropTable("dbo.Recognitions");
            DropTable("dbo.UserValues");
            DropTable("dbo.coreValues");
            DropTable("dbo.Locations");
            DropTable("dbo.userDetails");
            DropTable("dbo.businessUnits");
        }
    }
}
