
using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Interfaces
{
    public interface IthongkeRespo
    {
        List<ItemModel> Get_Saphet_Sanpham();
        List<ItemModel> Get_Het_Sanpham();
        List<ItemModel> Get_tonkho_Sanpham();
    }
}