using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HM.CourseManagement.Data
{
    public class CourseList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }       

        public DateTime Schedule { get; set; }

        public string Location { get; set; }

        public Course Course { get; set; }

        public Faculty Faculty { get; set; }
    }
}