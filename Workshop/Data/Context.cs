using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Models;

namespace Workshop.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

    }
}
