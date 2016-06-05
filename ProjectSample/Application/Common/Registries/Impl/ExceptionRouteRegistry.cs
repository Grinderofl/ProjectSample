using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using NHibernate.Exceptions;
using ProjectSample.Infrastructure.Mvc.Registries;

namespace ProjectSample.Application.Common.Registries.Impl
{
    public class ExceptionRouteRegistry : IExceptionRouteRegistry
    {
        private readonly List<Type> _registry = new List<Type>()
        {
            typeof(SqlException),
            typeof(HttpException),
            typeof(GenericADOException)
        };


        public virtual bool HasResultForException(Exception exception) => _registry.Contains(exception.GetType());

        

        public virtual ActionResult CreateResultForException(Exception exception)
        {
            

            var result = GetResult(exception);
            return !string.IsNullOrWhiteSpace(result) ? new RedirectResult(result) : null;
        }

        private string GetResult(Exception exception)
        {
            if (exception.Message.Contains("Cannot open database"))
                return "/Boot/Migrations/Create";

            if (exception.Message.Contains("Invalid object name") 
                ||
                exception.Message.Contains("could not execute query"))
                return "/Boot/Migrations";

            return "";
        }
    }
}