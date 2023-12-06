namespace Diagram4Tables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTablesName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DiagaramGroups", newName: "SETUP_MTS_GROUP");
            RenameTable(name: "dbo.Diagram
                ", newName: "SETUP_MTS_GROUP_QUESTION");
            RenameTable(name: "dbo.DiagramProblems", newName: "SETUP_MTS_PROPLEM");
            RenameTable(name: "dbo.DiagramQuestions", newName: "SETUP_MTS_QUESTION");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SETUP_MTS_QUESTION", newName: "DiagramQuestions");
            RenameTable(name: "dbo.SETUP_MTS_PROPLEM", newName: "DiagramProblems");
            RenameTable(name: "dbo.SETUP_MTS_GROUP_QUESTION", newName: "DiagramGroupQuestions");
            RenameTable(name: "dbo.SETUP_MTS_GROUP", newName: "DiagaramGroups");
        }
    }
}
