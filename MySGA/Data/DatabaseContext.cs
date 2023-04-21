using System.Collections.Generic;
using MySGA.Models;
using Microsoft.EntityFrameworkCore;

namespace MySGA.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        //abc@123 SrAlexDev\\SQLEXPRESS

    }
}
