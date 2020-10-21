using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class ItemRepository : IItemRepository
    {
        private IDatabaseHelper _dbHelper;
        public ItemRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(ItemModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_item_create",


                "@masp", model.masp         ,
                 "@tensp", model.tensp       ,
                 "@xuatxu", model.xuatxu     ,
                 "@gia", model.gia   ,
                 "@soluong", model.soluong   ,
                " @motadai", model.motadai       ,
                 "@motangan", model.motangan      ,
                 "@hinhanh", model.hinhanh      ,
                 "@ngaynhap", model.ngaynhap  ,
                 "@maloai", model.maloai ,
                 "@rate", model.rate   );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ItemModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ItemModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_item_get_by_id",
                     "@item_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ItemModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemModel> Get_Sanpham_lq(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_lq", "@l_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ItemModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemModel> Get_Sanpham_New()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sannpham_new");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ItemModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemModel> Search(int pageIndex, int pageSize, out long total, string madm)
        {
            throw new NotImplementedException();
        }
        public List<ItemModel> Get_Sanpham_idloai(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_by_id" , "@id_loai", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ItemModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ItemModel> get_san_pham_search(int pageIndex, int pageSize, out long total, string search)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_item_search_2", "@page_index", pageIndex, "@page_size", pageSize, "@search", search);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0)
                    total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ItemModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(ItemModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_item_update",
                 "@masp", model.masp,
                 "@tensp", model.tensp,
                 "@xuatxu", model.xuatxu,
                 "@gia", model.gia,
                 "@soluong", model.soluong,
                " @motadai", model.motadai,
                 "@motangan", model.motangan,
                 "@hinhanh", model.hinhanh,
                 "@ngaynhap", model.ngaynhap,
                 "@maloai", model.maloai,
                 "@rate", model.rate);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_item_delete",
                "@masp", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
