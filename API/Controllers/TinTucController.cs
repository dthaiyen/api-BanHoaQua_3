using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinTucController : ControllerBase
    {
        private readonly ITintucBusiness _Business;
        public TinTucController(ITintucBusiness bus)
        {
            _Business = bus;
        }
       [Route("get_tintuc_new")]
       [HttpGet]
       public List<tintucModel> get_Tintuc_New()
        {
            return _Business.Get_Tintuc_new();
        }
    }
}
