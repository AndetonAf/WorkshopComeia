using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
        public string NomeDaTarefa { get; set; }

        public Funcionario Funcionario { get; set; }

    }
}
