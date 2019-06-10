using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class UserInfoContext:DbContext
    {
        /// <summary>
        /// 构造函数    Micro_blogWebsiteDB配置文件name  ConnectionString
        /// </summary>
        public UserInfoContext()
            : base("name=Micro_blogWebsiteDB")
        {
            Database.SetInitializer<UserInfoContext>(null);
        }

        public DbSet<UserInfo> UserInfo { get; set; }//用户表
        public DbSet<GoodFriend> GoodFriend { get; set; }//好友关系表
        public DbSet<MicroBlog> MicroBlog { get; set; }//微博表
        public DbSet<Grouping> Grouping { get; set; }//分组表
        public DbSet<Comment> Comment { get; set; }//评论表


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //去掉级联删除操作
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public override int SaveChanges()
        {
            //EF错误处理
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                var errorMessages =
                    exception.EntityValidationErrors
                        .SelectMany(validationResult => validationResult.ValidationErrors)
                        .Select(m => m.ErrorMessage);

                var fullErrorMessage = string.Join(", ", errorMessages);
                //记录日志
                //Log.Error(fullErrorMessage);
                var exceptionMessage = string.Concat(exception.Message, " 验证异常消息是：", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, exception.EntityValidationErrors);
            }

            //其他异常throw到上层
        }

    }
}
