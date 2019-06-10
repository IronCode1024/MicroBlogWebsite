using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MicroBlogManager
    {
        /// <summary>
        ///微博新鲜事
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.MicroBlog> GetNewThings()
        {
            var uifSvc = new DAL.MicroBlogService();

            var NewThingsEntity = uifSvc.GetNewThings();
            return NewThingsEntity;

        }

        /// <summary>
        ///微博精选文章
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.MicroBlog> GetNivo()
        {
            var uifSvc = new DAL.MicroBlogService();
            var GetNivoEntity = uifSvc.GetNivo();
            return GetNivoEntity;

        }
    }
}
