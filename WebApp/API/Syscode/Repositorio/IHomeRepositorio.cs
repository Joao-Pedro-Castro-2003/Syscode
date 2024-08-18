using Syscode.Models;

namespace Syscode.Repositorio
{
	public interface IHomeRepositorio
	{
		List<PopulacaoModel> Pesquisar(string name);
	}
}
