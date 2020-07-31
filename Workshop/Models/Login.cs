using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workshop.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

    }
}
