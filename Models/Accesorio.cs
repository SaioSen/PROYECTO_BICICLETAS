using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PROYECTO_BICICLETAS.Models
{
    [Table("t_accesorio")]
    public class Accesorio
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id")]
        public int Id { get; set;}

        [Required(ErrorMessage="Debe escribir el nombre")]
        [Column("name")]
        [Display (Name="Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage="Debe colocar la url de la imagen")]
        [Display (Name="Imagen")]
        [Column("image")]
        public string Image{ get; set; }

        [Required(ErrorMessage="Debe colocar el precio")]
        [Display (Name="Precio")]  
        [Column("price")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage="Debe colocar la cantidad")]
        [Display (Name="Cantidad")]  
        [Column("amout")]
        public int Amout { get; set; }

        [Required(ErrorMessage="Debe colocar la descripcion")]
        [Display (Name="Descripcion")]  
        [Column("description")]
        public string Descripcion { get; set; }

    }
}