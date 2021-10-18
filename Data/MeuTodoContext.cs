using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MeuTodo.Models;

namespace MeuTodo.Data
{
    public class MeuTodoContext : DbContext
    {
        public MeuTodoContext (DbContextOptions<MeuTodoContext> options)
            : base(options)
        {
        }

        public DbSet<MeuTodo.Models.Todo> Todo { get; set; }
    }
}
