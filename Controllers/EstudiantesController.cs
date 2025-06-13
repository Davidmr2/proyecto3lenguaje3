using Actividad3LengProg3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad3LengProg3.Controllers
{
	public class EstudiantesController : Controller
	{
		private static List<EstudianteViewModel> listaEstudiantes = new List<EstudianteViewModel>();

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Registrar(EstudianteViewModel estudiante)
		{
			if (!estudiante.EstaBecado)
				estudiante.PorcentajeBeca = null;

			if (ModelState.IsValid)
			{
				listaEstudiantes.Add(estudiante);
				return RedirectToAction("Lista");
			}

			return View("Index", estudiante);
		}

		public ActionResult Lista()
		{
			return View(listaEstudiantes);
		}

		public ActionResult Editar(string matricula)
		{
			var estudiante = listaEstudiantes.FirstOrDefault(e => e.Matricula == matricula);
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
			if (!estudiante.EstaBecado)
				estudiante.PorcentajeBeca = null;

			if (ModelState.IsValid)
			{
				var original = listaEstudiantes.FirstOrDefault(e => e.Matricula == estudiante.Matricula);
				if (original != null)
				{
					listaEstudiantes.Remove(original);
					listaEstudiantes.Add(estudiante);
				}
				return RedirectToAction("Lista");
			}

			return View(estudiante);
		}

		public ActionResult Eliminar(string matricula)
		{
			var estudiante = listaEstudiantes.FirstOrDefault(e => e.Matricula == matricula);
			if (estudiante != null)
				listaEstudiantes.Remove(estudiante);

			return RedirectToAction("Lista");
		}
	}
}
