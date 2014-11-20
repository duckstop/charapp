using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CharApp.Models
{
    public class QuirkAttribute //Model for character attributten Quirk
    {
        [Key]//Denne property er Key i QurikAttributes tablen i databasen.
        public int QuirkID { get; set; }

        public string Quirk { get; set; }
    }
}