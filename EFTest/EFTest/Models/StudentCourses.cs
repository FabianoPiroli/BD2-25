using System.ComponentModel.DataAnnotations;

namespace EFTest.Models
{
    public class StudentCourses
    {
        [Key]
        public int StudentID { get; set; }
        // Property Navigation
        public Student? Student { get; set; }

        [Key]
        public int CourseID { get; set; }
        public Course? Course { get; set; }
    }
}
