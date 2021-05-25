using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyVueDemoApi.Repo;
using MyVueDemoApi.Model;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

namespace MyVueDemoApi.Controllers
{
    [Route("api/room/[action]")]
    [ApiController]
    public class roomController : ControllerBase
    {
        [HttpGet]
        //展示房间
        public IEnumerable<room> Getrooms()
        {
            List<room>rooms = new List<room>();
            using (IDbConnection db = new SqlConnection("Server=.;Database=mydbdemo;pwd=123;uid=sa"))
            {
                rooms = db.Query<room>("Select * from room").ToList();
            }
            return rooms;
        }
        [HttpGet]
        //查询房间
        public IEnumerable<room> SearchRooms(string rfloor)
        {
            List<room> rooms = new List<room>();
            using (IDbConnection db = new SqlConnection("Server=.;Database=mydbdemo;pwd=123;uid=sa"))
            {
                rooms = db.Query<room>("Select * from room where rfloor like @n", new { n = "%" + rfloor + "%" }).ToList();
            }
            return rooms;
        }
        [HttpDelete]
        //删除房间
        public int DelRooms(int id)
        {
            var row = 0;
            using (IDbConnection db = new SqlConnection("Server=.;Database=mydbdemo;pwd=123;uid=sa"))
            {
                string sqlQuery = "Delete  from room where rid=" + id;
                row = db.Execute(sqlQuery);
            }
            return row;
        }

        [HttpPost]
        //添加数据
        public int InsertRooms([FromBody] roomItem item)
        {

            var row = 0;
            room rooms = new room();
            using (IDbConnection db = new SqlConnection("Server=.;Database=mydbdemo;pwd=123;uid=sa"))
            {
                string sqlQuery = "Insert Into room (rfloor, bid, rarea) Values('" + item.rfloor + "', '" + item.bid + "', '" + item.rarea + "')";
                row = db.Execute(sqlQuery, rooms);
            }
            return row;

        }
    }
}
