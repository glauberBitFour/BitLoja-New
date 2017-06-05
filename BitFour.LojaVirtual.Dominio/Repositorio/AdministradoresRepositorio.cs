

using System.Linq;
using BitFour.LojaVirtual.Dominio.Entidades;

namespace BitFour.LojaVirtual.Dominio.Repositorio
{
    public class AdministradoresRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public Administrador ObterAdministrador(Administrador administrador)
        {
            return _context.Administradores.FirstOrDefault(a=>a.Login == administrador.Login);
        }
    }
}
