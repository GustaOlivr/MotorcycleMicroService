using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleMicroService.Application.Dto.CustomerDto.Responses
{
    public class GetCustomerByIdResponse
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Cpf { get; set; }
    }
}
