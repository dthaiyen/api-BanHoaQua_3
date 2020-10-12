using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class TintucBusiness : ITintucBusiness
    {
        private ITintucRepository _res;
        public TintucBusiness(ITintucRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }

     
        public List<tintucModel> Get_Tintuc_all()
        {
            return _res.Get_Tintuc_all();
        }

      
        public List<tintucModel> Get_Tintuc_new()
        {
            return _res.Get_Tintuc_new();
        }
    }
}
