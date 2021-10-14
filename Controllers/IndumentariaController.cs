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

namespace PROYECTO_BICICLETAS.Controllers
{

    public class IndumentariaController : Controller{

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public IndumentariaController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

         public IActionResult Index()
        {
            //listar
            var listarIndumentaria = _context.Indumentarias.ToList();
            return View(listarIndumentaria);
            //listar
        
        }

        public IActionResult Catalogo3()
        {
            //listar
            var listarIndumentaria = _context.Indumentarias.ToList();
            return View(listarIndumentaria);
            //listar
        
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar (Indumentaria objIndumentaria){

           if(ModelState.IsValid){

                //Registrar
               _context.Add(objIndumentaria);
               _context.SaveChanges();
                //Registrar
                return RedirectToAction(nameof(Index));   
             }
         
         return View ("Registro",objIndumentaria);

        }

         public async Task<IActionResult> Editar (int ? id){
        
            if(id == null){
            return NotFound();
            }else{
                
                var indumentaria= await _context.Indumentarias.FindAsync(id);
                if(indumentaria == null){
                    return NotFound();
                }
                else{
                    return View(indumentaria);
                }

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Editar (int id, [Bind("Id,Name,Image,Price,Amout,Categoria,Descripcion")] Indumentaria objIndumentaria ){

            if(id !=objIndumentaria.Id){
                return NotFound();
            }

            if(ModelState.IsValid){
            try{
                _context.Update(objIndumentaria);
                await _context.SaveChangesAsync();
                
            }
            catch(DbUpdateConcurrencyException){
                return NotFound();
            }
           
            return RedirectToAction(nameof(Index));
            }

            return View (objIndumentaria);

        }

         public IActionResult Eliminar (int? id){

                var indumentaria= _context.Indumentarias.Find(id);
                _context.Indumentarias.Remove(indumentaria);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));

         }










    }








}
