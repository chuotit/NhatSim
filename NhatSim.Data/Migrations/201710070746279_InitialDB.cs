namespace NhatSim.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgentLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgentID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        PriceFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceTo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Percent = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 255),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 255),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agents", t => t.AgentID, cascadeDelete: true)
                .Index(t => t.AgentID);
            
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Website = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Hotline = c.String(maxLength: 255),
                        Address = c.String(maxLength: 255),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 255),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 255),
                        Status = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FirstNumbers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 4, unicode: false),
                        NetworkId = c.Int(nullable: false),
                        FirstNumberName = c.String(nullable: false, maxLength: 255),
                        Description = c.String(storeType: "ntext"),
                        Alias = c.String(nullable: false, maxLength: 255, unicode: false),
                        HomeFlag = c.Boolean(nullable: false),
                        MetaDescription = c.String(maxLength: 255),
                        MetaKeyword = c.String(maxLength: 255),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 255),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 255),
                        Status = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SimNetworks", t => t.NetworkId, cascadeDelete: true)
                .Index(t => t.NetworkId);
            
            CreateTable(
                "dbo.SimNetworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Alias = c.String(nullable: false, maxLength: 255, unicode: false),
                        Image = c.String(),
                        Description = c.String(storeType: "ntext"),
                        HomeFlag = c.Boolean(nullable: false),
                        MetaDescription = c.String(maxLength: 255),
                        MetaKeyword = c.String(maxLength: 255),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 255),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 255),
                        Status = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SimStores",
                c => new
                    {
                        SimId = c.String(nullable: false, maxLength: 11, unicode: false),
                        SimName = c.String(nullable: false, maxLength: 25, unicode: false),
                        NetWorkId = c.Int(nullable: false),
                        AgentId = c.String(nullable: false, maxLength: 128),
                        Discount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SimId)
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .ForeignKey("dbo.SimNetworks", t => t.NetWorkId, cascadeDelete: true)
                .Index(t => t.NetWorkId)
                .Index(t => t.AgentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SimStores", "NetWorkId", "dbo.SimNetworks");
            DropForeignKey("dbo.SimStores", "AgentId", "dbo.Agents");
            DropForeignKey("dbo.FirstNumbers", "NetworkId", "dbo.SimNetworks");
            DropForeignKey("dbo.AgentLevels", "AgentID", "dbo.Agents");
            DropIndex("dbo.SimStores", new[] { "AgentId" });
            DropIndex("dbo.SimStores", new[] { "NetWorkId" });
            DropIndex("dbo.FirstNumbers", new[] { "NetworkId" });
            DropIndex("dbo.AgentLevels", new[] { "AgentID" });
            DropTable("dbo.SimStores");
            DropTable("dbo.SimNetworks");
            DropTable("dbo.FirstNumbers");
            DropTable("dbo.Agents");
            DropTable("dbo.AgentLevels");
        }
    }
}
