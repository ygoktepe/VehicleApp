using Example.DataAccess.Abstract;
using Example.DataAccess.Concrete.Contexts;
using Example.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Example.DataAccess.Concrete
{
    public class ColorRepository : IColorRepository
    {
        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (var context = new VehicleDbContext())
            {

                return filter == null
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filter).ToList();

            }
        }
        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (var context = new VehicleDbContext())
            {
                    return context.Set<Color>().Where(filter).SingleOrDefault();

            }

        }
        public void Add(Color color)
        {
            using (var context = new VehicleDbContext())
            {
                var addedEntity = context.Entry(color);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Update(Color color)
        {
            using (var context = new VehicleDbContext())
            {
                var addedEntity = context.Entry(color);
                addedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(Color color)
        {
            using (var context = new VehicleDbContext())
            {

                var addedEntity = context.Entry(color);
                addedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}

