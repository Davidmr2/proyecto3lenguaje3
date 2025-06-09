using System.ComponentModel.DataAnnotations;

namespace proyecto3lorenzo.Models
{
	public class EstudianteViewModel
	{
	}
}


	public class EstudianteViewModel
	{
		[Required(ErrorMessage = "La matrícula es obligatoria.")]
		[StringLength(10, ErrorMessage = "Máximo 10 caracteres.")]
		public string Matricula { get; set; }

		[Required(ErrorMessage = "El nombre es obligatorio.")]
		[StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "La edad es obligatoria.")]
		[Range(1, 100, ErrorMessage = "Debe estar entre 1 y 100.")]
		public int Edad { get; set; }

		[Required(ErrorMessage = "El correo es obligatorio.")]
		[EmailAddress(ErrorMessage = "Correo inválido.")]
		public string Correo { get; set; }
	}

