﻿using Microsoft.AspNetCore.Mvc;

namespace Laboratory.Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
