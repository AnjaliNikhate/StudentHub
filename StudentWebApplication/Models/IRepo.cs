using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApplication.Models
{
    internal interface IRepo
    {
        Student[] GetAllStudents();
        Student GetStudent(int id);
        bool AddStudent(StudentWebApplication.Models.Student student);
        bool UpdateStudent(StudentWebApplication.Models.Student student);
        bool DeleteStudent(int id);
    }
}
