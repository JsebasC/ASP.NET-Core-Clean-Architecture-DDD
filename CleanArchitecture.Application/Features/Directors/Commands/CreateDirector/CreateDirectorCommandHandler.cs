using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateDirectorCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateDirectorCommandHandler(IUnitOfWork unitOfWork, ILogger<CreateDirectorCommandHandler> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var directorEntity = _mapper.Map<Director>(request);

            _unitOfWork.Repository<Director>().AddEntity(directorEntity);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError("No se inserto el director");
                throw new Exception("No se puedo insertar el director");
            }
                
            return directorEntity.Id;
        }
    }
}
