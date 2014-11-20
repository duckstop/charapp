using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CharApp.Models
{
    public class NameAttribute //Model for character attributten Name
    {
        [Key]//Denne property er Key i NameAttributes tablen i databasen.
        public int NameID { get; set; }

        public string Name { get; set; }
    }
}