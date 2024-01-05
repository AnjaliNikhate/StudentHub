using Dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace StudentWebApplication.Models
{
    public class ActualRepo : IRepo
    {
        private readonly string cnnstr;
        private IDal dal;

        public ActualRepo()
        {
            cnnstr = ConfigurationManager.ConnectionStrings["cnnstr"].ConnectionString;
            dal = DalFactory.GetDalInstance(cnnstr);
        }

        public Student[] GetAllStudents()
        {
            var students = from std in dal.GetAll() select new StudentWebApplication.Models.Student { Id = std.SId, Name = std.SName, Course = std.SCourse, College = std.SCollege };
            return students.ToArray();
        }

        public Student GetStudent(int id)
        {
            var std = dal.GetStdById(id);
            if (std != null)
            {
                return new StudentWebApplication.Models.Student
                {
                    Id = std.SId,
                    Name = std.SName,
                    Course = std.SCourse,
                    College = std.SCollege
                };
            }
            else
            {
                return null;
            }
        }

        public bool AddStudent(StudentWebApplication.Models.Student student)
        {
            return dal.AddStd(new Dal.Student { SId = student.Id, SName = student.Name, SCourse = student.Course, SCollege = student.College });
        }

        public bool UpdateStudent(StudentWebApplication.Models.Student student)
        {
            return dal.ModifyStd(new Dal.Student { SId = student.Id, SName = student.Name, SCourse = student.Course, SCollege = student.College });
        }

        public bool DeleteStudent(int Id)
        {
            return dal.DeleteStd(Id);
        }
    }
}