using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Student
    {
        public int SId { get; set; }
        public string SName { get; set; }
        public string SCourse { get; set; }
        public string SCollege { get; set; }
    }

    public interface IDal
    {
        Student[] GetAll();
        Student GetStdById(int id);
        bool ModifyStd(Student std);
        bool AddStd(Student std);
        bool DeleteStd(int id);
    }

    public static class DalFactory
    {
        public static IDal GetDalInstance(string cnnstr)
        {
            return new CDal(cnnstr);
        }
    }

    internal class CDal : IDal
    {
        private readonly string cnnstr;
        SqlConnection connection;
        SqlCommand command;

        public CDal(string cnnstr)
        {
            this.cnnstr = cnnstr;
            connection = new SqlConnection(cnnstr);
            command = connection.CreateCommand();
        }
        private bool DoNotQuery(string query)
        {
            command.CommandText = query;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected > 0;
        }

        private List<Student> DoQuery(string query)
        {
            List<Student> students = new List<Student>();
            command.CommandText = query;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                students.Add(new Student { SId = (int)reader[0], SName = reader[1].ToString(), SCourse = reader[2].ToString(), SCollege = reader[3].ToString() });
            }
            reader.Close();
            return students;
        }

        public bool AddStd(Student std)
        {
            string query = $"insert into Student values ({std.SId},'{std.SName}','{std.SCourse}', '{std.SCollege}')";
            return DoNotQuery(query);
        }

        public bool DeleteStd(int id)
        {
            string query = $"delete from Student where StdId={id}";
            return DoNotQuery(query);
        }

        public bool ModifyStd(Student std)
        {
            string query = $"update Student set StdName='{std.SName}', StdCourse='{std.SCourse}', StdCollege='{std.SCollege}'  where StdId={std.SId}";
            return DoNotQuery(query);
        }

        public Student[] GetAll()
        {
            string query = "select * from Student";
            List<Student> students = DoQuery(query);
            return students.ToArray();
        }

        public Student GetStdById(int id)
        {
            string query = $"select * from Student where StdId={id}";
            List<Student> students = DoQuery(query);
            return students.FirstOrDefault();
        }

    }
}
