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
    public class VehicleRepository : IVehicleRepository
    {
        public List<Vehicle> GetAll(Expression<Func<Vehicle, bool>> filter = null)
        {
            using (var context = new VehicleDbContext())
            {
                var result = from vehicle in context.Vehicles
                             join color in context.Colors on vehicle.ColorId equals color.Id
                             from car in context.Cars.Where(x => x.VehicleId == vehicle.Id).DefaultIfEmpty()
                             from bus in context.Buses.Where(x => x.VehicleId == vehicle.Id).DefaultIfEmpty()
                             from boat in context.Boats.Where(x => x.VehicleId == vehicle.Id).DefaultIfEmpty()
                             select new Vehicle()
                             {
                                 Id = vehicle.Id,
                                 HeadLight = vehicle.HeadLight,
                                 ColorId = vehicle.ColorId,
                                 Color = color,
                                 Car = car,
                                 Bus = bus,
                                 Boat = boat
                             };
                return (filter != null) ? result.Where(filter).ToList() : result.ToList();

            }
        }
        public Vehicle Get(Expression<Func<Vehicle, bool>> filter)
        {
            using (var context = new VehicleDbContext())
            {
                var result = from vehicle in context.Vehicles
                             join car in context.Cars on vehicle.Id equals car.VehicleId
                             join bus in context.Buses on vehicle.Id equals bus.VehicleId
                             join boat in context.Boats on vehicle.Id equals boat.VehicleId
                             select new Vehicle()
                             {
                                 Id = vehicle.Id,
                                 Color = vehicle.Color,
                                 HeadLight = vehicle.HeadLight,
                                 Car = car,
                                 Bus = bus,
                                 Boat = boat
                             };
                return result.Where(filter).SingleOrDefault();

            }

        }
        public void Add(Vehicle vehicle)
        {
            using (var context = new VehicleDbContext())
            {
                var addedEntity = context.Entry(vehicle);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                if (vehicle.Car != null)
                {
                    vehicle.Car.VehicleId= vehicle.Id;
                    var addedInEntity = context.Entry(vehicle.Car);
                    addedInEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
                if (vehicle.Bus != null)
                {
                    vehicle.Bus.VehicleId = vehicle.Id;
                    var addedInEntity = context.Entry(vehicle.Bus);
                    addedInEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
                if (vehicle.Boat != null)
                {
                    vehicle.Boat.VehicleId = vehicle.Id;
                    var addedInEntity = context.Entry(vehicle.Boat);
                    addedInEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
            }
        }
        public void Update(Vehicle vehicle)
        {
            using (var context = new VehicleDbContext())
            {
                context.Vehicles.Update(vehicle);
                if (vehicle.Car != null)
                {
                    context.Cars.Update(vehicle.Car);
                }
                if (vehicle.Bus != null)
                {
                    context.Buses.Update(vehicle.Bus);
                }
                if (vehicle.Boat != null)
                {
                    context.Boats.Update(vehicle.Boat);
                }
                context.SaveChanges();
            }
        }
        public void Delete(Vehicle vehicle)
        {
            using (var context = new VehicleDbContext())
            {
                context.Vehicles.Remove(vehicle);
                if (vehicle.Car != null)
                {
                    context.Cars.Remove(vehicle.Car);
                }
                if (vehicle.Bus != null)
                {
                    context.Buses.Remove(vehicle.Bus);
                }
                if (vehicle.Boat != null)
                {
                    context.Boats.Remove(vehicle.Boat);
                }
                context.SaveChanges();
            }
        }
    }
}

