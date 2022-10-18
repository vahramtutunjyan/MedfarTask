
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medfar.Interview.Web.Models;
using System.Data.Common;

namespace Medfar.Interview.Web.Controllers
{
    public class ExamController : Controller
    {
        //must be moved to config file
        private static string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=MEDFAR_DEV_INTERVIEW;Integrated Security=True";
        private static SqlConnection _dbConnection;

        public ActionResult Index()
        {
            return View();
        }


        public void AddUserToDb(ExamViewModel model)
        {
            using (SqlConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                string query = $"INSERT INTO Users (id,first_name,last_name,email,date_created) VALUES('{Guid.NewGuid()}','{model.FirstName}','{model.LastName}','{model.Email}','{DateTime.Now.ToString("yyyyMMdd")}')";
                using (SqlCommand command = new SqlCommand(query, dbConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        [HttpPost]
        public ActionResult Users([Microsoft.AspNetCore.Mvc.FromBody] ExamViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    using (_dbConnection = new SqlConnection(_connectionString))
                    {
                        using (SqlCommand command = new SqlCommand("SELECT * FROM Users", _dbConnection))
                        {

                            _dbConnection.Open();

                            SqlDataReader reader = command.ExecuteReader();


                            while (reader.Read())
                            {
                                var CurrentEmail = reader["Email"].ToString();
                                if (model.Email.Equals(CurrentEmail))
                                {
                                    ViewBag.DuplicateEmail = "Current Email is in use";
                                    throw new Exception();
                                }
                            }

                        }

                        AddUserToDb(model);
                    }
                    return RedirectToAction("Index");
                }
               
                return View("Index");
            }
            catch (Exception)
            {
                return View("Index");
            }
        }
    }
}