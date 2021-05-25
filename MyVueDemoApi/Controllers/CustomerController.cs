using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyVueDemoApi.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyVueDemoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpGet]
        //展示客户信息
        public IEnumerable<customer> Getcustomers()
        {
            List<customer> customers = new List<customer>();
            using (IDbConnection db = new SqlConnection("Server=.;Database=mydbdemo;pwd=123;uid=sa"))
            {
                customers = db.Query<customer>("Select * from customer").ToList();
            }
            return customers;
        }
        [HttpGet]
        //查询房间
        public IEnumerable<customer> SearchCustomerS(string cname)
        {
            List<customer> customers = new List<customer>();
            using (IDbConnection db = new SqlConnection("Server=.;Database=mydbdemo;pwd=123;uid=sa"))
            {
                customers = db.Query<customer>("Select * from customer where cname like @n", new { n = "%" + cname + "%" }).ToList();
            }
            return customers;
        }
        [HttpDelete]
        //删除房间
        public int DelCustomerS(int id)
        {
            var row = 0;
            using (IDbConnection db = new SqlConnection("Server=.;Database=mydbdemo;pwd=123;uid=sa"))
            {
                string sqlQuery = "Delete  from customer where cid=" + id;
                row = db.Execute(sqlQuery);
            }
            return row;
        }

        [HttpPost]
        //添加数据
        public int InsertRooms([FromBody] customerItem item)
        {

            var row = 0;
            customer customer = new customer();
            using (IDbConnection db = new SqlConnection("Server=.;Database=mydbdemo;pwd=123;uid=sa"))
            {
                string sqlQuery = "Insert Into customer (cname, telephone, gender,email) Values('" + item.cname + "', '" + item.telephone + "', '" + item.gender + "','"+item.email+"')";
                row = db.Execute(sqlQuery, customer);
            }
            return row;

        }
    }
}
