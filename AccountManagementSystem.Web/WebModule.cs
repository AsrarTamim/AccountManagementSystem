using AccountManagementSystem.Infrastructure.Utilities;
using AccountManagementSystem.Infrustructure;
using AccountManagementSystem.Infrustructure.Repositories;
using AccountManagemnetSystem.Domain;
using AccountManagemnetSystem.Domain.Repositories;
using AccountManagemnetSystem.Domain.Utilities;
using Autofac;
using System.ComponentModel;

namespace AccountManagementSystem.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public WebModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                 .InstancePerLifetimeScope();
            builder.RegisterType<AccountRepository>()
                   .As<IAccountRepository>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>()
                   .As<IApplicationUnitOfWork>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<EmailUtility>().As<IEmailUtility>()
                .InstancePerLifetimeScope(); 




            base.Load(builder);
        }
    }
}
