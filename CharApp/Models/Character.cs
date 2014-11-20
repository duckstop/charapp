using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CharApp.Models
{
    public class Character // Model for Character objekt. 
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BodyType { get; set; }
        public string Quirk { get; set; }
        public string imagePath { get; set; }
        public string owner { get; set; }

        [Key] //Denne property er Key i Characters table i databasen.
        public int CharID { get; set; }

        //Metode der gemmer billede og sætter Character.imagePath til korrekte sti.
        public void SaveImage(

            HttpPostedFileBase image,
            String serverPath,
            String pathToFile)
        {
            if (image == null) return;

            string createFileWithName =
                Guid.NewGuid().ToString();

            ImageModel.ResizeAndSave(serverPath + pathToFile,
                createFileWithName, image.InputStream, 200);

            imagePath = pathToFile + createFileWithName + ".jpg";
        }

    }
}