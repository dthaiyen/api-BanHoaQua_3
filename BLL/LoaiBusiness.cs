using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class LoaiBusiness : ILoaiBusiness
    {
        private ILoaiRepository _res;
        public LoaiBusiness(ILoaiRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }

        public List<LoaiModel> Get_Loai_All()
        {
            return _res.Get_Loai_All();
        }
    }
}
