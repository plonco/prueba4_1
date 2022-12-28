using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebVistas.Models
{
    public class asignacion
    {
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar un rut")]
        [Display(Name = "Rut")]
        public string Rut { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar nombre")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar un apellido")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe ingresar numero de personas")]
        [Range(1, 4, ErrorMessage = "No puede haber mas de 4 personas por habitacion o menos de 1")]
        public int NumeroDePersonas { get; set; }

        [Required(ErrorMessage = "Debe ingresar numero de habitacion")]
        public int NumeroDeHabitacion { get; set; }

        public asignacion(String rut, String nombre, String apellido, int numeroDePersonas, int numeroDeHabitaciones)
        {
            Rut = rut;
            Nombre = nombre;
            Apellido = apellido;
            NumeroDePersonas = numeroDePersonas;
            NumeroDeHabitacion = numeroDeHabitaciones;
        }
    }
}