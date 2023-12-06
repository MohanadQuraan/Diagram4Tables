using Diagram4Tables.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Diagram4Tables.Data
{
    public class DbContextForDiagram: DbContext
    {
        public DbContextForDiagram() : base("ConnectToDiagramDB")
        {
            Database.SetInitializer<DbContextForDiagram>(null);
        }


        public DbSet<SETUP_MTS_GROUP>SETUP_MTS_GROUP { get; set; }
        public DbSet<SETUP_MTS_GROUP_QUESTION> SETUP_MTS_GROUP_QUESTION { get; set; }
        public DbSet<SETUP_MTS_PROPLEM> SETUP_MTS_PROPLEM { get; set; }
        public DbSet<SETUP_MTS_QUESTION> SETUP_MTS_QUESTION { get; set; }

        public void InsertDiagaramGroup(SETUP_MTS_GROUP diagaramGroup)
        {
            this.SETUP_MTS_GROUP.Add(diagaramGroup);

            this.SaveChanges();
        }

        public void InsertDiagramGroupQuestion(SETUP_MTS_GROUP_QUESTION diagramGroupQuestion)
        {
            this.SETUP_MTS_GROUP_QUESTION.Add(diagramGroupQuestion);

            this.SaveChanges();
        }
        public void InsertDiagramProblem(SETUP_MTS_PROPLEM diagramProblem)
        {
            this.SETUP_MTS_PROPLEM.Add(diagramProblem);

            this.SaveChanges();
        }
        public void InsertDiagramQuestion(SETUP_MTS_QUESTION diagramQuestion)
        {
            this.SETUP_MTS_QUESTION.Add(diagramQuestion);

            this.SaveChanges();
        }



    }
}