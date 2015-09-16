using NTierApplications.Data.Context;
using NTierApplications.Data.Initializers;
using NTierApplications.Domain.Entities;

namespace NTierApplications.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NTierApplicationsDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        // Uncomment out the data and methods to generate seed data in the database.
        protected override void Seed(NTierApplicationsDataContext context)
        {
            #region Department

            //context.Departments.Add(new Department()
            //{
            //    Name = "Accounting"
            //});

            //context.Departments.Add(new Department()
            //{
            //    Name = "Finance"
            //});

            //context.Departments.Add(new Department()
            //{
            //    Name = "Customer Service"
            //});

            //context.Departments.Add(new Department()
            //{
            //    Name = "IT"
            //});

            //context.Departments.Add(new Department()
            //{
            //    Name = "Sales"
            //});

            #endregion

            //context.SaveChanges();

            #region Location

            //context.Locations.Add(new Location()
            //{
            //    Name = "Montreal Warehouse",
            //    Address = "P.O. Box 908, 4379 Ipsum St.",
            //    City = "Montreal",
            //    State = "QC",
            //    Zip = 13245
            //});
            //context.Locations.Add(new Location()
            //{
            //    Name = "Aksehir Factory",
            //    Address = "3445 Nunc Av.",
            //    City = "Aksehir",
            //    State = "KN",
            //    Zip = 61883
            //});
            //context.Locations.Add(new Location()
            //{
            //    Name = "Chicago Office",
            //    Address = "123 Main St.",
            //    City = "Chicago",
            //    State = "IL",
            //    Zip = 60606
            //});

            #endregion

            //context.SaveChanges();

            #region NamePrefix

            //context.NamePrefixes.Add(new NamePrefix() { Prefix = "Mr." });
            //context.NamePrefixes.Add(new NamePrefix() { Prefix = "Mrs." });
            //context.NamePrefixes.Add(new NamePrefix() { Prefix = "Miss" });

            #endregion

            //context.SaveChanges();

            #region Skill

            //context.Skills.Add(new Skill() { Name = "Microsoft Word" });
            //context.Skills.Add(new Skill() { Name = "Microsoft Excel" });
            //context.Skills.Add(new Skill() { Name = "Microsoft PowerPoint" });
            //context.Skills.Add(new Skill() { Name = "Microsoft Access" });
            //context.Skills.Add(new Skill() { Name = "Microsoft SharePoint" });
            //context.Skills.Add(new Skill() { Name = "Microsoft SQL Server" });
            //context.Skills.Add(new Skill() { Name = "C#" });
            //context.Skills.Add(new Skill() { Name = "ASP.NET MVC" });
            //context.Skills.Add(new Skill() { Name = "ASP.NET WebForms" });
            //context.Skills.Add(new Skill() { Name = "Visual Basic" });

            #endregion

            //context.SaveChanges();

            #region Employee

            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Declan",
            //    LastName = "Oneal",
            //    JobTitle = "lorem eu",
            //    Email = "nec@ac.ca",
            //    WebSite = "interdum.",
            //    PhoneNumber = "1-643-629-4425",
            //    DepartmentId = 3,
            //    NamePrefixId = 3,
            //    LocationId = 1,
            //    Notes =
            //        "Donec sollicitudin adipiscing ligula. Aenean gravida nunc sed pede. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel arcu eu odio tristique pharetra."
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Armando",
            //    LastName = "Gillespie",
            //    JobTitle = "arcu et",
            //    Email = "imperdiet.dictum.magna@loremeumetus.org",
            //    WebSite = "eu,",
            //    PhoneNumber = "1-500-679-6639",
            //    DepartmentId = 2,
            //    NamePrefixId = 2,
            //    LocationId = 1,
            //    Notes =
            //        "Duis mi enim, condimentum eget, volutpat ornare, facilisis eget, ipsum. Donec sollicitudin adipiscing ligula. Aenean"
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Peter",
            //    LastName = "Love",
            //    JobTitle = "risus quis",
            //    Email = "sed@Fuscediam.net",
            //    WebSite = "In",
            //    PhoneNumber = "1-362-859-0436",
            //    DepartmentId = 2,
            //    NamePrefixId = 1,
            //    LocationId = 3,
            //    Notes = "ante dictum cursus. Nunc mauris elit, dictum eu, eleifend nec, malesuada"
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Jolene",
            //    LastName = "Reyes",
            //    JobTitle = "lacinia vitae,",
            //    Email = "Nunc@Vivamusnonlorem.edu",
            //    WebSite = "varius.",
            //    PhoneNumber = "1-336-560-7031",
            //    DepartmentId = 1,
            //    NamePrefixId = 1,
            //    LocationId = 1,
            //    Notes = "id, mollis nec, cursus a, enim. Suspendisse aliquet, sem ut"
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Macy",
            //    LastName = "Fernandez",
            //    JobTitle = "Donec feugiat",
            //    Email = "Cras@anteblandit.net",
            //    WebSite = "facilisis",
            //    PhoneNumber = "1-532-645-4195",
            //    DepartmentId = 3,
            //    NamePrefixId = 3,
            //    LocationId = 3,
            //    Notes = "mauris elit, dictum eu, eleifend nec, malesuada ut, sem. Nulla interdum. Curabitur dictum. Phasellus"
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Benjamin",
            //    LastName = "Park",
            //    JobTitle = "eu erat",
            //    Email = "non@scelerisquemollis.com",
            //    WebSite = "dolor.",
            //    PhoneNumber = "1-763-294-2092",
            //    DepartmentId = 2,
            //    NamePrefixId = 2,
            //    LocationId = 2,
            //    Notes =
            //        "vitae, aliquet nec, imperdiet nec, leo. Morbi neque tellus, imperdiet non, vestibulum nec, euismod in, dolor. Fusce feugiat. Lorem ipsum"
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Karyn",
            //    LastName = "Padilla",
            //    JobTitle = "Mauris magna.",
            //    Email = "inceptos@rutrummagnaCras.org",
            //    WebSite = "tempus",
            //    PhoneNumber = "1-735-145-2571",
            //    DepartmentId = 1,
            //    NamePrefixId = 1,
            //    LocationId = 3,
            //    Notes =
            //        "Proin ultrices. Duis volutpat nunc sit amet metus. Aliquam erat volutpat. Nulla facilisis. Suspendisse commodo"
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Brynn",
            //    LastName = "York",
            //    JobTitle = "vel, vulputate",
            //    Email = "ante@Mauris.co.uk",
            //    WebSite = "posuere",
            //    DepartmentId = 3,
            //    NamePrefixId = 2,
            //    LocationId = 1,
            //    PhoneNumber = "1-563-400-4118",
            //    Notes = "Cras eu tellus eu augue porttitor interdum. Sed auctor odio a purus. Duis elementum, dui quis"
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Alice",
            //    LastName = "Wilcox",
            //    JobTitle = "ipsum. Suspendisse",
            //    Email = "lectus@elitEtiamlaoreet.com",
            //    WebSite = "vulputate,",
            //    PhoneNumber = "1-901-523-1427",
            //    DepartmentId = 2,
            //    NamePrefixId = 1,
            //    LocationId = 3,
            //    Notes =
            //        "adipiscing lacus. Ut nec urna et arcu imperdiet ullamcorper. Duis at lacus. Quisque purus sapien, gravida non, sollicitudin a, malesuada id,"
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Elaine",
            //    LastName = "Skinner",
            //    JobTitle = "Sed nec",
            //    Email = "at.risus.Nunc@felisadipiscing.edu",
            //    WebSite = "Sed",
            //    PhoneNumber = "1-767-571-1886",
            //    DepartmentId = 5,
            //    NamePrefixId = 2,
            //    LocationId = 3,
            //    Notes = "auctor ullamcorper, nisl arcu iaculis enim, sit amet ornare lectus justo eu arcu. Morbi sit amet massa."
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Belle",
            //    LastName = "Chapman",
            //    JobTitle = "at, velit.",
            //    Email = "est.tempor.bibendum@natoquepenatibus.edu",
            //    WebSite = "ornare.",
            //    PhoneNumber = "1-613-947-7547",
            //    DepartmentId = 2,
            //    NamePrefixId = 2,
            //    LocationId = 2,
            //    Notes =
            //        "mauris. Integer sem elit, pharetra ut, pharetra sed, hendrerit a, arcu. Sed et libero. Proin mi. Aliquam gravida mauris"
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Alexandra",
            //    LastName = "Mccormick",
            //    JobTitle = "Phasellus ornare.",
            //    Email = "et.pede.Nunc@Integertinciduntaliquam.com",
            //    WebSite = "sed",
            //    PhoneNumber = "1-611-589-4271",
            //    DepartmentId = 1,
            //    NamePrefixId = 1,
            //    LocationId = 1,
            //    Notes =
            //        "et, euismod et, commodo at, libero. Morbi accumsan laoreet ipsum. Curabitur consequat, lectus sit amet luctus vulputate, nisi sem semper erat, in consectetuer ipsum nunc id"
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Zenia",
            //    LastName = "House",
            //    JobTitle = "diam dictum",
            //    Email = "lobortis.mauris.Suspendisse@euenimEtiam.edu",
            //    WebSite = "Nunc",
            //    PhoneNumber = "1-444-880-0564",
            //    DepartmentId = 1,
            //    NamePrefixId = 2,
            //    LocationId = 3,
            //    Notes =
            //        "ac arcu. Nunc mauris. Morbi non sapien molestie orci tincidunt adipiscing. Mauris molestie pharetra nibh. Aliquam ornare, libero at auctor ullamcorper, nisl arcu"
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "William",
            //    LastName = "Walsh",
            //    JobTitle = "orci tincidunt",
            //    Email = "mus.Donec@arcuNunc.co.uk",
            //    WebSite = "Aenean",
            //    PhoneNumber = "1-161-945-9337",
            //    DepartmentId = 3,
            //    NamePrefixId = 2,
            //    LocationId = 1,
            //    Notes =
            //        "eget mollis lectus pede et risus. Quisque libero lacus, varius et, euismod et, commodo at, libero. Morbi accumsan laoreet ipsum. Curabitur consequat, lectus sit"
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Arden",
            //    LastName = "Daugherty",
            //    JobTitle = "vehicula et,",
            //    Email = "cursus@congueelit.ca",
            //    WebSite = "Phasellus",
            //    PhoneNumber = "1-314-444-5694",
            //    DepartmentId = 1,
            //    NamePrefixId = 1,
            //    LocationId = 2,
            //    Notes =
            //        "erat. Etiam vestibulum massa rutrum magna. Cras convallis convallis dolor. Quisque tincidunt pede ac urna. Ut tincidunt vehicula risus. Nulla eget metus eu erat semper rutrum. Fusce dolor quam, elementum"
            //});
            //context.Employees.Add(new Employee()
            //{
            //    FirstName = "Jacqueline",
            //    LastName = "Shaw",
            //    JobTitle = "pede, ultrices",
            //    Email = "eu@scelerisquescelerisquedui.net",
            //    WebSite = "libero",
            //    PhoneNumber = "1-983-621-0094",
            //    DepartmentId = 1,
            //    NamePrefixId = 2,
            //    LocationId = 1,
            //    Notes =
            //        "arcu imperdiet ullamcorper. Duis at lacus. Quisque purus sapien, gravida non, sollicitudin a, malesuada id, erat. Etiam vestibulum massa"
            //});

            #endregion

            //context.SaveChanges();

        }
    }
}
