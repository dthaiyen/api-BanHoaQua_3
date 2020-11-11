using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public class ThongkeBusiness : IthongkeBusiness
    {
        private readonly IthongkeRespo _Respo;
        public ThongkeBusiness(IthongkeRespo respo)
        {
            _Respo = respo;
        }

        public List<ItemModel> Get_Het_Sanpham()
        {
            return _Respo.Get_Het_Sanpham();
        }


        public List<ItemModel> Get_Saphet_Sanpham()
        {
            return _Respo.Get_Saphet_Sanpham();
        }

        public List<ItemModel> Get_tonkho_Sanpham()
        {
            return _Respo.Get_tonkho_Sanpham();
        }
    }
}