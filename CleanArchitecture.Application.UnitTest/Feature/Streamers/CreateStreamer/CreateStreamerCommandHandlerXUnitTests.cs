﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTest.Mocks;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTest.Feature.Streamers.CreateStreamer
{
    public class CreateStreamerCommandHandlerXUnitTests
    {
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<CreateStreamerCommandHandler>> _logger;
        private readonly IMapper _mapper;

        public CreateStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _emailService = new Mock<IEmailService>();
            _logger = new Mock<ILogger<CreateStreamerCommandHandler>>();

            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);            
        }

        [Fact]
        public async Task CreateStreamerCommand_InputStreamer_ReturnsNumber()
        {
            var streamerInput = new CreateStreamerCommand
            {
                Nombre  = "Prueba Streamer",
                Url = "www.prueba.com"
            };

            var handler = new CreateStreamerCommandHandler(_unitOfWork.Object, _emailService.Object, _logger.Object, _mapper);
            var result = await handler.Handle(streamerInput, CancellationToken.None);

            result.ShouldBeOfType<int>();

        }

    }
}
