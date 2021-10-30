using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROYECTO_BICICLETAS.Data;
using PROYECTO_BICICLETAS.Models;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;

namespace PROYECTO_BICICLETAS.Controllers
{
    public class ProformaController: Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager; 

        public ProformaController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

         public async Task<IActionResult> Index()
        {
            var userID = _userManager.GetUserName(User);
            var items = from o in _context.Proformas select o;
            items = items.
                Include(p => p.Producto).
                Where(s => s.UserID.Equals(userID));

            var elements = await items.ToListAsync();
            var total = elements.Sum(c => c.Cantidad * c.Price );
            
            dynamic model = new ExpandoObject();
            model.montoTotal = total;
            model.proformas = elements;

            return View(model);


        }

         public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma = await _context.Proformas.FindAsync(id);
            _context.Proformas.Remove(proforma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));   
        }

         public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma = await _context.Proformas.FindAsync(id);
            if (proforma == null)
            {
                return NotFound();
            }
            return View(proforma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cantidad,Price,UserID,Image")] Proforma proforma)
        {
            if (id != proforma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proforma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProformaExists(proforma.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(proforma);
        }
        private bool ProformaExists(int id)
        {
            return _context.Proformas.Any(e => e.Id == id);
        }

        







        
        

    }
}