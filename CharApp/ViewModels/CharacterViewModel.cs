using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharApp.Models;

namespace CharApp.ViewModels
{
    public class CharacterViewModel //ViewModel der bruges til at parsse en liste af typen Character til et view.   
    {
        public List<Character> Characters { get; set; }
    }
}