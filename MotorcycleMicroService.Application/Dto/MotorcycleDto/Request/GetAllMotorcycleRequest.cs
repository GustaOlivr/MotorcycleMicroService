using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleMicroService.Application.Dto.MotorcycleDto.Request
{
    public class GetAllMotorcyclesRequest
    {
        public string? Name { get; set; } // Filtro opcional por nome
        public string? Plate { get; set; } // Filtro opcional por fabricante
        public int PageIndex { get; set; } = 1; // Padrão para a primeira página
        public int PageSize { get; set; } = 10; // Padrão para 10 itens por página
    }
}
