using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    [Table("ItemVenda")]
    public class Itemvenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(255)]
        public string descricao { get; set; }

        public double quantidade { get; set; }
        public double valor { get; set; }

        //chaves estrangeiras
        [ForeignKey("Venda")]
        public int Venda_id { get; set; }
        virtual public Venda Venda { get; set; }

        [ForeignKey("Produtos")]
        public int Produtos_id { get; set; }
        virtual public Produtos Produtos { get; set; }

        [ForeignKey("Servicos")]
        public int Servicos_id { get; set; }
        virtual public Servicos Servicos { get; set; }

    }
}
