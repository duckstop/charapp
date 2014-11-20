using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CharApp.Abstract;
using CharApp.Models;

namespace CharApp.Repositorys
{
    public class CharacterRepository : ICharacterRepository //Repository af typen Character.
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        
        public List<Character> GetAll()
        {
            return _db.Characters.ToList();
        }

        public Character Find(int id)
        {
            return _db.Characters.Find(id);
        }

        public void Delete(int id)
        {
            _db.Characters.Remove(_db.Characters.Find(id));
        }

        public void InsertOrUpdate(Character character)
        {
            
            if (character.CharID == default(int))
            {
                _db.Characters.Add(character);
            }
            else
            {
                _db.Entry(character).State = EntityState.Modified;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        } 


    }
}