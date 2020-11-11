﻿using System;
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
    public class HoaDonController : ControllerBase
    {
        private IHoaDonBusiness _hoaDonBusiness;
        public HoaDonController(IHoaDonBusiness hoaDonBusiness)
        {
            _hoaDonBusiness = hoaDonBusiness;
        }

        [Route("create-hoa-don")]
        [HttpPost]
        public HoaDonModel CreateItem([FromBody] HoaDonModel model)
        {
            model.mahdd = Guid.NewGuid().ToString();
            if (model.listjson_chitiet != null)
            {
                foreach (var item in model.listjson_chitiet)
                    item.mahdd = model.mahdd;
            }
            _hoaDonBusiness.Dat_Hang(model.mahdd,model.makh, model.noigiao, model.sdt,model.thanhtien,model.listjson_chitiet);
            return model;
        }
    }
}
