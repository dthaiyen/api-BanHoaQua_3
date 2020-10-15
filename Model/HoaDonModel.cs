using System;
using System.Collections.Generic;

namespace Model
{
    public class HoaDonModel
    {

        public int mahdd { get; set; }
        public System.DateTime ngaydat { get; set; }
        public Nullable<System.DateTime> ngaygiao { get; set; }
        public string tinhtrang { get; set; }
        public Nullable<int> makh { get; set; }
        public string noigiao { get; set; }
        public string sdt { get; set; }
        public Nullable<int> thanhtien { get; set; }
        public List<ChiTietHoaDonModel> listjson_chitiet { get; set; }
    }
}
