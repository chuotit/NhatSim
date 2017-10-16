namespace NhatSim.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableIdentityName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IdentityRoles", newName: "AppRoles");
            RenameTable(name: "dbo.IdentityUserRoles", newName: "AppUserRoles");
            RenameTable(name: "dbo.IdentityUserClaims", newName: "AppUserClaims");
            RenameTable(name: "dbo.IdentityUserLogins", newName: "AppUserLogins");
            RenameColumn(table: "dbo.AppUserClaims", name: "AppUser_Id", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.AppUserLogins", name: "AppUser_Id", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.AppUserRoles", name: "AppUser_Id", newName: "IdentityUser_Id");
            RenameIndex(table: "dbo.AppUserRoles", name: "IX_AppUser_Id", newName: "IX_IdentityUser_Id");
            RenameIndex(table: "dbo.AppUserClaims", name: "IX_AppUser_Id", newName: "IX_IdentityUser_Id");
            RenameIndex(table: "dbo.AppUserLogins", name: "IX_AppUser_Id", newName: "IX_IdentityUser_Id");
            DropPrimaryKey("dbo.AppUserClaims");
            AddColumn("dbo.AppUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AppUserClaims", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.AppUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.AppUserClaims", "UserId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AppUserClaims");
            AlterColumn("dbo.AppUserClaims", "UserId", c => c.String());
            AlterColumn("dbo.AppUserClaims", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.AppUsers", "Discriminator");
            AddPrimaryKey("dbo.AppUserClaims", "Id");
            RenameIndex(table: "dbo.AppUserLogins", name: "IX_IdentityUser_Id", newName: "IX_AppUser_Id");
            RenameIndex(table: "dbo.AppUserClaims", name: "IX_IdentityUser_Id", newName: "IX_AppUser_Id");
            RenameIndex(table: "dbo.AppUserRoles", name: "IX_IdentityUser_Id", newName: "IX_AppUser_Id");
            RenameColumn(table: "dbo.AppUserRoles", name: "IdentityUser_Id", newName: "AppUser_Id");
            RenameColumn(table: "dbo.AppUserLogins", name: "IdentityUser_Id", newName: "AppUser_Id");
            RenameColumn(table: "dbo.AppUserClaims", name: "IdentityUser_Id", newName: "AppUser_Id");
            RenameTable(name: "dbo.AppUserLogins", newName: "IdentityUserLogins");
            RenameTable(name: "dbo.AppUserClaims", newName: "IdentityUserClaims");
            RenameTable(name: "dbo.AppUserRoles", newName: "IdentityUserRoles");
            RenameTable(name: "dbo.AppRoles", newName: "IdentityRoles");
        }
    }
}
