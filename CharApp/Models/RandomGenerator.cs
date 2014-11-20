using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharApp.Repositories;
using CharApp.Repositorys;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace CharApp.Models
{
    public class RandomGenerator //Model der indeholder metoder til at auto-generere Character objekter.
    {
        
       //Repositories deklareres.
       NameRepository NameRepos = new NameRepository();
       GenderRepository GenderRepos = new GenderRepository();
       BodyTypeRepository BodyTypeRepos = new BodyTypeRepository();
       QuirkRepository QuirkRepos = new QuirkRepository();
       CharacterRepository CharRepos = new CharacterRepository(); 
       
            
        //Metode til at generere vilkårlige integers imellem 1 og en forudbestemt parameter.
        public int GenerateRandomID(int ran)
        {
            Random random = new Random();

            int rnd = random.Next(1, ran);

            return rnd;
        }

        //Metode til at generere et vilkårlig Character objekt. 
        public Character GenerateChar()
        {
            //Lister bliver deklareret og fyldt med objekter fra repositories.
            IEnumerable<NameAttribute> nameAttributes = NameRepos.GetAll();
            IEnumerable<GenderAttribute> genderAttributes = GenderRepos.GetAll();
            IEnumerable<BodyTypeAttribute> bodyTypeAttributes = BodyTypeRepos.GetAll();
            IEnumerable<QuirkAttribute> quirkAttributes = QuirkRepos.GetAll();
            
            //String variabler fyldes med vilkårligt genereret indhold.
            string name = NameRepos.Find(GenerateRandomID(nameAttributes.Count())).Name;

            string gender = GenderRepos.Find(GenerateRandomID(genderAttributes.Count())).Gender;

            string bodyType = BodyTypeRepos.Find(GenerateRandomID(bodyTypeAttributes.Count())).BodyType;

            string quirk = QuirkRepos.Find(GenerateRandomID(quirkAttributes.Count())).Quirk;
                
            
            //Character objekt oprettes, og objektets properties fyldes med ovenstående variabler.
            Character genchar = new Character()
            {
                
                Name = name,
                Gender = gender,
                BodyType = bodyType,
                Quirk = quirk
            };


            
              //Character objekt gemmes da det skal kunne findes på sit CharID senere. 
              CharRepos.InsertOrUpdate(genchar);
              CharRepos.Save(); 
            
            
            return genchar;

        }

    }
}