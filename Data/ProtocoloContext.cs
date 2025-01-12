using Microsoft.EntityFrameworkCore;
using ProtocoloApp.Models;

namespace ProtocoloApp.Data
{
    public class ProtocoloContext(DbContextOptions<ProtocoloContext> options) : DbContext(options)
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Protocolo> Protocolos { get; set; }
        public DbSet<StatusProtocolo> StatusProtocolos { get; set; }
        public DbSet<ProtocoloFollow> ProtocoloFollows { get; set; }
    }
}