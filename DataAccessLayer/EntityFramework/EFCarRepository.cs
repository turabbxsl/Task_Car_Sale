using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFCarRepository : GenericRepository<Car>, ICarDAL
    {
        public Car GetCarByModel(string model)
        {
            using (var c = new Context())
            {
                return c.Cars.Where(c => c.Model == model).FirstOrDefault();
            };
        }

       
    }
}
