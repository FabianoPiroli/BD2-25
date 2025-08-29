using EFTest.Data;
using EFTest.Models;

namespace EFTest.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext? _context;
        public StudentRepository(SchoolContext? context)
        {
            _context = context;
        }
        public void Create(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
