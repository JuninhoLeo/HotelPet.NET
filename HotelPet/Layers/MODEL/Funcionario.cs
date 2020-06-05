using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(255)]
        public string nome { get; set; }

        [StringLength(255)]
        public string rg { get; set; }

        [StringLength(255)]
        public string cpf { get; set; }

        [StringLength(255)]
        public string endereco { get; set; }

        [StringLength(2)]
        public string uf { get; set; }

        //chaves estrangeiras
        [ForeignKey("Usuario")]
        public int Usuario_id { get; set; }
        virtual public Usuario Usuario { get; set; }

        [ForeignKey("Permicoes")]
        public int Permicoes_id { get; set; }
        virtual public Permicoes Permicoes { get; set; }
    }
}
