using Actividad3LengProg3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad3LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private static List<EstudianteViewModel> estudiantes = new List<EstudianteViewModel>();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(EstudianteViewModel estudiante)
        {
            if (ModelState.IsValid)
            {
                estudiantes.Add(estudiante);
                return RedirectToAction("Lista");
            }
            return View("Index", estudiante);
        }

        public ActionResult Lista()
        {
            return View(estudiantes);
        }

        public ActionResult Editar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
                return HttpNotFound();
            return View(estudiante);
        }

		private ActionResult HttpNotFound()
		{
			throw new NotImplementedException();
		}

		[HttpPost]
        public ActionResult Editar(EstudianteViewModel estudiante)
        {
            if (ModelState.IsValid)
            {
                var original = estudiantes.FirstOrDefault(e => e.Matricula == estudiante.Matricula);
                if (original != null)
                {
                    original.Nombre = estudiante.Nombre;
                    original.Edad = estudiante.Edad;
                    original.Correo = estudiante.Correo;
                    original.Carrera = estudiante.Carrera;
                }
                return RedirectToAction("Lista");
            }
            return View(estudiante);
        }

        public ActionResult Eliminar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante != null)
                estudiantes.Remove(estudiante);

            return RedirectToAction("Lista");


		}
	}

}
