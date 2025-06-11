
using System.ComponentModel.DataAnnotations;

namespace Actividad3LengProg3.Models
{
	public class EstudianteViewModel
	{
		[Required]
		[StringLength(10)]
		public string Matricula { get; set; }

		[Required]
		[StringLength(100)]
		public string Nombre { get; set; }

		[Required]
		[Range(1, 100)]
		public int Edad { get; set; }

		[Required]
		[EmailAddress]
		public string Correo { get; set; }

		[Required]
		public string Carrera { get; set; }
	}
}

