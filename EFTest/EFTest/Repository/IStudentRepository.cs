using EFTest.Models;

namespace EFTest.Repository
{
    public interface IStudentRepository
    {
        public void Create(Student student);
        public void Update(Student student);
        public void Delete(Student student);
        public Student? GetById(int id);
        public List<Student> GetAll();
        public List<Student> GetByName(string name);
    }
}