using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;

namespace DataLayer
{
    public class PaymentsDatabase
    {
        readonly SQLiteAsyncConnection db;

        public PaymentsDatabase(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Address>().Wait();
            db.CreateTableAsync<UtilityBill>().Wait();
            db.CreateTableAsync<MeterReading>().Wait();
            db.CreateTableAsync<Payment>().Wait();
        }

        public Task<List<T>> GetAll<T>(bool withChildren = false) where T : Entity, new()
         => withChildren ? db.GetAllWithChildrenAsync<T>() : db.Table<T>().ToListAsync();

        public Task<List<T>> GetAll<T>(Expression<Func<Task, bool>> @where,
            Expression<Func<T, bool>> order = null, bool desc = false,
            int? skip = null, int? take = null) where T : Entity, new()
        {
            var all = db.Table<T>();
            if(order != null)
            {
                if (desc) all = all.OrderByDescending(order).ThenBy(t => t.Id);
                else all = all.OrderBy(order).ThenBy(t => t.Id);
            }
            if (skip.HasValue) all = all.Skip(skip.Value);
            if (take.HasValue) all = all.Take(take.Value);

            return all.ToListAsync();
        }

        public Task<T> GetById<T>(int id) where T : Entity, new()
            => db.Table<T>().Where(t => t.Id == id).FirstOrDefaultAsync();

        public Task<int> Save<T>(T item, bool withChildren = false) where T : Entity, new()
        {
            if (item.IsNew)
            {
                if (withChildren)
                {
                    db.InsertWithChildrenAsync(item);
                    return new Task<int>(()=> { return 0; });
                }
                else return db.InsertAsync(item);
            }
            else return db.UpdateAsync(item);
        }

        public Task<int> Delete<T>(T item) where T : Entity, new()
        {
            return db.DeleteAsync(item);
        }

        public Task<List<T>> Query<T>(string query) where T : Entity, new()
            => db.QueryAsync<T>(query);
    }
}
