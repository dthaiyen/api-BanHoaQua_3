using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemBusiness _itemBusiness;
        private string _path;
        public ItemController(IItemBusiness itemBusiness, IConfiguration configuration)
        {
            _itemBusiness = itemBusiness;
            _path = configuration["AppSettings:PATH"];
        }

        [Route("create-item")]
        [HttpPost]
        public ItemModel CreateItem([FromBody] ItemModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public ItemModel GetDatabyID(int id)
        {
            return _itemBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ItemModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string item_group_id = "";
                if (formData.Keys.Contains("item_group_id") && !string.IsNullOrEmpty(Convert.ToString(formData["item_group_id"]))) { item_group_id = Convert.ToString(formData["item_group_id"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize,out total,  item_group_id);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        [Route("get_sanpham_new")]
        [HttpGet]
        public List<ItemModel> Get_Sanpham_New()
        {
            return _itemBusiness.Get_Sanpham_New();
        }
        [Route("Get_Sanpham_lq/{id}")]
        [HttpGet]
        public List<ItemModel> Get_Sanpham_lq(int id)
        {
            return _itemBusiness.Get_Sanpham_lq(id);
        }
        [Route("Get_Sanpham_idloai/{id}")]
        [HttpGet]
        public List<ItemModel> Get_Sanpham_idloai(int id)
        {
            return _itemBusiness.Get_Sanpham_idloai(id);
        }

        [Route("get_san_pham_search")]
        [HttpPost]
        public ResponseModel get_san_pham_search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            var page = int.Parse(formData["page"].ToString());
            var pageSize = int.Parse(formData["pageSize"].ToString());
            string search = "";
            if (formData.Keys.Contains("search") && !string.IsNullOrEmpty(Convert.ToString(formData["search"])))
            {
                search = formData["search"].ToString();
                long total = 0;
                var data = _itemBusiness.get_san_pham_search(page, pageSize, out total, search);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            return response;
        }
        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("delete-item")]
        [HttpPost]
        public IActionResult DeleteItem([FromBody] Dictionary<string, object> formData)
        {
            string masp = "";
            if (formData.Keys.Contains("masp") && !string.IsNullOrEmpty(Convert.ToString(formData["masp"]))) { masp = Convert.ToString(formData["masp"]); }
            _itemBusiness.Delete(masp);
            return Ok();
        }

        [Route("create-item")]
        [HttpPost]
        public ItemModel CreateUser([FromBody] ItemModel model)
        {
            if (model.hinhanh != null)
            {
                var arrData = model.hinhanh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.hinhanh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            //model.user_id = Guid.NewGuid().ToString();
            _itemBusiness.Create(model);
            return model;
        }

        [Route("update-item")]
        [HttpPost]
        public ItemModel UpdateUser([FromBody] ItemModel model)
        {
            if (model.hinhanh != null)
            {
                var arrData = model.hinhanh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.hinhanh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _itemBusiness.Update(model);
            return model;
        }
    }
}
