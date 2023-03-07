using ApiRestNet6.Modelos.Dto;

namespace ApiRestNet6.Datos
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
        {
            new VillaDto {Id = 1, Nombre = "Vista cerca de la playa",Ocupantes=5,MetrosCuadrados=100},
            new VillaDto {Id = 2, Nombre = "Vista cerca de la playa",Ocupantes=10,MetrosCuadrados=200}
        };
    }
}
