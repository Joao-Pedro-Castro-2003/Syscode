using Microsoft.AspNetCore.Mvc;
using Syscode.Models;
using Syscode.Repositorio;
using System.Diagnostics;

namespace Syscode.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepositorio _homeRepositorio;
        public HomeController(IHomeRepositorio homeRepositorio)
        {
            _homeRepositorio = homeRepositorio;
        }
        public IActionResult Index(string pais)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(pais))
                {
                    var resultado = _homeRepositorio.Pesquisar(pais);
                    if (resultado.Any())
                    {
                        TempData["MensagemSucesso"] = "Pesquisa realizada com sucesso!";
                        return View(resultado);
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Esse país não está em nossa base ou não existe";
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao realizar a pesquisa. Erro detalhado: {ex.Message}";
                throw;
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}