﻿using Microsoft.AspNetCore.Mvc;

namespace ItServiceApp.Areas.Admin.Controllers
{
    public class ManageController : AdminBaseController
    {
       public IActionResult Index()
        {
            return View();
        }
    }
}
