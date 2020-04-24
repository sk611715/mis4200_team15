namespace mis4200_team15.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recog : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recognitions", "userDetails_ID", "dbo.userDetails");
            DropIndex("dbo.Recognitions", new[] { "userDetails_ID" });
            DropColumn("dbo.Recognitions", "ID");
            RenameColumn(table: "dbo.Recognitions", name: "userDetails_ID", newName: "ID");
            AlterColumn("dbo.Recognitions", "ID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Recognitions", "ID", c => c.Guid(nullable: false));
            CreateIndex("dbo.Recognitions", "ID");
            AddForeignKey("dbo.Recognitions", "ID", "dbo.userDetails", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recognitions", "ID", "dbo.userDetails");
            DropIndex("dbo.Recognitions", new[] { "ID" });
            AlterColumn("dbo.Recognitions", "ID", c => c.Guid());
            AlterColumn("dbo.Recognitions", "ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Recognitions", name: "ID", newName: "userDetails_ID");
            AddColumn("dbo.Recognitions", "ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Recognitions", "userDetails_ID");
            AddForeignKey("dbo.Recognitions", "userDetails_ID", "dbo.userDetails", "ID");
        }
    }
}
