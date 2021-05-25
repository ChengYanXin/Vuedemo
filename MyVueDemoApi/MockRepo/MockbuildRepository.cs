using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MyVueDemoApi.Model
{
    public class MockbuildRepository : bulidRepository
    {
        private readonly TodoContext _context;

        public MockbuildRepository(TodoContext context)
        {
            _context = context;
        }
        //全部数据
        public IEnumerable<building> GetBuildings()
        {
            return _context.Buildings;
        }
    }
}
