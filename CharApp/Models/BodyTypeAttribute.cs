using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CharApp.Models
{
    public class BodyTypeAttribute //Model for character attributten BodyType  
    {

        [Key] //Denne property er Key i BodyTypeAttributes tablen i databasen.
        public int BodyTypeID { get; set; }
        public string BodyType { get; set; }

    }
}