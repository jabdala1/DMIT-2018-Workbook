using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

// You can learn about Database Intialization Strategies in EF6 via
// http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx

namespace WebApp.Admin
{
    /// <summary>
    /// Provide functionality for setting up the database for the ApplicationDbContext.
    /// The specific functionality is to create database if it does not exist
    /// </summary>
    public class SecurityDbContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // To "seed" a database is to provide it wiht some initial data
            // when the database is created.

            #region Seed the security roles
            // Make the Identity's BLL instance to help us manage roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //The RoleManager<T> nad RoleStore<T> are BLL classes that give flexibility to the design/structure of how we're using Asp.NET Identity.
            // The Identity Role is an Entity class that represents a security role.

            // TODO: Move these hard-coded security roles to Web.config
            roleManager.Create(new IdentityRole { Name = "Administrators" });
            roleManager.Create(new IdentityRole { Name = "Registered Users" });
            #endregion

            #region Seed the users
            #endregion
            // Note: Keep this call to the base class so it can do its seeding work
            base.Seed(context);
        }
    }
}