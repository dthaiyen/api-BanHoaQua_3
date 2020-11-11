using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL.Interfaces
{
    public interface IthongkeBusiness
    {
        List<ItemModel> Get_Saphet_Sanpham();
        List<ItemModel> Get_Het_Sanpham();
        List<ItemModel> Get_tonkho_Sanpham();
    }
}