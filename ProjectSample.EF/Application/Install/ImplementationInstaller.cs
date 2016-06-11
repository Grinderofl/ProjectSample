using System;
using System.Data.Entity;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using ProjectSample.EF.Application.Install.Base;
using ProjectSample.EF.Core.Domain;
using ProjectSample.Infrastructure.Windsor.Extensions;

namespace ProjectSample.EF.Application.Install
{
    public class ImplementationInstaller : ProjectSampleInstaller
    {
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Action<Assembly> action = asm =>
                container.Register(
                    Classes.FromAssembly(asm)
                        .Where(t => t.Namespace != null && t.Namespace.EndsWith(".Impl"))
                        .LifestylePerWebRequest()
                        .WithServiceFirstInterface());
            action.VisitAssemblies(AssemblyConfiguration);

            container.Register(
                Component.For<AuthorizeAttribute>()
                );
            container.Register(
                Component.For<IUserStore<User>>().ImplementedBy<UserStore<User>>().LifestylePerWebRequest(),
                Component.For<ApplicationSignInManager>().LifestylePerWebRequest(),
                Component.For<ApplicationUserManager>().OnCreate((kernel, manager) =>
                {
                    manager.UserValidator = new UserValidator<User>(manager) {AllowOnlyAlphanumericUserNames = false};
                    manager.PasswordValidator = new PasswordValidator()
                    {
                        RequireDigit = false,
                        RequireLowercase = false,
                        RequireNonLetterOrDigit = false,
                        RequireUppercase = false,
                        RequiredLength = 1
                    };
                }).LifestylePerWebRequest(),
                Component.For<IAuthenticationManager>()
                    .UsingFactoryMethod((kernel, context) => HttpContext.Current.GetOwinContext().Authentication)
                    .LifestylePerWebRequest()

                );
        }
    }
}