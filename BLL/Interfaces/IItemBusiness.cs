using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IItemBusiness
    {
        bool Create(ItemModel model);
        ItemModel GetDatabyID(int id);
        List<ItemModel> GetDataAll();
        List<ItemModel> Search(int pageIndex, int pageSize, out long total, string madm);
        List<ItemModel> Get_Sanpham_New();
        List<ItemModel> Get_Sanpham_lq(int id);
    }
}
