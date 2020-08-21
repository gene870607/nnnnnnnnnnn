using Microsoft.EntityFrameworkCore;
using Storyteller.DBModels;
using System;

namespace Storyteller.Repository
{
    internal class GDRepository<T>
    {
        private GoodGood_DBContext _context;

        public GDRepository(GoodGood_DBContext context)
        {
            if (context == null)
            {
                throw new ArgumentException();
            }
            _context = context;
        }

        internal void Create(User userData)
        {
            _context.Entry(userData).State = EntityState.Added;
        }

        public void UserUpdate(User value)
        {
            _context.Entry(value).State = EntityState.Modified;
        }
    }
}