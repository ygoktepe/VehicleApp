using Example.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Example.DataAccess.Abstract
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAll(Expression<Func<Vehicle, bool>> filter = null);
        Vehicle Get(Expression<Func<Vehicle, bool>> filter);
        void Add(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(Vehicle vehicle);
    }
    public interface IColorRepository
    {
        List<Color> GetAll(Expression<Func<Color, bool>> filter = null);
        Color Get(Expression<Func<Color, bool>> filter);
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
    }
}
