using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class ItemGroupBusiness : IItemGroupBusiness
    {
        private IItemGroupRepository _res;
        public ItemGroupBusiness(IItemGroupRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        
        public List<ItemGroupModel> GetData()
        {
            var allItemGroups = _res.GetData();
            var lstParent = allItemGroups.ToList();
            foreach (var item in lstParent)
            {
                item.children = GetHiearchyList(allItemGroups, item);
            }
            return lstParent;
        }
        public List<ItemGroupModel> GetHiearchyList(List<ItemGroupModel> lstAll, ItemGroupModel node)
        {
            var lstChilds = lstAll.Where(ds => ds.parent_item_group_id == node.madm).ToList();
            if (lstChilds.Count == 0)
                return null;
            for (int i = 0; i < lstChilds.Count; i++)
            {
                var childs = GetHiearchyList(lstAll, lstChilds[i]);
                lstChilds[i].type = (childs == null || childs.Count == 0) ? "leaf" : "";
                lstChilds[i].children = childs;
            }
            return lstChilds.ToList();
        }
        
    }

}
