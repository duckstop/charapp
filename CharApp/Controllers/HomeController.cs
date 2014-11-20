using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CharApp.Abstract;
using CharApp.Models;
using CharApp.Repositorys;
using CharApp.ViewModels;
using Microsoft.AspNet.Identity;

namespace CharApp.Controllers
{
    public class HomeController : Controller //HomeController der tager sig af Create, Edit og Delete metoder til at behandle Character objekter.
    {
        //Repository deklareres.
        CharacterRepository CharRepos =  new CharacterRepository();


        public ActionResult Index()
        {   
            //If sætning der bestemmer hvilket index view der vises, alt efter om en bruger er logget ind eller ej.
            if (User.Identity.GetUserId() == null)
            {
                return RedirectToAction("Index", "Generator");
            }

            else
            {
                List<Character> characters = CharRepos.GetAll();

                //ViewModel objekt oprettes, og properties sat.
                CharacterViewModel vm = new CharacterViewModel()
                {
                    Characters = characters  

                };
               
                return View(vm);


            }
        }
        //Create viewets GET metode
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //Create viewets POST metode der tager et Character objekt, og et uploadet billede ind fra GET viewet.
        [HttpPost]
        public ActionResult Create(Character character, HttpPostedFileBase image)
        {

            if (ModelState.IsValid)
            {   //Billedestien sættes i character objektet og gemmes.
                string path = Server == null ? "" : Server.MapPath("~");
                character.SaveImage(image, path, "/UserUploads/CharacterImages/");

                //Det nye character objekt gemmes, igennem et repository
                CharRepos.InsertOrUpdate(character);
                CharRepos.Save();

                return RedirectToAction("Index");
            }

            else
            {
                return View(character);
            }
        }
        //Edit viewets GET metode der tager integeren id ind som parameter.
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Ønskede character objekt findes via id
            Character character = CharRepos.Find(id);

           //If sætninger der sørger for at en bruger ikke kan edite character objekter han/hun ikke ejer.
           if (User.Identity.GetUserId() == null)
            {
                return View(character);
            }
            else if (User.Identity.GetUserId().Equals(character.owner))
            {
                return View(character);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        //Edit viewets POST metode der tager characterobjekt, og et billede ind.
        [HttpPost]
        public ActionResult Edit(Character character, HttpPostedFileBase image)
        {

            //Try/Catch her for at undgå fejl når view loades op
            try
            {

                if (ModelState.IsValid)
                {
                    //Billedestien sættes i character objektet og gemmes.
                    string path = Server == null ? "" : Server.MapPath("~");
                    character.SaveImage(image, path, "/UserUploads/CharacterImages/");
                    //
                    var user = User.Identity.GetUserId();
                    character.owner = user;

                    //Det nye character objekt gemmes, igennem et repository
                    CharRepos.InsertOrUpdate(character);
                    CharRepos.Save();

                    return RedirectToAction("Index");
                }

                else
                {
                    return View(character);
                }


            }

            catch (ArgumentException exception)
            {
                return View("Index");
            }
           
        }
        //Delete viewets GET metode der tager integeren id ind
        [HttpGet]
        public ActionResult Delete(int id)
        {
            //character objekt findes ved hjælp af id
            Character character = CharRepos.Find(id);

            return View(character);
        }
        //Delete viewets POST metode
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            //character objekt slettes fra repository v.h.a id og ændringerne gemmes
            CharRepos.Delete(id);
            CharRepos.Save();

            return RedirectToAction("Index");
        }


    }
}