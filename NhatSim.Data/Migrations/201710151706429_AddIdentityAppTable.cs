namespace NhatSim.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentityAppTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AppRoleGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GroupId, t.RoleId })
                .ForeignKey("dbo.AppGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AppRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AppUserGroups",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.AppGroups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AppUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Functions",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        URL = c.String(nullable: false, maxLength: 256),
                        DisplayOrder = c.Int(nullable: false),
                        ParentId = c.String(maxLength: 50, unicode: false),
                        Status = c.Boolean(nullable: false),
                        IconCss = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Functions", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleId = c.String(maxLength: 128),
                        FunctionId = c.String(maxLength: 50, unicode: false),
                        CanCreate = c.Boolean(nullable: false),
                        CanRead = c.Boolean(nullable: false),
                        CanUpdate = c.Boolean(nullable: false),
                        CanDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AppRoles", t => t.RoleId)
                .ForeignKey("dbo.Functions", t => t.FunctionId)
                .Index(t => t.RoleId)
                .Index(t => t.FunctionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permissions", "FunctionId", "dbo.Functions");
            DropForeignKey("dbo.Permissions", "RoleId", "dbo.AppRoles");
            DropForeignKey("dbo.Functions", "ParentId", "dbo.Functions");
            DropForeignKey("dbo.AppUserGroups", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.AppUserGroups", "GroupId", "dbo.AppGroups");
            DropForeignKey("dbo.AppRoleGroups", "RoleId", "dbo.AppRoles");
            DropForeignKey("dbo.AppRoleGroups", "GroupId", "dbo.AppGroups");
            DropIndex("dbo.Permissions", new[] { "FunctionId" });
            DropIndex("dbo.Permissions", new[] { "RoleId" });
            DropIndex("dbo.Functions", new[] { "ParentId" });
            DropIndex("dbo.AppUserGroups", new[] { "GroupId" });
            DropIndex("dbo.AppUserGroups", new[] { "UserId" });
            DropIndex("dbo.AppRoleGroups", new[] { "RoleId" });
            DropIndex("dbo.AppRoleGroups", new[] { "GroupId" });
            DropTable("dbo.Permissions");
            DropTable("dbo.Functions");
            DropTable("dbo.AppUserGroups");
            DropTable("dbo.AppRoleGroups");
            DropTable("dbo.AppGroups");
        }
    }
}
