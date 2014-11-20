using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharApp.Abstract;
using CharApp.Models;

namespace CharApp.Repositories
{
    public class QuirkRepository : IAttributeRepository<QuirkAttribute> //Repository af typen QuirkAttribute
    {

        private ApplicationDbContext _db = new ApplicationDbContext();

        public List<QuirkAttribute> GetAll()
        {
            return _db.QuirkAttributes.ToList();
        }

        public QuirkAttribute Find(int id)
        {
            return _db.QuirkAttributes.Find(id);
        }
    }
}