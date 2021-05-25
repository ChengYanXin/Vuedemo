using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyVueDemoApi.Model;
using MyVueDemoApi.Repo;
namespace MyVueDemoApi.MockRepo
{
    public class MockroomRepository : roomRepository
    {
        private readonly TodoContext _context;

        public MockroomRepository(TodoContext context)
        {
            _context = context;
        }
        public IEnumerable<room> GetRooms()
        {
            return _context.Rooms;
        }
    }
}
