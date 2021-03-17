using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ETAPA3.Models;
using Microsoft.AspNetCore.Http;

namespace ETAPA3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contato()
        {
            return View();
        }
        
        
        [HttpPost]
         public IActionResult Confirmacao(UsuarioPedido usuario)
        {
            UsuarioPedidoDados usuarioDB = new UsuarioPedidoDados();
            usuarioDB.InserirUser(usuario); 
            ViewBag.Mensagem="Parabéns! seu pedido foi enviado com sucesso!";
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        
        
        [HttpPost]
        public IActionResult Login(UsuarioLogin usuario)
        {
            UsuarioLoginDados usuarioDB = new UsuarioLoginDados();
            UsuarioLogin usuarioSessao = usuarioDB.TesteLogin(usuario);

            if(usuarioSessao != null) 
            {
                ViewBag.Mensagem="Você está logado!";
                HttpContext.Session.SetString("LoginUsuario", usuarioSessao.Login);

                 return View();
            } else {
                ViewBag.Mensagem = "Falha no login!";
                return View();
            }
        }
             public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

         public IActionResult ListarPedido()
        {
            if(HttpContext.Session.GetInt32("LoginUsuario") == null)
                return RedirectToAction("Login");

            UsuarioPedidoDados usuarioDB = new UsuarioPedidoDados();
            List<UsuarioPedido> Lista = usuarioDB.ListarUser();
            return View(Lista);
        }
        public IActionResult RemoverUser(string Email)
        {
            if(HttpContext.Session.GetString("LoginUsuario") == null)
                return RedirectToAction("Login");
            UsuarioPedidoDados usuarioDB = new UsuarioPedidoDados();
            usuarioDB.RemoverUser(Email);
            return RedirectToAction("ListarPedido");           
        }

        public IActionResult Galeria()
        {
            return View();
        }
        public IActionResult Noticias()
        {
            return View();
        }
        public IActionResult Produtos()
        {
            return View();
        }
        public IActionResult Produto1()
        {
            return View();
        }
        public IActionResult Produto2()
        {
            return View();
        }
        public IActionResult Produto3()
        {
            return View();
        }
        public IActionResult Produto4()
        {
            return View();
        }
        public IActionResult Projetos()
        {
            return View();
        }
        public IActionResult QuemSomos()
        {
            return View();
        }
           

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
