using CineWave.Data;
using CineWave.DTOs;
using CineWave.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineWave.Controllers
{
    public class CampanhaController : Controller

    {

        private readonly DataContext _dataContext;

        public CampanhaController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult MinhasCampanhasPage(int UserId)
        {

            var getCampanhas = _dataContext.Campanhas.Where(c => c.UserId == UserId).ToList();
            
            ViewBag.Campanhas = getCampanhas;
            return View();
        }

        public IActionResult PrevisoesPage()
        {
            var previsoes = _dataContext.Insights.ToList();

            ViewBag.Previsoes = previsoes;

            return View();
        }

        public IActionResult CadastrarCampanhaPage()
        {
            return View();
        }


        //TODO: Está certa a função? 
        public IActionResult DeletarCampanha(int id)
        {
            var getCampanha = _dataContext.Campanhas.Find(id);

            _dataContext.Update(getCampanha);
            _dataContext.SaveChanges();

            return RedirectToAction("MinhasCampanhasPage");
        }

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

        //TODO: Como vou relacionar a campanha com meu usuario na hora de cadastrar?
        public IActionResult CadastrarCampanha(CadastroCampanhaDTO request)
        {

            Campanha newCampanha = new Campanha
            {
                MovieTitle = request.MovieTitle,
                GenderMovie = request.GenderMovie,
                Budget = request.Budget,
                AgeRange = request.AgeRange,
                ReachExpectations = request.ReachExpectations
            };

            _dataContext.Campanhas.Add(newCampanha);
            _dataContext.SaveChanges();

            return RedirectToAction("CadastrarCampanha");
        }


    }
}
