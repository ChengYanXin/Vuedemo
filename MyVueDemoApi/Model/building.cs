using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyVueDemoApi.Model
{
    public class building
    {
        [Key]
        public int bid { get; set; }//楼栋编号
        public string bname { get; set; }//名称
        public string bfloorheight { get; set; }//层高
        public string blocation { get; set; }//位置
    }
}
