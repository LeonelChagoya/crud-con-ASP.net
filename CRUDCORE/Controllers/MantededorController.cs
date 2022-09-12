using Microsoft.AspNetCore.Mvc;

using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantededorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            //MOSTRARA UNA LISTA DE CONTACTO
            var oLista = _ContactoDatos.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            // METODO SOLO DEVUELVE LA VISTA 
            return View();
        }


        [HttpPost]
        //RECIBE EL OBJETO PARA GUARDARLO EN BD
        public IActionResult Guardar(ContactoModel oContacto)
        {
            if(!ModelState.IsValid)

                return View();

            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();
        }

        public IActionResult Editar(int IdContacto)
        {
            // METODO SOLO DEVUELVE LA VISTA DEL CONTACTO A EDITAR 
            var ocontacto = _ContactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            if (!ModelState.IsValid)

                return View();

            var respuesta = _ContactoDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdContacto)
        {
            // METODO SOLO DEVUELVE LA VISTA DEL CONTACTO A EDITAR 
            var ocontacto = _ContactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {
           

            var respuesta = _ContactoDatos.Eliminar(oContacto.IdContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
