using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderingDomain.Common;
using OrderingDomain.Entities;

namespace OrderingInfrastructure.Presistence
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entity in ChangeTracker.Entries<EntityBase>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreatedDate = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entity.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
