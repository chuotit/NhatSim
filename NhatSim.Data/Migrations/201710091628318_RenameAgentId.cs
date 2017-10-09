namespace NhatSim.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAgentId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AgentLevels", new[] { "AgentID" });
            CreateIndex("dbo.AgentLevels", "AgentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AgentLevels", new[] { "AgentId" });
            CreateIndex("dbo.AgentLevels", "AgentID");
        }
    }
}
