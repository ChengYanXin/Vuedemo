using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MyVueDemoApi.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;

namespace MyVueDemoApi.Controllers
{
    [Route("api/build/[action]")]
    [ApiController]
    public class bulidController : ControllerBase
    {
        [HttpGet]
        //展示楼栋
        public IEnumerable<building> GetBuildings()
        {
            List<building> buildings = new List<building>();
            using (IDbConnection db = new SqlConnection("Server=.;Database=mydbdemo;pwd=123;uid=sa"))
            {
                string sql = @"Select * from building";
                buildings= db.Query<building>(sql).ToList();
                
            }
            return buildings;
        }
        [HttpGet]
        //查询楼栋
        public IEnumerable<building> SearchBuildings(string name)
        {
            List<building> buildings = new List<building>();
            using (IDbConnection db = new SqlConnection("Server=.;Database=mydbdemo;pwd=123;uid=sa"))
            {
                buildings = db.Query<building>("Select * from building where bname like @n", new { n = "%" + name + "%" }).ToList();
            }
            return buildings;
        }
        [HttpDelete]
        //删除楼栋
        public int DelBuildings(int id)
        {
            var row = 0;
            using (IDbConnection db = new SqlConnection("Server=.;Database=mydbdemo;pwd=123;uid=sa"))
            {
                string sqlQuery = "Delete  from building where bid=" + id;
                row = db.Execute(sqlQuery);
            }
            return row;
        }
        [HttpPut]
        //修改楼栋
        public int Updatebuild(int id, string bname)
        {
            var row = 0;
            building bild = new building();
            using (IDbConnection db = new SqlConnection("Server=.;Database=mydbdemo;pwd=123;uid=sa"))
            {
                string sqlQuery = " UPDATE building SET bname = '" + bname + "' where bid=" + id;
                row = db.Execute(sqlQuery, bild);

            }
            return row;
        }
        [HttpPost]
        //添加数据
        public int Insertbuild([FromBody] buildItem item)
        {

            var row = 0;
            building bild = new building();
            using (IDbConnection db = new SqlConnection("Server=.;Database=mydbdemo;pwd=123;uid=sa"))
            {
                string sqlQuery = "Insert Into building (bname, bfloorheight, blocation) Values('" + item.bulidName + "', '" + item.buildHigh + "', '" + item.buildAddres + "')";
                row = db.Execute(sqlQuery, bild);
            }
            return row;

        }

    }
}
