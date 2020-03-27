namespace mis4200_team15.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationscoreValuesUserValues : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Locations",
                c => new
                    {
                        locationsID = c.Int(nullable: false, identity: true),
                        city = c.String(),
                        state = c.String(),
                    })
                .PrimaryKey(t => t.locationsID);
            
            AddColumn("dbo.userDetails", "Locations_locationsID", c => c.Int());
            CreateIndex("dbo.userDetails", "Locations_locationsID");
            AddForeignKey("dbo.userDetails", "Locations_locationsID", "dbo.Locations", "locationsID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.userDetails", "Locations_locationsID", "dbo.Locations");
            DropForeignKey("dbo.UserValues", "UserDetails_ID", "dbo.userDetails");
            DropForeignKey("dbo.UserValues", "coreValues_coreValuesID", "dbo.coreValues");
            DropIndex("dbo.userDetails", new[] { "Locations_locationsID" });
            DropIndex("dbo.UserValues", new[] { "UserDetails_ID" });
            DropIndex("dbo.UserValues", new[] { "coreValues_coreValuesID" });
            DropColumn("dbo.userDetails", "Locations_locationsID");
            DropTable("dbo.Locations");
            DropTable("dbo.UserValues");
            DropTable("dbo.coreValues");
        }
    }
}
