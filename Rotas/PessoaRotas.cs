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
                Pessoas.Add(pessoa); return pessoa;
            });
        }
    }
}