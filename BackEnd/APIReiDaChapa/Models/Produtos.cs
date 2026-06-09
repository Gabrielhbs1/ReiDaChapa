using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIReiDaChapa.Models
{
    public class Produtos
    {
            [Column("id_produtos")]
            [Key]
            public int IdProduto {get; set;}

            [Column("produto")]
            public string Produto {get; set;}

            [Column("tipo")]
            public string Tipo {get; set;}

            [Column("preco")]
            public decimal Preco {get; set;}

            [Column("quantidade")]
            public int Quantidade {get; set;}

            [Column("imagem")]
            public string Imagem {get; set;}

            [Column("disponivel")]
            public bool Disponivel {get; set;}


    }
}