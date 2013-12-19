using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using SimpleBlog.Core.Data;
using SimpleBlog.Core.Entities;
using SimpleBlog.Services;

namespace SimpleBlog.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            _kernel.Bind<IDbContextFactory>().To<DbContextFactory>().InSingletonScope();
            _kernel.Bind<IPostsRepository>().To<PostsRepository>();
            _kernel.Bind<ICategoriesRepository>().To<CategoriesRepository>();
            _kernel.Bind<ITagsRepository>().To<TagsRepository>();
            _kernel.Bind<IPostViewModelCreator>().To<PostViewModelCreator>();
            _kernel.Bind<IWidgetsModelCreator>().To<WidgetsModelCreator>();
            _kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
            _kernel.Bind<IMapper>().To<Mapper>();
            _kernel.Bind<IAdminService>().To<AdminService>();

            _kernel.Bind<IRepository<Post>>().To<Repository<Post>>();
            _kernel.Bind<IRepository<Category>>().To<Repository<Category>>();
            _kernel.Bind<IRepository<Tag>>().To<Repository<Tag>>();
        }
    }
}