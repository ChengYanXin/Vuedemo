
using System.Collections.Generic;

namespace MyVueDemoApi.Model
{
    public interface bulidRepository
    {
        //返回全部
        IEnumerable<building> GetBuildings();
    }
}
