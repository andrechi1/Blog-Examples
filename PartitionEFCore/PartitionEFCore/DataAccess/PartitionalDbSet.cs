using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace PartitionEFCore.DataAccess
{
    /// <summary>Represent a <see cref="DbSet{TEntity}"/> whit partitions</summary>
    /// <typeparam name="TEntity">The type of entity being operated on by this set.</typeparam>
    /// <typeparam name="TIdPartition"></typeparam>
    public class PartitionalDbSet<TEntity, TIdPartition> : DbSet<TEntity>,
            IQueryable<TEntity>, IAsyncEnumerableAccessor<TEntity>, IInfrastructure<IServiceProvider>
        where TEntity : class
    {
        private readonly TIdPartition mIdPartition;

        private readonly DbSet<TEntity> mDbSetBase;

        public PartitionalDbSet(DbSet<TEntity> dbSetBase, TIdPartition idPartition)
        {
            mDbSetBase = dbSetBase;
            mIdPartition = idPartition;
        }

        public override LocalView<TEntity> Local => mDbSetBase.Local;

        public override TEntity Find(params object[] keyValues) => mDbSetBase.Find(keyValues);

        public override Task<TEntity> FindAsync(params object[] keyValues) => mDbSetBase.FindAsync(keyValues);

        public override Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
            => mDbSetBase.FindAsync(keyValues, cancellationToken);

        public override EntityEntry<TEntity> Add(TEntity entity)
            => mDbSetBase.Add(entity);

        public override Task<EntityEntry<TEntity>> AddAsync(
            TEntity entity,
            CancellationToken cancellationToken = default(CancellationToken))
            => mDbSetBase.AddAsync(entity, cancellationToken);

        public override EntityEntry<TEntity> Attach(TEntity entity)
            => mDbSetBase.Attach(entity);

        public override EntityEntry<TEntity> Remove(TEntity entity)
            => mDbSetBase.Remove(entity);

        public override EntityEntry<TEntity> Update(TEntity entity)
            => mDbSetBase.Update(entity);

        public override void AddRange(params TEntity[] entities)
            => mDbSetBase.AddRange(entities);

        public override Task AddRangeAsync(params TEntity[] entities)
            => mDbSetBase.AddRangeAsync(entities);

        public override void AttachRange(params TEntity[] entities)
            => mDbSetBase.AttachRange(entities);

        public override void RemoveRange(params TEntity[] entities)
            => mDbSetBase.RemoveRange(entities);

        public override void UpdateRange(params TEntity[] entities)
            => mDbSetBase.UpdateRange(entities);

        public override void AddRange(IEnumerable<TEntity> entities)
            => mDbSetBase.AddRange(entities);

        public override Task AddRangeAsync(
            IEnumerable<TEntity> entities,
            CancellationToken cancellationToken = default(CancellationToken))
            => mDbSetBase.AddRangeAsync(entities, cancellationToken);

        public override void AttachRange(IEnumerable<TEntity> entities)
            => mDbSetBase.AttachRange(entities);

        public override void RemoveRange(IEnumerable<TEntity> entities)
            => mDbSetBase.RemoveRange(entities);

        public override void UpdateRange(IEnumerable<TEntity> entities)
            => mDbSetBase.UpdateRange(entities);

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
            => ((IEnumerable<TEntity>)mDbSetBase).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)mDbSetBase).GetEnumerator();

        IAsyncEnumerable<TEntity> IAsyncEnumerableAccessor<TEntity>.AsyncEnumerable =>
            ((IAsyncEnumerableAccessor<TEntity>)mDbSetBase).AsyncEnumerable;

        Type IQueryable.ElementType => ((IQueryable)mDbSetBase).ElementType;

        Expression IQueryable.Expression
        {
            get
            {
                Expression dbExpression = ((IQueryable)mDbSetBase).Expression;

                TIdPartition idPartition = mIdPartition;

                Expression<Func<TEntity, bool>> expresionFuncFilter = b => EF.Property<TIdPartition>(b, "IdPartition").Equals(idPartition);

                IQueryable<TEntity> source = null;
                Expression<Func<TEntity, bool>> predicate = null;

                var meth = GetMethodInfo<IQueryable<TEntity>, Expression<Func<TEntity, bool>>,
                    IQueryable<TEntity>>(new Func<IQueryable<TEntity>, Expression<Func<TEntity, bool>>, IQueryable<TEntity>>
                        (Queryable.Where<TEntity>), source, predicate);

                Expression expression = Expression.Call(null, meth, dbExpression, expresionFuncFilter);

                return expression;
            }
        }


        IQueryProvider IQueryable.Provider => ((IQueryable)mDbSetBase).Provider;

        IServiceProvider IInfrastructure<IServiceProvider>.Instance
            => ((IInfrastructure<IServiceProvider>)mDbSetBase).Instance;

        private static MethodInfo GetMethodInfo<T1, T2, T3>(Func<T1, T2, T3> f, T1 unused1, T2 unused2)
        {
            return f.GetMethodInfo();
        }
    }
}
