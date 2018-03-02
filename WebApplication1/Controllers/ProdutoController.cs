using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProdutoController : Controller
    {
        static List<Produto> listaDeProdutos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Tomato Soup", Categoria = "Groceries", Preco = 1 },
            new Produto { Id = 2, Nome = "Yo-yo", Categoria = "Toys", Preco = 3.75M },
            new Produto { Id = 3, Nome = "Hammer", Categoria = "Hardware", Preco = 16.99M }
        };

        // GET: Produto
        public ActionResult Index()
        {
            return View(listaDeProdutos);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            Produto prod = listaDeProdutos.Single(r => r.Id == id);
            return View(prod);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            try
            {
                // TODO: Add insert logic here
                listaDeProdutos.Add(produto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            Produto prod = listaDeProdutos.Single(r => r.Id == id);

            return View(prod);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Produto prod = listaDeProdutos.Single(r => r.Id == id);
               // prod.Id = Request.Form["Id"];
                prod.Nome = Request.Form["Nome"];
                prod.Categoria = Request.Form["Categoria"];
               // prod.Preco = Request.Form["Preco"];

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            Produto prod = listaDeProdutos.Single(r => r.Id == id);
            return View(prod);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Produto prod = listaDeProdutos.Single(r => r.Id == id);
                listaDeProdutos.Remove(prod);
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}