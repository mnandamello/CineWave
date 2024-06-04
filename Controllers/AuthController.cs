using CineWave.Data;
using CineWave.DTOs;
using CineWave.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineWave.Controllers
{
    public class AuthController : Controller
    {
        private readonly DataContext _dataContext;

        public AuthController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult LogarUsuario(LoginDTO request) 
        {

            var session = HttpContext.Session.GetInt32("_Id");
            var find = _dataContext.Usuarios.Find(session);
            if (find != null)
            {
                return RedirectToAction("PerfilPage", "Usuario");
            }

            var getUser = _dataContext.Usuarios.FirstOrDefault(x => x.UserEmail == request.UserEmail);
            if (getUser == null)
            {
                return NotFound();
            }
            if (!BCrypt.Net.BCrypt.Verify(request.PassWordHash, getUser.PassWordHash))
            {
                return NotFound();
            }
            if(getUser.IsActive == false)
            {
                getUser.IsActive = true;
            }

            HttpContext.Session.SetInt32("_Id", getUser.Id);
            HttpContext.Session.SetString("_email", getUser.UserEmail);

            return RedirectToAction("Index", "Home");
        }



        public IActionResult CadastroPage() 
        {
            return View();
        }

        public IActionResult CadastroUsuario(CadastroDTO request) 
        {
            var findUser = _dataContext.Usuarios.FirstOrDefault(x => x.UserEmail == request.UserEmail);
            if (findUser != null) 
            {
                return NotFound(request);
            }

            Usuario newUser = new Usuario
            {
                UserEmail    = request.UserEmail,
                UserName = request.UserName,
                PassWordHash = BCrypt.Net.BCrypt.HashPassword(request.PassWordHash),
            };

            _dataContext.Usuarios.Add(newUser);
            _dataContext.SaveChanges();

            return RedirectToAction("LoginPage");
        }
    }
}
