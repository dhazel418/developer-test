namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewingStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viewings", "ViewingStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viewings", "ViewingStatus");
        }
    }
}
