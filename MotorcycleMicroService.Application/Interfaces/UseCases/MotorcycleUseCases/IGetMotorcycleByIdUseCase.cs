﻿using MotorcycleMicroService.Application.Dto.MotorcycleDto.Response;

namespace MotorcycleMicroService.Application.Interfaces.UseCases.MotorcycleUseCases
{
    public interface IGetMotorcycleByIdUseCase
    {
        Task<GetMotorcycleByIdResponse> ExecuteAsync(Guid id);
    }
}
