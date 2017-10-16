namespace NhatSim.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesAppTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppRoles", "Description", c => c.String());
            AddColumn("dbo.AppRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppRoles", "Discriminator");
            DropColumn("dbo.AppRoles", "Description");
        }
    }
}
