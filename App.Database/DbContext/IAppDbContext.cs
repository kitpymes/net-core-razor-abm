using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Threading.Tasks;

namespace App.Database
{
    public interface IAppDbContext
    {
        DbSet<Models.User> User { get; set; }
        DbSet<Models.Permission> Permision { get; set; }
        DbSet<Models.PermissionType> PermissionType { get; set; }

        #region Common

        DatabaseFacade Database { get; }

        IDbContextTransaction Transaction { get; }

        void OpenTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        Task OpenTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        void Save();

        Task SaveAsync();

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        #endregion Common
    }
}
