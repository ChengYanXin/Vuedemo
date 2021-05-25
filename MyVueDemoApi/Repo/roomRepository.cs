using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyVueDemoApi.Model;

namespace MyVueDemoApi.Repo
{
   public  interface roomRepository
    {
        IEnumerable<room> GetRooms();
    }
}
