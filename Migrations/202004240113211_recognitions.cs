namespace mis4200_team15.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recognitions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recognitions", "ID", c => c.Int(nullable: false));
            DropColumn("dbo.Recognitions", "userDetailsID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recognitions", "userDetailsID", c => c.Int(nullable: false));
            DropColumn("dbo.Recognitions", "ID");
        }
    }
}
