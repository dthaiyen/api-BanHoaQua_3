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
    public class LoaiController : ControllerBase
    {
        private readonly ILoaiBusiness _Business;
        public LoaiController(ILoaiBusiness bus)
        {
            _Business = bus;
        }
        [Route("get-loai")]
        [HttpGet]
        public List<LoaiModel> Get_Loai_All()
        {
            return _Business.Get_Loai_All();
        }
    }
}
