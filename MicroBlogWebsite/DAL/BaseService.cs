using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 基础数据操作类服务(增删改查基类)
    /// : IDisposable
    /// </summary>
    public class BaseService<T> where T : Models.BaseEntity, new()// new T();添加new()约束
    {
        //public Model.StudentContext DbContext { get; set; } = new Model.StudentContext();
        /// <summary>
        /// 实例化上下文
        /// </summary>
        public static Models.UserInfoContext DbContexts = new Models.UserInfoContext();


        /// <summary>
        /// async 异步  返回值Task   添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task AddAsync(T t)
        {
            //DbContext.Student
            //DbContext.Class
            DbContexts.Set<T>().Add(t);
            await DbContexts.SaveChangesAsync();//异步方法
        }
        //Task<返回值类型>，没有返回值就不写尖括号，save的时候需要异步

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int EditAsync(T t)
        {
            //DbContext.Student
            //DbContext.Class
            DbContexts.Entry(t).State = System.Data.Entity.EntityState.Modified;
            return DbContexts.SaveChanges();//异步方法
        }


        /// <summary>
        /// 真的删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int TrueRemoveAsync(int id)
        {
            var t = new T();//需要在上面添加new()约束
            t.Id = id;
            DbContexts.Entry(t).State = System.Data.Entity.EntityState.Modified;
            return DbContexts.SaveChanges();
        }


        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            //DbContext.Students.Where().wher().orderby().skip().take();
            //Track跟踪
            return DbContexts.Set<T>().Where(m => m.IsRemoved == false).AsNoTracking();
        }

        /// <summary>
        /// 条件查询  
        /// </summary>
        /// <param name="predicate">委托，兰姆达表达式</param>
        /// <returns></returns>
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        /// <summary>
        /// 查询单个数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public async Task<T> GetOneAsync(int id)
        //{
        //    return await GetAll().FirstAsunc(m => m.Id == id);
        //}
        public T GetOne(int id)
        {
            return GetAll().First(m => m.Id == id);
        }


        /// <summary>
        /// 伪删除，修改IsRemove状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int IsRemove(int id)
        {
            //var t = new T() { Id = id };
            var t = new T();
            t.Id = id;
            DbContexts.Entry(t).State = System.Data.Entity.EntityState.Unchanged;
            t.IsRemoved = false;
            return DbContexts.SaveChanges();
        }


        /// <summary>
        /// 实现接口
        /// </summary>
        //public void Dispose()
        //{
        //    DbContexts.Dispose();
        //}
    }
}
