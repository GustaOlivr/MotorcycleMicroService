namespace MotorcycleMicroService.Application.Dto.CustomerDto.Requests
{
    public class CreateCustomerRequest
    {
        public string Name { get; set;}
        public string Telephone { get; set; }   
        public string Cpf { get; set; }
    }
}
