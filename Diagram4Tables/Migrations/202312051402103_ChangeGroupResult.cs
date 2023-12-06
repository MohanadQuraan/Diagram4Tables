namespace Diagram4Tables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGroupResult : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DiagaramGroups", "GroupYesResult", c => c.String());
            AlterColumn("dbo.DiagaramGroups", "GroupNoResult", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DiagaramGroups", "GroupNoResult", c => c.Long());
            AlterColumn("dbo.DiagaramGroups", "GroupYesResult", c => c.Long());
        }
    }
}
