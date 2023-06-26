using Lvmendes.Adm.Entidade;
using Lvmendes.Adms.Entidade;
using Microsoft.EntityFrameworkCore;
namespace Lvmendes.Adms.Entidade
{
    public class AdmContext : DbContext
    {       

        public AdmContext(DbContextOptions<AdmContext> options) : base(options)
        {

        }

        public DbSet<CardapioEntidade> Cardapios { get; set; }
        public DbSet<MesaEntidade> Mesas { get; set; }
        public DbSet<UsuarioEntidade> Usuarios { get; set; }
        public DbSet<PerfilEntidade> Perfil { get; set; }
        public DbSet<EmpresaEntidade> Empresa { get; set; }


        public DbSet<ClienteEntidade> Cliente { get; set; }
        public DbSet<PedidoEntidade> Pedido { get; set; }
        public DbSet<ItemPedidoEntidade> ItemPedido { get; set; }

    }
}