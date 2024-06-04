using CineWave.Data;
using CineWave.DTOs;
using CineWave.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineWave.Controllers
{
    public class CampanhaController : Controller

    {
        //Descrição do core: Aqui é o CORE  da nossa aplicação é essa parte que futuramente vai permitir o usuário cadastrar uma campanha de um filme e
        //vai enviar para a IA e ver os insights das campanhas que a IA vai retoranr, ou seja vai ser a parte principal da nossa aplicação.

        private readonly DataContext _dataContext;

        public CampanhaController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult MinhasCampanhasPage()
        {
            var id = HttpContext.Session.GetInt32("_Id");

            var getCampanhas = _dataContext.Campanhas.Where(c => c.UserId == id).ToList();
            
            ViewBag.Campanhas = getCampanhas;
            return View();
        }

        // Aqui foi o método que não conseguimos resolver o problema, nn conseguimos pegar as infos do banco :(
        public IActionResult PrevisoesPage()
        {
            var getPrevisoes = _dataContext.Insights.Find(2);

            return View(getPrevisoes);
        }

        public IActionResult CadastrarCampanhaPage()
        {
            return View();
        }

        public IActionResult CadastrarCampanha(CadastroCampanhaDTO request)
        {
            var id = HttpContext.Session.GetInt32("_Id");

            var getUser = _dataContext.Usuarios.Find(id);

            if (getUser == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            Campanha newCampanha = new Campanha
            {
                MovieTitle = request.MovieTitle,
                GenderMovie = request.GenderMovie,
                Budget = request.Budget,
                AgeRange = request.AgeRange,
                ReachExpectations = request.ReachExpectations,
                UserId = getUser.Id
            };

            _dataContext.Campanhas.Add(newCampanha);
            _dataContext.SaveChanges();

            return RedirectToAction("MinhasCampanhasPage");
        }

        public IActionResult DeletarCampanha(int id)
        {
            var getCampanha = _dataContext.Campanhas.Find(id);

            _dataContext.Campanhas.Remove(getCampanha);
            _dataContext.SaveChanges();

            return RedirectToAction("MinhasCampanhasPage");
        }

        //Aqui eu chamo a view e passo de dados de determinada campanha
        public IActionResult EditarCampanhaPage(int id)
        {
            var getCampanha = _dataContext.Campanhas.Find(id);
            ViewBag.Campanhas = getCampanha;
            return View();
        }

        //eu preciso retornar a minha view EditarCampanha e no form chamo essa minha função
        public IActionResult EditarCampanha (int id, CadastroCampanhaDTO request)
        {
            var getCampanha = _dataContext.Campanhas.Find(id);

            getCampanha.MovieTitle = request.MovieTitle;
            getCampanha.GenderMovie = request.GenderMovie;
            getCampanha.AgeRange = request.AgeRange;
            getCampanha.Budget = request.Budget;
            getCampanha.ReachExpectations = request.ReachExpectations;

            _dataContext.Update(getCampanha);
            _dataContext.SaveChanges();

            return RedirectToAction("MinhasCampanhasPage");
        }

    }
}
