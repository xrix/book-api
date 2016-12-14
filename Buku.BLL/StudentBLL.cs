using Buku.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buku.BussinessObject;
using Buku.DAL;

namespace Buku.BLL
{
    public class StudentBLL : IStudentBLL
    {
        private BukuDALContext db = new BukuDALContext();

        public Student ReadStudentById(int studentId)
        {
            Student student = db.Student.Find(studentId);
            return student;
        }

        public List<Student> ReadStudents()
        {
            return db.Student.ToList();
        }
    }
}
