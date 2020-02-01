using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetGrooming.Data;
using PetGrooming.Models;
using System.Diagnostics;


namespace PetGrooming.Controllers
{
    public class SpeciesController : Controller
    {
        private PetGroomingContext db = new PetGroomingContext();

        //TODO: Each line should be a separate method in this class
        // List
        public ActionResult List()
        {
            var species = db.Species.SqlQuery("Select * from species").ToList();
            return View(species);
            
        }

        // Show
        public ActionResult Show(int id)
        {
           
            Species species = db.Species.SqlQuery("select * from species where speciesid=@SpeciesID", new SqlParameter("@SpeciesID", id)).FirstOrDefault();

            return View(species);
        }
        // Add
        [HttpPost]
        public ActionResult Add(string SpeciesName)
        {
            //creating insert query in parametererized way
            string query = "insert into species (SpeciesName) values (@SpeciesName)";

            //parameters it can in collection if parameters are more than one.
            SqlParameter sqlparams = new SqlParameter("@SpeciesName", SpeciesName);

            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        }

        public ActionResult Add()
        {
            //getting the list for the species
            List<Species> species = db.Species.SqlQuery("select * from Species").ToList();

            return View(species);
        }

        // Update
        //GET : Update
        public ActionResult Update(int id)
        {
           //display the species that has been selected
            Species species = db.Species.SqlQuery("select * from species where speciesid=@SpeciesID", new SqlParameter("@SpeciesID", id)).FirstOrDefault();
            return View(species);
        }

        [HttpPost]
        public ActionResult Update(int id, string SpeciesName)
        {
            //allow the user to update the species.

            //query to update in parameters passing way.
            string query = "update species set SpeciesName = @SpeciesName where SpeciesID = @SpeciesID";
            SqlParameter[] sqlparams = new SqlParameter[2];
            sqlparams[0] = new SqlParameter("@SpeciesName", SpeciesName);
            sqlparams[1] = new SqlParameter("@SpeciesID", id);

            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }

        
        public ActionResult Delete(int id)
        {
            //creating and passing the delete query to database to delete particular species.
            string query = "delete from species where speciesid = @id";
            SqlParameter sqlparam = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, sqlparam);
            return RedirectToAction("List");
        }
        
    }
}