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
            throw new NotImplementedException();
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
    }
}
