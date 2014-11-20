using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CharApp.Models
{
    public class GenderAttribute //Model for character attributten Gender.
    {
        [Key]//Denne property er Key i GenderAttributes tablen i databasen.
        public int GenderID { get; set; }

        public string Gender { get; set; }
    }
}