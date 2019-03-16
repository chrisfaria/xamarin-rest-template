using System;
using Autofac;
using xTemplate.Mobile.Contracts.Repository;
using xTemplate.Mobile.Contracts.Services.Data;
using xTemplate.Mobile.Contracts.Services.General;
using xTemplate.Mobile.Services.Data;
using xTemplate.Mobile.Services.General;
//using xTemplate.Mobile.Services.General;
using xTemplate.Mobile.ViewModels;

namespace xTemplate.Mobile.Bootstrap
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<HomeViewModel>(); 
            builder.RegisterType<RegistrationViewModel>();

            //services - data
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();

            //services - general
            builder.RegisterType<ConnectionService>().As<IConnectionService>();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();

            //General
            //builder.RegisterType<GenericRepository>().As<IGenericRepository>();

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
