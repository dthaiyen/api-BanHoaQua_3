using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DAL
{
    public class LoaiRepository : ILoaiRepository
    {
        private IDatabaseHelper _dbHelper;
        public LoaiRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<LoaiModel> Get_Loai_All()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_loaisp_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LoaiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
