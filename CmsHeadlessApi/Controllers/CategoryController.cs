﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CmsHeadless.Models;
using System.Data.Entity.Core.EntityClient;
using System.Data;
using CmsHeadlessApi.ModelsController;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace CmsHeadlessApi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly CmsHeadlessDbContext _contextDb;
        public string pathMedia;
        private readonly IServer _server;
        public CategoryController(ILogger<CategoryController> logger, CmsHeadlessDbContext contextDb, IServer server)
        {
            _logger = logger;
            _contextDb = contextDb;
            _server = server;
            pathMedia = server.Features.Get<IServerAddressesFeature>().Addresses.ToList().FirstOrDefault();
        }

        [HttpGet]
        public JsonResult GetAllCategory(int? idCategory, string? nameCategory)
        {
            //string pathMedia = AppDomain.CurrentDomain.BaseDirectory;
            if (idCategory ==null && nameCategory == null) {
                var categoryItem = _contextDb.Category.ToList<Category>();
                foreach (var category in categoryItem)
                {
                    if (category.Media != null)
                    {
                        category.Media = pathMedia + category.Media;
                    }

                }
                return Json(categoryItem);
            }
            else if(nameCategory == null){
                var categoryItem = _contextDb.Category.FindAsync(idCategory);
                if (categoryItem == null)
                {
                    return Json(null);
                }
                else
                {
                    if(categoryItem.Result.Media!=null)
                    { 
                        categoryItem.Result.Media = pathMedia + categoryItem.Result.Media; 
                    }
                    return Json(categoryItem.Result);
                }
            }
            else if(idCategory == null)
            {
                var categoryItem = _contextDb.Category.Where(c=>c.Name.Contains(nameCategory)).ToList<Category>();
                if (categoryItem.Count()==0)
                {
                    return Json(null);
                }
                else
                {
                    foreach (var category in categoryItem)
                    {
                        if (category.Media != null)
                        {
                            category.Media = pathMedia + category.Media;
                        }
                    }
                    return Json(categoryItem);
                }
            }
            else
            {
                var categoryItem = _contextDb.Category.Where(c => c.CategoryId == idCategory && c.Name.Contains(nameCategory)).ToList<Category>();
                if (categoryItem.Count() == 0)
                {
                    return Json(null);
                }
                else
                {
                    foreach (var category in categoryItem)
                    {
                        if (category.Media != null)
                        {
                            category.Media = pathMedia + category.Media;
                        }
                    }
                    return Json(categoryItem);
                }
            }
        }

        
    }
}