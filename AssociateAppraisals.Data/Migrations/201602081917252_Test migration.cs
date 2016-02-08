namespace AssociateAppraisals.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppraisalQuestionGroup",
                c => new
                    {
                        AppraisalQuestionGroupId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AppraisalQuestionGroupId);
            
            CreateTable(
                "dbo.AppraisalQuestion",
                c => new
                    {
                        AppraisalQuestionId = c.Int(nullable: false, identity: true),
                        AppraisalQuestionGroupId = c.Int(),
                        AppraisalQuestionTypeId = c.Int(nullable: false),
                        Question = c.String(nullable: false, maxLength: 100),
                        QuestionNumber = c.Int(nullable: false),
                        AppraisalId = c.Int(nullable: false),
                        AssociateAppraisal_AssociateAppraisalId = c.Int(),
                        AssociateAppraisalQuestionAnswer_AssociateAppraisalQuestionAnswerId = c.Int(),
                    })
                .PrimaryKey(t => t.AppraisalQuestionId)
                .ForeignKey("dbo.AssociateAppraisal", t => t.AssociateAppraisal_AssociateAppraisalId)
                .ForeignKey("dbo.Appraisal", t => t.AppraisalId, cascadeDelete: true)
                .ForeignKey("dbo.AssociateAppraisalQuestionAnswer", t => t.AssociateAppraisalQuestionAnswer_AssociateAppraisalQuestionAnswerId)
                .Index(t => t.AppraisalId)
                .Index(t => t.AssociateAppraisal_AssociateAppraisalId)
                .Index(t => t.AssociateAppraisalQuestionAnswer_AssociateAppraisalQuestionAnswerId);
            
            CreateTable(
                "dbo.Appraisal",
                c => new
                    {
                        AppraisalId = c.Int(nullable: false, identity: true),
                        ReviewYear = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AppraisalId);
            
            CreateTable(
                "dbo.AssociateAppraisal",
                c => new
                    {
                        AssociateAppraisalId = c.Int(nullable: false, identity: true),
                        AppraisalId = c.Int(nullable: false),
                        AssociateId = c.Int(nullable: false),
                        PracticeGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.AssociateAppraisalId)
                .ForeignKey("dbo.Appraisal", t => t.AppraisalId, cascadeDelete: true)
                .ForeignKey("dbo.Associate", t => t.AssociateId, cascadeDelete: true)
                .Index(t => t.AppraisalId)
                .Index(t => t.AssociateId);
            
            CreateTable(
                "dbo.Associate",
                c => new
                    {
                        AssociateId = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.AssociateId);
            
            CreateTable(
                "dbo.AssociateAppraisalQuestionAnswer",
                c => new
                    {
                        AssociateAppraisalQuestionAnswerId = c.Int(nullable: false, identity: true),
                        AppraisalQuestionId = c.Int(nullable: false),
                        AssociateAppraisalId = c.Int(nullable: false),
                        Answer = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.AssociateAppraisalQuestionAnswerId);
            
            CreateTable(
                "dbo.AppraisalQuestionType",
                c => new
                    {
                        AppraisalQuestionTypeId = c.Int(nullable: false, identity: true),
                        QuestionType = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.AppraisalQuestionTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppraisalQuestion", "AssociateAppraisalQuestionAnswer_AssociateAppraisalQuestionAnswerId", "dbo.AssociateAppraisalQuestionAnswer");
            DropForeignKey("dbo.AppraisalQuestion", "AppraisalId", "dbo.Appraisal");
            DropForeignKey("dbo.AssociateAppraisal", "AssociateId", "dbo.Associate");
            DropForeignKey("dbo.AppraisalQuestion", "AssociateAppraisal_AssociateAppraisalId", "dbo.AssociateAppraisal");
            DropForeignKey("dbo.AssociateAppraisal", "AppraisalId", "dbo.Appraisal");
            DropIndex("dbo.AssociateAppraisal", new[] { "AssociateId" });
            DropIndex("dbo.AssociateAppraisal", new[] { "AppraisalId" });
            DropIndex("dbo.AppraisalQuestion", new[] { "AssociateAppraisalQuestionAnswer_AssociateAppraisalQuestionAnswerId" });
            DropIndex("dbo.AppraisalQuestion", new[] { "AssociateAppraisal_AssociateAppraisalId" });
            DropIndex("dbo.AppraisalQuestion", new[] { "AppraisalId" });
            DropTable("dbo.AppraisalQuestionType");
            DropTable("dbo.AssociateAppraisalQuestionAnswer");
            DropTable("dbo.Associate");
            DropTable("dbo.AssociateAppraisal");
            DropTable("dbo.Appraisal");
            DropTable("dbo.AppraisalQuestion");
            DropTable("dbo.AppraisalQuestionGroup");
        }
    }
}
