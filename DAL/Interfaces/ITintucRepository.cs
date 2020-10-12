
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ITintucRepository
    {
        List<tintucModel> Get_Tintuc_all();
        List<tintucModel> Get_Tintuc_new();
    }
}

