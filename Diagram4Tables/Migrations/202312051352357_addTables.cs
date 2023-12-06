namespace Diagram4Tables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiagaramGroups",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        ProblemID = c.String(),
                        GroupName = c.String(),
                        GroupDescription = c.String(),
                        GroupOrder = c.Int(),
                        GroupYesResult = c.Long(),
                        GroupNoResult = c.Long(),
                        CREATED_BY = c.String(),
                        CREATION_DATETIME = c.DateTime(),
                        DELETED_BY = c.String(),
                        DELETE_DATETIME = c.DateTime(),
                        UPDATED_BY = c.String(),
                        UPDATE_DATETIME = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DiagramGroupQuestions",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        GroupID = c.String(),
                        QuestionID = c.String(),
                        CREATED_BY = c.String(),
                        CREATION_DATETIME = c.DateTime(),
                        DELETED_BY = c.String(),
                        DELETE_DATETIME = c.DateTime(),
                        UPDATED_BY = c.String(),
                        UPDATE_DATETIME = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DiagramProblems",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        ProblemName = c.String(),
                        ProblemDescription = c.String(),
                        CREATED_BY = c.String(),
                        CREATION_DATETIME = c.DateTime(),
                        DELETED_BY = c.String(),
                        DELETE_DATETIME = c.DateTime(),
                        UPDATED_BY = c.String(),
                        UPDATE_DATETIME = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DiagramQuestions",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        QuestionText = c.String(),
                        LOVType = c.String(),
                        AnswerObject = c.Long(),
                        AnswerAttribute = c.Long(),
                        IsFreeText = c.Boolean(),
                        AnswerYesValueCriteria = c.String(),
                        CREATED_BY = c.String(),
                        CREATION_DATETIME = c.DateTime(),
                        DELETED_BY = c.String(),
                        DELETE_DATETIME = c.DateTime(),
                        UPDATED_BY = c.String(),
                        UPDATE_DATETIME = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DiagramQuestions");
            DropTable("dbo.DiagramProblems");
            DropTable("dbo.DiagramGroupQuestions");
            DropTable("dbo.DiagaramGroups");
        }
    }
}
