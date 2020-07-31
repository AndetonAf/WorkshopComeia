using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshop.Data;
using Workshop.Models;

namespace Workshop.Controllers
{
    public class LoginController : Controller
    {

        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new Auth());
        }

        [HttpPost]
        public IActionResult Index([Bind("Usuario,Senha")] Auth auth)
        {
            string error = null;
            var login = _context.Login.Where(x => x.Usuario == auth.Usuario).FirstOrDefault();
            if(login != null)
            {
                if(BCrypt.Net.BCrypt.Verify(auth.Senha, login.Senha))
                {
                    HttpContext.Session.SetString("logado", "logado");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    error = "Usuario ou senha invalidos";
                }
            }
            else
            {
                error = "Usuario ou senha invalidos";
            }

            return View(new Auth() { Retorno = error } );
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/login");
        }

    }
}