using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIReiDaChapa.Models
{
    public class Pedidos
    {
        [Column("id_pedidos")]
        [Key]
        public int IdPedido {get; set;}

        [Column("id_clientes")]
        public int IdClientes {get; set;}

        [Column("total")]
        public decimal Total {get; set;}

        [Column("status_pedido")]
        public string StatusPedido {get; set;}

        [Column("data_pedido")]
        public DateTime DataPedido {get; set;}

        public virtual Clientes Clientes {get; set;}
    }
}