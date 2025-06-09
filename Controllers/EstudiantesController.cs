using Microsoft.AspNetCore.Mvc;

namespace proyecto3lorenzo.Controllers
{
	public class EstudiantesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}




	public class EstudiantesController : Controller
	{
		// Lista estática de estudiantes (en memoria)
		private static List<EstudianteViewModel> estudiantes = new List<EstudianteViewModel>();

		// Muestra el formulario
		public ActionResult Index()
		{
			return View(new EstudianteViewModel());
		}

		// Registra estudiante si el modelo es válido
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

		// Lista los estudiantes
		public ActionResult Lista()
		{
			return View(estudiantes);
		}

		// Carga el formulario de edición
		public ActionResult Editar(string matricula)
		{
			var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
			if (estudiante == null) if (estudiante == null)
				return new HttpStatusCodeResult(404, "Estudiante no encontrado");

		return View(estudiante);
		}

		// Guarda cambios del estudiante
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
				}
				return RedirectToAction("Lista");
			}

			return View(estudiante);
		}

		// Elimina estudiante por matrícula
		public ActionResult Eliminar(string matricula)
		{
			var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
			if (estudiante != null)
			{
				estudiantes.Remove(estudiante);
			}
			return RedirectToAction("Lista");
		}
	}


