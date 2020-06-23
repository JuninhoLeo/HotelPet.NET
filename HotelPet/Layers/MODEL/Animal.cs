using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    [Table("Animal")]

    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public DateTime? nascimento { get; set; }
        public DateTime? nascpai { get; set; }
        public DateTime? nascmae { get; set; }

        [StringLength(55)]
        public string especie { get; set; }

        [StringLength(55)]
        public string raca { get; set; }

        [StringLength(25)]
        public string pelagem { get; set; }

        [StringLength(25)]
        public string cor { get; set; }

        [StringLength(10)]
        public string porte { get; set; }

        [StringLength(5)]
        public string sexo { get; set; }

        [StringLength(55)]
        public string apelido { get; set; }

        [StringLength(55)]
        public string nome { get; set; }

        [StringLength(55)]
        public string pai { get; set; }

        [StringLength(55)]
        public string mae { get; set; }

        public string observacoes { get; set; }

        public string cuidados { get; set; }

        public bool hospedado { get; set; } = false;

        public byte[] imagem { get; set; }

        //CHAVE ESTRANGEIRA
        [ForeignKey("Cliente")]
        public int Cliente_id { get; set; }
        virtual public Cliente Cliente { get; set; }
    }
}
