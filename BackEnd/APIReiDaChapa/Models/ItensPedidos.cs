using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIReiDaChapa.Models
{
    public class ItensPedidos
    {
        [Column("id_pedidos")]
        public int IdPedidos {get; set;}

        [Column("id_produtos")]
        public int IdProdutos {get; set;}

        [Column ("quantidade_item_pedido")]
        public int QuantidadeItemPedido {get; set;}

        [Column("subtotal")]
        public int Subtotal {get; set;}
    }
}