using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiraApi.Rotas
{
    public static class PessoaRotas
    {
        public static void MapPessoaRotas(this WebApplication app)
        {
            app.MapGet("/hello-world", ()=> new {
                Nome = "Pablo"
            });
        }
    }
}