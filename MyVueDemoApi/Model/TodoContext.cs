using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVueDemoApi.Model
{
    public class TodoContext:DbContext
    {
        public IConfiguration Configuration { get; }
        public TodoContext(DbContextOptions<TodoContext> options,IConfiguration configuration): base(options)
        {
            Configuration = configuration;
        }
        public  DbSet<building> Buildings { get; set; }
        public  DbSet<room>  Rooms { get; set; }
        public  DbSet<customer> Customers { get; set; }
    }
}


