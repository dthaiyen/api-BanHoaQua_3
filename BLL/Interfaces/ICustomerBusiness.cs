using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ICustomerBusiness
    {
        bool Create(CustomerModel model);
        List<CustomerModel> Get_Khachhang_All();
    }
}
