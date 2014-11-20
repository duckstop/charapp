using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharApp.Models;

namespace CharApp.Abstract
{
    public interface ICharacterRepository //Interface der beskriver et Character repository og dennes operationer.
    {
        List<Character> GetAll();
        Character Find(int id);
        void Delete(int id);
        void InsertOrUpdate(Character character);
        void Save();
    }
}
