﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTest.Mocks;
using CleanArchitecture.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Application.UnitTest.Feature.Streamers.UpdateStreamer
{
    public class UpdateStreamerCommandHandlerXUnitTests
    {
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<UpdateStreamerCommandHandler>> _logger;
        private readonly IMapper _mapper;

        public UpdateStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _emailService = new Mock<IEmailService>();
            _logger = new Mock<ILogger<UpdateStreamerCommandHandler>>();

            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);
        }


        [Fact]
        public async Task UpdateStreamerCommand_InputStreamer_ReturnsUnit()
        {
            var streamerInput = new UpdateStreamerCommand
            {
                Id = 8001,
                Nombre = "Vaxi Stream Max",
                Url ="maximo.com"
            };

            var handler = new UpdateStreamerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(streamerInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }   
}
