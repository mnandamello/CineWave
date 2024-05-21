using CineWave.Data;
using CineWave.DTOs;
using CineWave.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineWave.Controllers
{
    public class UsuarioController : Controller
    {
         
        private readonly DataContext _dataContext;

        public UsuarioController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //TODO: Confirmar se esta certo
        public IActionResult PerfilPage()
        {
            var id = HttpContext.Session.GetInt32("_Id");

            var getUser = _dataContext.Usuarios.Find(id);
            ViewBag.Usuario = getUser;

            var numeroDeCampanhas = _dataContext.Campanhas.Count(c => c.UserId == id);//usei o count() pq pego o numero de elementos
            ViewBag.NumeroDeCampanhas = numeroDeCampanhas;
            return View();
        }

        //nn implementado no front nessa sprint, em avaliação para ver se faz sentido ter
        public IActionResult EditarPerfil(int id, string newPassword, CadastroDTO request) 
        {
            var getUser = _dataContext.Usuarios.Find(id);
            if (BCrypt.Net.BCrypt.Verify(request.PassWordHash, getUser.PassWordHash)) 
            {
                getUser.PassWordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                getUser.UserEmail = request.UserEmail;
                getUser.UserName = request.UserName;
            }

            _dataContext.Update(getUser);
            _dataContext.SaveChanges();

            return RedirectToAction("PerfilPage");
        }

        //foi colocado a rota pois o sistema estava se perdendo
        [HttpPost]
        [Route("Usuario/DeletarPerfil")]
        public IActionResult DesativarPerfil()
        {
            var id = HttpContext.Session.GetInt32("_Id");
            if (id == null)
            {
                return RedirectToAction("LoginPage", "Auth");
            }

            var getUser = _dataContext.Usuarios.Find(id);
            if (getUser != null)
            {
                getUser.IsActive = false;
                _dataContext.Update(getUser);
                _dataContext.SaveChanges();
                HttpContext.Session.Clear();
            }

            return RedirectToAction("LoginPage", "Auth");
        }
    }
}
