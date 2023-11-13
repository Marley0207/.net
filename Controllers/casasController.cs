using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test1.Models;
using Newtonsoft.Json;

namespace Test1.Controllers
{
    public class casasController : Controller
    {
        public List<Venta_Casas> lista_casas = null;
        public casasController()
        {
            var myJsonString = System.IO.File.ReadAllText("Models/casas.json");
            lista_casas = JsonConvert.DeserializeObject<List<Venta_Casas>>(myJsonString);
        }

        public IActionResult Index()
        {
            return View(lista_casas);
        }
        public IActionResult detalles(int id)
        {
            foreach(var item in lista_casas)
            {
               if (item.id == id){ 
                return View(item);
               }
            }
            return View();
        }
        public IActionResult search(string name)
        {
            List<Venta_Casas> casaEncontrada = new List<Venta_Casas>();

            foreach(var item in lista_casas)
            {
                if(item.nombre.ToUpper().Contains(name.ToUpper()))
                {
                    casaEncontrada.Add(item);
                }
            }
            bool? verTodo = casaEncontrada.Count >= 1 ? (bool?)true : null;
            ViewData["verTodo"] = verTodo;
            return View("index", casaEncontrada);
        }
    }
}