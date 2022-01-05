using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CarManager : ICarService
    {

        ICarDAL _carDal;

        public CarManager(ICarDAL carDal)
        {
            _carDal = carDal;
        }

        public async Task<List<Car>> GetList()
        {
            return await _carDal.GetListAll();
        }

        public Car TAdd(Car t)
        {
             return _carDal.Insert(t);
        }

        public void TDelete(Car t)
        {
             _carDal.Delete(t);
        }

        public Car TGetByID(int id)
        {
            return _carDal.GetByID(id);
        }

        public  Car TUpdate(Car t)
        {
            return _carDal.Update(t);
        }


        public Car GetCarByModel(string model)
        {
            return _carDal.GetCarByModel(model);
        }
    }
}
