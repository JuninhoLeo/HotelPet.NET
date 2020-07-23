using HotelPet.Camadas.MODEL;
using HotelPet.Layers.MODEL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Entity
{
    class Contexto : DbContext
    {
        public Contexto() : base("name=HotelPet") { }

        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Consumo> Consumo { get; set; }
        public DbSet<Historico> Historico { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<ListaCompra> ListaCompras { get; set; }
        public DbSet<Permicoes> Permicao { get; set; }
        public DbSet<Produtos> Produto { get; set; }
        public DbSet<Quarto> Quarto { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venda> Venda { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
