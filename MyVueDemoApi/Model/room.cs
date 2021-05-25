using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVueDemoApi.Model
{
    public class room
    {
        [Key]
        public int rid { get; set; }//房间编号
        public string rfloor { get; set; }//楼层
        public string bid { get; set; }//所属楼栋
        public string rarea { get; set; }//面积
    }
}
