using Microsoft.EntityFrameworkCore;
using Syscode.Data;
using Syscode.Models;

namespace Syscode.Repositorio
{
	public class HomeRepositorio : IHomeRepositorio
	{
        private readonly BancoContext _bancoContext;
        public HomeRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<PopulacaoModel> Pesquisar(string name)
        {
            var resultados = _bancoContext.Population
           .FromSqlRaw("EXEC BuscaPopulacaoPorPais @Nome_Pais = {0}", name)
           .ToList();

            return resultados;
        }
    }
}
