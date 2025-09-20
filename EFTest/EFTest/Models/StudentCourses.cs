﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTest.Models
{
    [PrimaryKey(nameof(StudentID), nameof(CourseID))]
    public class StudentCourses
    {
        public int StudentID { get; set; }
        // Property Navigation
        [ForeignKey(nameof(StudentID))]
        public Student? Student { get; set; }
        public int CourseID { get; set; }
        [ForeignKey(nameof(CourseID))]
        public Course? Course { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime? CancelDate { get; set; }

    }
}
