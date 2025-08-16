using Veterinaria.Models;
namespace Veterinaria.Data
{
    public class DbInitializer
    {
        public static void Initialize(VetContext context)
        {
            context.Database.EnsureCreated();

            if (context.TiposAnimais.Any())
            {
                return;
            }

            var tiposAnimais = new TipoAnimal[]
            {
                new TipoAnimal { Especie = "Cachorro", Descricao = "Animal de estimação popular" },
                new TipoAnimal { Especie = "Gato", Descricao = "Outro animal de estimação comum" },
                new TipoAnimal { Especie = "Pássaro", Descricao = "Ave doméstica" }
            };
            foreach (var tipo in tiposAnimais)
            {
                context.TiposAnimais.Add(tipo);
            }
            context.SaveChanges();

            var animais = new Animal[]
            {
                new Animal { Nome = "Rex", TipoAnimal = tiposAnimais[0], DtNascimento = new DateTime(2020, 1, 1), Raca = "Labrador", Cor = "Amarelo", Peso = 30.5f, Altura = 60.0f },
                new Animal { Nome = "Mia", TipoAnimal = tiposAnimais[1], DtNascimento = new DateTime(2019, 5, 15), Raca = "Siamês", Cor = "Cinza", Peso = 4.5f, Altura = 25.0f }
            };
            foreach (var animal in animais)
            {
                context.Animais.Add(animal);
            }
            context.SaveChanges();

            var vacinas = new Vacina[]
            {
                new Vacina { Nome = "Vacina Antirrábica", DataAplicacao = new DateTime(2023, 1, 10), AnimalId = animais[0].Id },
                new Vacina { Nome = "Vacina V8", DataAplicacao = new DateTime(2023, 2, 20), AnimalId = animais[0].Id },
                new Vacina { Nome = "Vacina V10", DataAplicacao = new DateTime(2023, 3, 15), AnimalId = animais[1].Id }
            };
            foreach (var vacina in vacinas)
            {
                context.Vacinas.Add(vacina);
            }
            context.SaveChanges();
        }
    }
}
