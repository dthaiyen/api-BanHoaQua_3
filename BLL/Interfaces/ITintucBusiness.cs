

using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ITintucBusiness
    {
       
        List<tintucModel> Get_Tintuc_all();
       
        List<tintucModel> Get_Tintuc_new();
    }
}
