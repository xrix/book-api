using Buku.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buku.Contract
{
    public interface IStudentBLL
    {
        List<Student> ReadStudents();
        Student ReadStudentById(int studentId);
    }
}
