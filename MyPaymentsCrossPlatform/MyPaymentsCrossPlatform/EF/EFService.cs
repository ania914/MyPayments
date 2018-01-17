using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyPaymentsCrossPlatform.EF
{
    public interface IEFService<T> where T: Entity, new()
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T item);
        Task Delete(int id);
    }

    public class EFService<T> : IEFService<T> where T : Entity, new()
    {
        private PaymentsContext context;
        public EFService()
        {
            context = App.Database;
        }
        
        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task Insert(T item)
        {
            context.Set<T>().Update(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = await GetById(id);
            if(item != null)
            {
                context.Set<T>().Remove(item);
                await context.SaveChangesAsync();
            }
        }

    }
}
