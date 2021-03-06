﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tier.Business.Abstract;
using Tier.Entities.ComplexType;
using Tier.Entities.Concrete;
using Tier.Entities.EnType;
using Web.MVC.Models;
using Web.MVC.Services;

namespace Web.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        private IParamSessionService _paramSessionService;
        public CategoryController(IParamSessionService paramSessionService, ICategoryService categoryService)
        {
            _paramSessionService = paramSessionService;
            _categoryService = categoryService;
        }

        [Route("Category/{categoryId:int}")]
        public ActionResult Index(int categoryId)
        {
            var cat = _categoryService.GetById(categoryId);
            
            var model = new CategoryViewModel
            {
                MetaTitle = cat.Name,
                MetaDescription = cat.Summary,
                MetaKeywords = cat.Name,
                MetaAuthor = _paramSessionService.GetParam(ParamType.Author).Description,
                Category = cat
            };

            return View(model);
        }
    }
}
