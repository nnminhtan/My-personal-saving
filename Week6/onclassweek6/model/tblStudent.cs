namespace onclassweek6.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblStudent")]
    public partial class tblStudent
    {
        [Key]
        [StringLength(20)]
        public string STUDENTID { get; set; }

        [StringLength(20)]
        public string FULLNAME { get; set; }

        public double? AVERAGESCORE { get; set; }

        public int? FACULTYID { get; set; }

        public virtual tblFaculty tblFaculty { get; set; }
    }
}
