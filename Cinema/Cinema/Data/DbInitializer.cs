using Cinema.Models;

namespace Cinema.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CinemaContext context)
        {
            context.Database.EnsureCreated();
            // Look for any persons.
            if (context.Persons.Any())
            {
                return;   // DB has been seeded
            }
            var persons = new Person[]
            {
                new Person{Name="Carson Alexander", BirthDate=DateTime.Parse("2005-09-01")},
                new Person{Name="Meredith Alonso", BirthDate=DateTime.Parse("2002-09-01")},
                new Person{Name="Arturo Anand", BirthDate=DateTime.Parse("2003-09-01")},
                new Person{Name="Gytis Barzdukas", BirthDate=DateTime.Parse("2002-09-01")},
                new Person{Name="Yan Li", BirthDate=DateTime.Parse("2002-09-01")},
                new Person{Name="Peggy Justice", BirthDate=DateTime.Parse("2001-09-01")},
                new Person{Name="Laura Norman", BirthDate=DateTime.Parse("2003-09-01")},
                new Person{Name="Nino Olivetto", BirthDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Person s in persons)
            {
                context.Persons.Add(s);
            }
            context.SaveChanges();
        }
    }
}
