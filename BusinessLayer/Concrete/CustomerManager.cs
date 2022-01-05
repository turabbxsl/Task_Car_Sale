using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {

        ICustomerDAL _customerDAL;

        public CustomerManager(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }
        public async Task<List<Customer>> GetList()
        {
            return await _customerDAL.GetListAll();
        }

        public Customer TAdd(Customer t)
        {
            return _customerDAL.Insert(t);
        }

        public void TDelete(Customer t)
        {
            _customerDAL.Delete(t);
        }

        public Customer TGetByID(int id)
        {
            return _customerDAL.GetByID(id);
        }

        public Customer TUpdate(Customer t)
        {
            return _customerDAL.Update(t);
        }
    }
}
