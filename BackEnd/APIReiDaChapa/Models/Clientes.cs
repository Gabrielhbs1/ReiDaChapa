using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIReiDaChapa.Models
{
    public class Clientes
    {
        [Column("id_clientes")]
        [Key]
        public int IdCliente {get; set;}

        [Column("nome")]
        public string Nome {get;set;}

        [Column("telefone")]
        public string Telefone {get; set;}

        [Column("email")]
        public string Email {get; set;}

        [Column("senha")]
        public string Senha {get; set;}

    }
}