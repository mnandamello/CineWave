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
        public IActionResult PerfilPage(int id)
        {
            var getUser = _dataContext.Usuarios.Find(id);
            ViewBag.Usuario = getUser;

            var numeroDeCampanhas = _dataContext.Campanhas.Count(c => c.UserId == id);
            ViewBag.NumeroDeCampanhas = numeroDeCampanhas;
            return View();
        }

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

        public IActionResult DeletarPerfil(int id)
        {
            var getUser = _dataContext.Usuarios.Find(id);
            getUser.IsActive = false;

            _dataContext.Update(getUser);
            _dataContext.SaveChanges();
            return RedirectToAction("PerfilPage");
        }
    }
}
