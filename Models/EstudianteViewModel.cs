using System;
using System.ComponentModel.DataAnnotations;

namespace Actividad3LengProg3.Models
{
	public class EstudianteViewModel
	{
		[Required]
		[StringLength(100)]
		public string NombreCompleto { get; set; }

		[Required]
		[StringLength(15, MinimumLength = 6)]
		public string Matricula { get; set; }

		[Required]
		public string Carrera { get; set; }

		[Required]
		[EmailAddress]
		public string CorreoInstitucional { get; set; }

		[Phone]
		[MinLength(10)]
		public string Telefono { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime FechaNacimiento { get; set; }

		[Required]
		public string Genero { get; set; }

		[Required]
		public string Turno { get; set; }

		[Required]
		public string TipoIngreso { get; set; }

		public bool EstaBecado { get; set; }

		[Range(0, 100)]
		public int? PorcentajeBeca { get; set; }

		[Required(ErrorMessage = "Debe aceptar los términos.")]
		public bool Terminos { get; set; }
	}
}

