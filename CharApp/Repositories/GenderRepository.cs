using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharApp.Abstract;
using CharApp.Models;

namespace CharApp.Repositories //Repository af typen GenderAttribute.
{
    public class GenderRepository : IAttributeRepository<GenderAttribute>
    {

        ApplicationDbContext _db = new ApplicationDbContext();

        public List<GenderAttribute> GetAll()
        {
            return _db.GenderAttributes.ToList();
        }

        public GenderAttribute Find(int id)
        {
            return _db.GenderAttributes.Find(id);
        }
    }
}