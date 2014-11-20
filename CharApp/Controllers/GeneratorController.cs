using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using CharApp.Models;
using CharApp.Repositorys;
using Microsoft.AspNet.Identity;

namespace CharApp.Controllers
{
    public class GeneratorController : Controller //GeneratorController der tager sig af views der behandler genererede character objekter.
    {
        //Character repository deklareres.
        CharacterRepository CharRepos =  new CharacterRepository();
        
        //Index GET metode.
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }

        //Index POST metode.
        [HttpPost]
        public ActionResult GeneratedIndex()
        {
            //RandomGenerator objekt rand kaldes, og metoden .GenerateChar() der returnerer et nyt Character objekt, kaldes på rand.
            RandomGenerator rand = new RandomGenerator();

            return View(rand.GenerateChar());
        }
        //SaaveGenereatedCharacter GEt metode der tager integeren id ind.
        [HttpGet]
        public ActionResult SaveGeneratedCharacter(int id)
        {
            //character object findes i repositoriet v.h.a id.
            Character character = CharRepos.Find(id);
            return View(character);
        }

        //SaveGeneratedCharacter viewets POST metode der tager integeren id og et billede ind som parametere.
        [Authorize] // Bruger skal være logget ind for at gemme sin nye character.
        [HttpPost]
        public ActionResult SaveGeneratedCharacter(int id, HttpPostedFileBase image)
        {
            //character objekt findes i repository v.h.a id 
            Character character = CharRepos.Find(id);
            
            //Billede gemmes.
            string path = Server == null ? "" : Server.MapPath("~");
            character.SaveImage(image, path, "/UserUploads/CharacterImages/");
            
            //Nuværende brugers id bliver sat i characterns .owner property.
            var user = User.Identity.GetUserId();
            character.owner = user;

            //character gemmes.
            CharRepos.InsertOrUpdate(character);
            CharRepos.Save();

            return RedirectToAction("Index");


        }
        
        //Action metode der tager integeren id ind.
        public ActionResult DiscardGeneratedCharacter(int id)
        {
            //Nyligt generede character objekt slette.
            CharRepos.Delete(id);
            CharRepos.Save();

            return RedirectToAction("Index");
       }

    }
}