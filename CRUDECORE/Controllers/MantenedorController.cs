using Microsoft.AspNetCore.Mvc;

using CRUDECORE.Datos;
using CRUDECORE.Models;


namespace CRUDECORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            //LA VISTA MOSTRARA UNA LISTA DE CONTACTOS
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int Idcontacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oContacto = _ContactoDatos.Obtener(Idcontacto);
            return View(oContacto);
        }
        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            //METODO RECIBE EL OBJETO PARA EDITARLO EN BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ContactoDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int Idcontacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oContacto = _ContactoDatos.Obtener(Idcontacto);
            return View(oContacto);
        }
        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {
            //METODO RECIBE EL OBJETO PARA ELIMINARLO EN BD

            var respuesta = _ContactoDatos.Eliminar(oContacto.IdContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
