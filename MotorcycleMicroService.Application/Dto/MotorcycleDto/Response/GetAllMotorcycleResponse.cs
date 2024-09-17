using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleMicroService.Application.Dto.MotorcycleDto.Response
{
    public class GetAllMotorcyclesResponse
    {
        public List<MotorcycleDto> Motorcycles { get; set; }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }
    }

    public class MotorcycleDto
    {
        public Guid MotorcycleId { get; set; }
        public string Name { get; set; }
    }

}
