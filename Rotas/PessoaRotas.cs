using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrimeiraApi.Models;

namespace PrimeiraApi.Rotas
{
    public static class PessoaRotas
    {
        public static List<Pessoa> Pessoas = new List<Pessoa>() {
            new Pessoa(Guid.NewGuid(), "Neymar"),
            new Pessoa(Guid.NewGuid(), "Cristiano"),
            new Pessoa(Guid.NewGuid(), "Messi")

            };
        public static void MapPessoaRotas(this WebApplication app)
        {
            app.MapGet("/pessoas", ()=> Pessoas);

            app.MapGet("/pessoas/{nome}", (string nome)=> Pessoas.Find( x=>x.Nome == nome));

            app.MapGet("/pessoa/{id}/{nome}", (Guid id, string nome) => Pessoas.Find(x=>x.Id == id));

            app.MapPost("/pessoas", (Pessoa pessoa)=> 
            {
                if (pessoa.Nome != "Lucas")

                    return Results.BadRequest( new {message = "o nome esta errado "});

                Pessoas.Add(pessoa); 
                return Results.Ok(pessoa);
            });

            app.MapPut("/pessoas/{id}", (Guid id, Pessoa pessoa)=>
             {
                var encontrado = Pessoas.Find(x => x.Id == id);
                if (encontrado == null)
                return Results.NotFound();

                encontrado.Nome = pessoa.Nome;
                return Results.Ok(encontrado);
            });

            app.MapDelete("/pessoas/{id}", (Guid id)=> {
                var pessoa = Pessoas.Find(x => x.Id == id);
                if (pessoa == null)
                return Results.NotFound();

                Pessoas.Remove(pessoa);
                return Results.Ok(new {message = "Pessoa removida com sucesso"});
            });
        }
    }
}