using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyVueDemoApi.Model;

namespace MyVueDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        /// <summary>
        /// 获取所有学生
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Student> Get()
        {
            return DataHelper.GetStudent();
        }

        /// <summary>
        /// 新增学生
        /// </summary>
        /// <param name="entity">学生实体</param>
        /// <returns></returns>
        [HttpPost]
        public List<Student> Post(Student entity)
        {
            DataHelper.ListStudent.Add(entity);
            return DataHelper.ListStudent;
        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="entity">学生实体</param>
        /// <returns></returns>
        [HttpPut]
        public List<Student> Put(Student entity)
        {
            for (int i = 0; i < DataHelper.ListStudent.Count; i++)
            {
                if (DataHelper.ListStudent[i].ID == entity.ID)
                {
                    DataHelper.ListStudent[i].Name = entity.Name;
                    DataHelper.ListStudent[i].Age = entity.Age;
                    break;
                }
            }
            return DataHelper.ListStudent;
        }

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="id">学生Id</param>
        /// <returns></returns>
        [HttpDelete]
        public List<Student> Delete(int id)
        {
            for (int i = 0; i < DataHelper.ListStudent.Count; i++)
            {
                if (DataHelper.ListStudent[i].ID == id)
                {
                    DataHelper.ListStudent.Remove(DataHelper.ListStudent[i]);
                    break;
                }
            }
            return DataHelper.ListStudent;
        }
    }
}

