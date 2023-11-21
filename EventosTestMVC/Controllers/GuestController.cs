using System.Collections.Generic;
using System.Web.Mvc;

public class GuestController : Controller
{
    // Acción para mostrar la lista de productos
    public ActionResult Index()
    {
        // Supongamos que tienes una clase DbContext llamada ApplicationDbContext
        using (var dbContext = new ApplicationDbContext())
        {
            // Obtener la lista de productos desde la base de datos
            List<Guests> invitados = dbContext.Guests.ToList();

            // Pasar la lista de productos a la vista
            return View(invitados);
        }
    }
}
