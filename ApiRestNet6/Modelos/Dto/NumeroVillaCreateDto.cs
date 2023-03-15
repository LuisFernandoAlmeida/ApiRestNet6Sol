﻿using System.ComponentModel.DataAnnotations;

namespace ApiRestNet6.Modelos.Dto
{
    public class NumeroVillaCreateDto
    {
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string DetalleEspecial { get; set; }
    }
}
