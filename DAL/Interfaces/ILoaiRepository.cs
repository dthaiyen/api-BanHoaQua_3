﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ILoaiRepository
    {
        List<LoaiModel> Get_Loai_All();
        
    }
}

