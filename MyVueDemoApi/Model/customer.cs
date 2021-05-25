using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVueDemoApi.Model
{
    public class customer
    {
        [Key]
        public int cid { get; set; }
        public string cname { get; set; }//客户名字
        public string telephone { get; set; }//电话
        public string gender { get; set; }//性别
        public string  email { get; set; }//邮箱

    }
}
