using Medfar.Interview.DAL.Repositories;
using Medfar.Interview.Types;
using Medfar.Interview.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medfar.Interview.Web.Controllers
{
    public class ExampleController : Controller
    {
        public ActionResult Index([Microsoft.AspNetCore.Mvc.FromBody] int currentPageIndex=0)
        {
          
            ExampleViewModel model = new ExampleViewModel();

            UserRepository userRep = new UserRepository();
            model.Users = userRep.GetAll();

            PaginationForUsers(model,currentPageIndex,"Index");

            return View("Index", model);
        }


        public void PaginationForUsers(ExampleViewModel model, int currentPageIndex = 0,string ActionName=null)
        {
            //Add pagination for current input

            //Max rows shown to user
            int maxrowscount = 2;

            double pageCount = (double)((decimal)model.Users.Count() / Convert.ToDecimal(maxrowscount));
            int PageCount = (int)Math.Ceiling(pageCount);

            ViewBag.PageCount = PageCount;
            ViewBag.CurrentPageIndex = currentPageIndex;

            ViewBag.ActionMethod = ActionName;

           var users = (from customer in model.Users
                         select customer)
                          .Skip((currentPageIndex - 1) * maxrowscount)
                          .Take(maxrowscount).ToList();
            model.Users = users;


        }

        [HttpPost]
        public ActionResult GetUserByName([Microsoft.AspNetCore.Mvc.FromBody] string UserName, [Microsoft.AspNetCore.Mvc.FromBody] int currentPageIndex = 0)
        {
            //After search pagination must be applied also (there was a problem with updating action method from View to be called)

            if (string.IsNullOrEmpty(UserName))
            {
               return Index();
            }

            ExampleViewModel model = new ExampleViewModel();

            UserRepository userRep = new UserRepository();
            model.Users = userRep.GetByUserName(UserName);
            PaginationForUsers(model, currentPageIndex, "GetUserByName");
           
            return View("Index", model);
        }

        public ActionResult LoadData()
        {
            ExampleViewModel model = new ExampleViewModel();

            UserRepository userRep = new UserRepository();
            model.Users = userRep.GetAll();

            //shuffle for fun
            var rnd = new Random();
            model.Users = model.Users.OrderBy(item => rnd.Next()).ToList();

            return View("Index",model);
        }

    }
}