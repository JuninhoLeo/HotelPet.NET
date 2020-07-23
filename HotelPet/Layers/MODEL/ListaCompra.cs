using HotelPet.Camadas.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Layers.MODEL
{
    [Table("ListaCompra")]
    public class ListaCompra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string descricao { get; set; }
        public double Quantidade { get; set; }
        public double valor { get; set; }

        public double total { get; set; }

        [ForeignKey("Vendas")]
        public int Vendas_id { get; set; }
        virtual public Venda Vendas { get; set; }
        
        [ForeignKey("Produtos")]
        public long Codigo { get; set; }
        virtual public Produtos Produtos { get; set; }

    }
}
