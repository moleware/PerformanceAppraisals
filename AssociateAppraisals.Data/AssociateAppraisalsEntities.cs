﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AssociateAppraisals.Model;

namespace AssociateAppraisals.Data
{
    public class AssociateAppraisalsEntities : DbContext
    {
        public AssociateAppraisalsEntities() : base("name=AssociateAppraisalsEntities") { }

        public DbSet<Appraisal> Appraisals { get; set; }
        public DbSet<AppraisalQuestion> AppraisalQuestions { get; set; }
        public DbSet<AppraisalQuestionGroup> AppraisalQuestionGroups { get; set; }
        public DbSet<AppraisalQuestionType> AppraisalQuestionTypes { get; set; }
        public DbSet<Associate> Associates { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<AssociateAppraisal> AssociateAppraisals { get; set; }
        public DbSet<AssociateAppraisalQuestionAnswer> AssociateAppraisalQuestionAnswers { get; set; }
        public DbSet<AssociateWork> AssociateWorks { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppraisalConfiguration());
            modelBuilder.Configurations.Add(new AppraisalQuestionConfiguration());
            modelBuilder.Configurations.Add(new AppraisalQuestionGroupConfiguration());
            modelBuilder.Configurations.Add(new AppraisalQuestionTypeConfiguration());
            modelBuilder.Configurations.Add(new AssociateConfiguration());
            modelBuilder.Configurations.Add(new PartnerConfiguration());
            modelBuilder.Configurations.Add(new AssociateAppraisalConfiguration());
            modelBuilder.Configurations.Add(new AssociateAppraisalQuestionAnswerConfiguration());
            modelBuilder.Configurations.Add(new AssociateWorkConfiguration());
        }
    }
}
