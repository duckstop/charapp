using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharApp.Abstract;
using CharApp.Models;

namespace CharApp.Repositories
{
    public class BodyTypeRepository : IAttributeRepository<BodyTypeAttribute> //Repository af typen BodyTypeAttribute.
    {
        
            ApplicationDbContext _db = new ApplicationDbContext();

            public List<BodyTypeAttribute> GetAll()
            {
                return _db.BodyTypeAttributes.ToList();
            }

            public BodyTypeAttribute Find(int id)
            {
                return _db.BodyTypeAttributes.Find(id);
            }
        
    }
}