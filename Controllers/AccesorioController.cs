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
    public class AccesorioController : Controller{

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
    
      public AccesorioController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

         public IActionResult Index()
        {
            //listar
            var listarAccesorios = _context.Accesorios.ToList();
            return View(listarAccesorios);
            //listar
        
        }

        public IActionResult Catalogo2()
        {
            //listar
            var listarAccesorios = _context.Accesorios.ToList();
            return View(listarAccesorios);
            //listar
        
        }

        public async Task<IActionResult> Details(int? id)
        {
            Accesorio objAccesorio = await _context.Accesorios.FindAsync(id);
            if(objAccesorio == null){
                return NotFound();
            }
            return View(objAccesorio);
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar (Accesorio objAccesorio){

           if(ModelState.IsValid){

                //Registrar
               _context.Add(objAccesorio);
               _context.SaveChanges();
                //Registrar
                return RedirectToAction(nameof(Index));   
             }
         
         return View ("Registro",objAccesorio);

        }

         public async Task<IActionResult> Editar (int ? id){
        
            if(id == null){
            return NotFound();
            }else{
                
                var accesorio= await _context.Accesorios.FindAsync(id);
                if(accesorio == null){
                    return NotFound();
                }
                else{
                    return View(accesorio);
                }

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Editar (int id, [Bind("Id,Name,Image,Price,Amout,Descripcion")] Accesorio objAccesorio ){

            if(id !=objAccesorio.Id){
                return NotFound();
            }

            if(ModelState.IsValid){
            try{
                _context.Update(objAccesorio);
                await _context.SaveChangesAsync();
                
            }
            catch(DbUpdateConcurrencyException){
                return NotFound();
            }
           
            return RedirectToAction(nameof(Index));
            }

            return View (objAccesorio);

        }

         public IActionResult Eliminar (int? id){

                var accesorio= _context.Accesorios.Find(id);
                _context.Accesorios.Remove(accesorio);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));

         }











    }

}