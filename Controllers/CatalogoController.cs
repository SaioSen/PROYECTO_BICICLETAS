using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PROYECTO_BICICLETAS.Models;
using Microsoft.EntityFrameworkCore;
using PROYECTO_BICICLETAS.Data;
using Microsoft.AspNetCore.Identity;

namespace PROYECTO_BICICLETAS.Controllers
{
    public class CatalogoController: Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CatalogoController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var productos = from o in _context.Productos select o;
            return View(await productos.ToListAsync());
        }

         public IActionResult Catalogo()
        {
            //listar
            var listarProductos = _context.Productos.ToList();
            return View(listarProductos);
            //listar
        
        }

        public IActionResult Catalogo2()
        {
            //listar
            var listarProductos = _context.Productos.ToList();
            return View(listarProductos);
            //listar
        
        }

        public IActionResult Catalogo3()
        {
            //listar
            var listarProductos = _context.Productos.ToList();
            return View(listarProductos);
            //listar
        
        }

        public async Task<IActionResult> Details(int? id)
        {
            Producto objProduct = await _context.Productos.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

        public async Task<IActionResult> Details2(int? id)
        {
            Producto objProduct = await _context.Productos.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

        public async Task<IActionResult> Details3(int? id)
        {
            Producto objProduct = await _context.Productos.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

         public async Task<IActionResult> Add(int? id)
        {
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                List<Producto> productos = new List<Producto>();
                return  View("Index",productos);
            }else{
                var producto = await _context.Productos.FindAsync(id);
                Proforma proforma = new Proforma();
                proforma.Producto = producto;
                proforma.Price = producto.Price;
                proforma.Image = producto.Image;
                proforma.Cantidad = 1;
                proforma.UserID = userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return  RedirectToAction(nameof(Index));
            }
        }



        
    }
}