using System;
using System.Collections.Generic;

namespace Model
{
    public class ItemGroupModel
    {
        public int parent_item_group_id { get; set; }
        public int madm { get; set; }
        public string tendm { get; set; }
        
        public int chiso { get; set; }
        public List<ItemGroupModel> children { get; set; }
        public string type { get; set; }
    }
}
