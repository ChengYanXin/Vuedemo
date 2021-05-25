using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVueDemoApi.Model
{
    public class DataHelper
    {
        public static List<Student> ListStudent = new List<Student>();

        public static List<Student> GetStudent()
        {
            for (int i = 0; i < 5; i++)
            {
                Student student = new Student();
                student.ID = i;
                student.Name = $"测试_{i}";
                student.Age = 20 + i;
                ListStudent.Add(student);
            }

            return ListStudent;
        }
    }
}
