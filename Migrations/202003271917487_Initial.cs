namespace mis4200_team15.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.userDetails",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Email = c.String(),
                        firstName = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Office = c.String(),
                        Position = c.String(),
                        hireDate = c.DateTime(nullable: false),
                        photo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.userDetails");
        }
    }
}
