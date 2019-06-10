using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MicroBlogService : BaseService<Models.GoodFriend>
    {
        /// <summary>
        ///微博新鲜事
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.MicroBlog> GetNewThings()
        {
            var NewThingsEntity = (from u in DbContexts.MicroBlog orderby u.CreateTime descending select u).ToList();
            return NewThingsEntity;
        }


        /// <summary>
        ///微博精选文章
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.MicroBlog> GetNivo()
        {
            var GetNivoEntity = (from u in DbContexts.MicroBlog orderby u.Points_number descending select u).ToList();
            return GetNivoEntity;

        }
    }
}
