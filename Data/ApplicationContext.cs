using Microsoft.EntityFrameworkCore;
using ServiceManagerApp3.Models;
using ServiceManagerApp3.Data;


namespace ServiceManagerApp3.Data
{
    public class ApplicationContext:DbContext
    {
        //Контекст базы данных - связывает модель и таблицы SQLite
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        
        //Таблицы заявок
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
    }
}
