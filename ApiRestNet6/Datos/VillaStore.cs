using ApiRestNet6.Modelos.Dto;

namespace ApiRestNet6.Datos
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
        {
            new VillaDto {Id = 1, Nombre = "Vista cerca de la playa" },
            new VillaDto {Id = 2, Nombre = "Vista cerca de la playa" }
        };
    }
}
