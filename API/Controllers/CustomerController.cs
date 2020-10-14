using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerBusiness _customerBusiness;
        public CustomerController(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }
         
        [Route("create-item")]
        [HttpPost]
        public CustomerModel CreateItem([FromBody] CustomerModel model)
        {
            _customerBusiness.Create(model);
            return model;
        }

        [Route("get-khachhang")]
        [HttpGet]
        public IEnumerable<CustomerModel> GetAllKhachhang()
        {
            return _customerBusiness.Get_Khachhang_All();
        }
    }
}
