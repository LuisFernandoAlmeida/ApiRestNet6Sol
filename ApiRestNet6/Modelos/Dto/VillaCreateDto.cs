using System.ComponentModel.DataAnnotations;

namespace ApiRestNet6.Modelos.Dto
{
    public class VillaCreateDto
    {
        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; } = String.Empty;
        public string Detalle { get; set; }
        [Required]
        public int Tarifa { get; set; }
        public int Ocupantes { get; set; }
        public int MetrosCuadrados { get; set; }
        public string ImagenUrl { get; set; }
        public string Amenidad { get; set; }
    }
}
