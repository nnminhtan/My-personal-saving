using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace onclassweek6.model
{
    public partial class StudentContextDB : DbContext
    {
        public StudentContextDB()
            : base("name=StudentContextDB1")
        {
        }

        public virtual DbSet<tblFaculty> tblFaculties { get; set; }
        public virtual DbSet<tblStudent> tblStudents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
