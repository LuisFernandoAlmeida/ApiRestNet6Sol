using System.ComponentModel.DataAnnotations;

namespace ApiRestNet6.Modelos.Dto
{
    public class VillaUpdateDto
    {
        [Required]
        public int Id { get; set; } = 0;
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; } = String.Empty;
        public string Detalle { get; set; }
        [Required]
        public int Tarifa { get; set; }
        [Required]
        public int Ocupantes { get; set; }
        [Required]
        public int MetrosCuadrados { get; set; }
        [Required]
        public string ImagenUrl { get; set; }
        public string Amenidad { get; set; }
    }
}
