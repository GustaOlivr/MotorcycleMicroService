﻿namespace MotorcycleMicroService.Application.Dto.CustomerDto.Responses
{
    /// <summary>
    /// DTO for the response after updating a existing customer. Contains the ID
    /// and the details of the updated customer.
    /// </summary>
    public class UpdateCustomerResponse
    {
        /// <summary>
        /// The unique identifier of the updated customer.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The customer's telephone number.
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// The CPF of the customer, which is a unique identifier in Brazil.
        /// </summary>
        public string Cpf { get; set; }
    }
}
