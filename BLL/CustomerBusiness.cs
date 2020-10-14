using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class CustomerBusiness : ICustomerBusiness
    {
        private ICustomerRepository _res;
        public CustomerBusiness(ICustomerRepository res)
        {
            _res = res;
        }
        public bool Create(CustomerModel model)
        {
            return _res.Create(model);
        }

        public List<CustomerModel> Get_Khachhang_All()
        {
            return _res.Get_Khachhang_All();
        }
    }

}
