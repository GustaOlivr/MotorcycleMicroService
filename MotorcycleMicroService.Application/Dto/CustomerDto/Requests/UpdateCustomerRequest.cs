namespace MotorcycleMicroService.Application.Dto.CustomerDto.Requests
{
    /// <summary>
    /// DTO for the request to update a existent customer. Contains the necessary information
    /// to updates a new customer in the system.
    /// </summary>
    public class UpdateCustomerRequest
    {
        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The customer's telephone number.
        /// </summary>
        public string? Telephone { get; set; }

        /// <summary>
        /// The CPF (Cadastro de Pessoa Física) of the customer, which is a unique identifier in Brazil.
        /// </summary>
        public string? Cpf { get; set; }
    }
}
