using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.DAL.Entities;
using System.Data.SqlClient;
using System.Data;

namespace MVC.DAL.DAL
{
    public class BlogRepository : BaseRepository<BlogEntity, BlogContext, int>
    {
        public BlogRepository() : base()
        {
        }

        public override BlogEntity Get(int id)
        {
            try
            {
                BlogEntity blogEntity = context.Set<BlogEntity>().Where(x => x.BlogId == id).FirstOrDefault();
                return blogEntity;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}