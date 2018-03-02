using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        static List<Usuario> listaDeUsuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Nome = "Usuario 1", Cpf = "44455566", Email = "usuario1email" },
            new Usuario { Id = 2, Nome = "Usuario 2", Cpf = "66655566", Email = "usuario2email" }
        };

        // GET: Usuario
        public ActionResult Index()
        {
            return View(listaDeUsuarios);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            Usuario user = listaDeUsuarios.Single(r => r.Id == id);
            return View(user);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here
                listaDeUsuarios.Add(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario user = listaDeUsuarios.Single(r => r.Id == id);
            return View(user);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                Usuario user = listaDeUsuarios.Single(r => r.Id == id);
                user.Nome = Request.Form["Nome"];
                user.Cpf = Request.Form["Cpf"];

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario user = listaDeUsuarios.Single(r => r.Id == id);
            return View(user);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Usuario user = listaDeUsuarios.Single(r => r.Id == id);
                listaDeUsuarios.Remove(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}