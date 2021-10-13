using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;

namespace App.Database
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Models.User> User { get; set; }

        public DbSet<Models.Permission> Permision { get; set; }

        public DbSet<Models.PermissionType> PermissionType { get; set; }

        public AppDbContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }

        #region Save

        /// <inheritdoc/>
        public virtual void Save()
        {
            try
            {
                this.SaveChanges();

                if (Transaction is not null)
                {
                    Transaction.Commit();
                }
            }
            catch (Exception)
            {
                CloseTransaction();
            }
        }

        /// <inheritdoc/>
        public virtual async Task SaveAsync()
        {
            try
            {
                await this.SaveChangesAsync();

                if (Transaction is not null)
                {
                    await Transaction.CommitAsync();
                }
            }
            catch (Exception)
            {
                await CloseTransactionAsync();
            }
        }

        #endregion Save

        #region Transaction

        public IDbContextTransaction Transaction { get; private set; } = null!;

        public virtual void OpenTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (Transaction is not null)
            {
                Transaction.Dispose();
            }

            Transaction = Database.BeginTransaction(isolationLevel);
        }

        public virtual async Task OpenTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (Transaction is not null)
            {
                await Transaction.DisposeAsync();
            }

            Transaction = await Database.BeginTransactionAsync(isolationLevel);
        }

        private void CloseTransaction()
        {
            if (Transaction is not null)
            {
                Transaction.Dispose();
            }

            if (this is not null)
            {
                Database.CloseConnection();

                Dispose();
            }
        }

        private async Task CloseTransactionAsync()
        {
            if (Transaction is not null)
            {
                await Transaction.DisposeAsync();
            }

            if (this is not null)
            {
                await Database.CloseConnectionAsync();

                await DisposeAsync();
            }
        }


        #endregion Transaction
    }
}
