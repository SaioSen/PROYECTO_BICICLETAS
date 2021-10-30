using System;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_BICICLETAS.Data;
using PROYECTO_BICICLETAS.Models;
using Microsoft.AspNetCore.Identity;

namespace PROYECTO_BICICLETAS.Controllers
{
    public class PagoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PagoController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Create(Decimal id)
        {
            Pago pago = new Pago();
            pago.UserID = _userManager.GetUserName(User);
            pago.MontoTotal = id;
            return View(pago);
        }

        [HttpPost]
        public IActionResult Pagar(Pago pago)
        {
            pago.PaymentDate = DateTime.Now;
            _context.Add(pago);
            _context.SaveChanges();

            ViewData["Message"] = "El pago se ha registrado";
            return View("Create");
        }
    }
}