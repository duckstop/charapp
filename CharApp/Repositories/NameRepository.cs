using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharApp.Abstract;
using CharApp.Models;

namespace CharApp.Repositories
{
    public class NameRepository : IAttributeRepository<NameAttribute> //Repository af typen NameAttribute
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        public List<NameAttribute> GetAll()
        {
            return _db.NameAttributes.ToList();
        }

        public NameAttribute Find(int id)
        {
            return _db.NameAttributes.Find(id);
        }
    }
}