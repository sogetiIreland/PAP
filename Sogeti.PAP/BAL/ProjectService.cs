using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogeti.PAP.BAL
{
    public class ProjectService
    {
        private PAPContext context = new PAPContext();

        public void Add(Project project)
        {
            context.Project.Add(project);
            context.SaveChanges();
        }

        public List<Project> GetAll()
        {
            return context.Project.ToList();
        }

        public void Add(StatusItem item)
        {
            context.StatusItem.Add(item);
            context.SaveChanges();
        }

        private class PAPContext : DbContext
        {
            public DbSet<Project> Project { get; set; }
            public DbSet<ProjectStatus> ProjectStatus { get; set; }
            public DbSet<Delivery> Delivery { get; set; }
            public DbSet<BusinessDevelopment> BusinessDevelopment { get; set; }
            public DbSet<StatusItem> StatusItem { get; set; }
            public DbSet<Person> Person { get; set; }
            public DbSet<Client> Client { get; set; }
        }
    }
}
