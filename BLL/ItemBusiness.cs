using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class ItemBusiness : IItemBusiness
    {
        private IItemRepository _res;
        public ItemBusiness(IItemRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Create(ItemModel model)
        {
            return _res.Create(model);
        }
        public ItemModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ItemModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<ItemModel> Search(int pageIndex, int pageSize, out long total, string item_group_id)
        {
            return _res.Search(pageIndex, pageSize, out total, item_group_id);
        }

        public List<ItemModel> Get_Sanpham_New()
        {
            return _res.Get_Sanpham_New();
        }

        public List<ItemModel> Get_Sanpham_lq(int id)
        {
            return _res.Get_Sanpham_lq(id);
        }
        public List<ItemModel> Get_Sanpham_idloai(int id)
        {
            return _res.Get_Sanpham_idloai(id);
        }

        public List<ItemModel> get_san_pham_search(int pageIndex, int pageSize, out long total, string search)
        {
            return _res.get_san_pham_search(pageIndex, pageSize, out total, search);
        }
    }

}
