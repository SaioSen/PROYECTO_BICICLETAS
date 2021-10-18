using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROYECTO_BICICLETAS.Models
{
    [Table("t_proforma")]

    public class Proforma
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        [Column("id")]
        public int Id { get; set; }

        public String UserID {get; set;}

        public Producto Producto {get; set;}

        public int Cantidad{get; set;}

        public Decimal Price { get; set; }


        
    }
}