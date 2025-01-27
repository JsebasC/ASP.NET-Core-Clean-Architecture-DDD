﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTest.Mocks;
using CleanArchitecture.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTest.Feature.Streamers.DeleteStreamer
{
    public class DeleteStreamerCommandHandlerXUnitTests
    {

        private readonly Mock<UnitOfWork> _unitOfWork;        
        private readonly Mock<ILogger<DeleteStreamerCommandHandler>> _logger;
        private readonly IMapper _mapper;

        public DeleteStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();            
            _logger = new Mock<ILogger<DeleteStreamerCommandHandler>>();

            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);
        }


        [Fact]
        public async Task DeleteStreamerCommand_InputStreamerById_ReturnsUnit()
        {
            var streamerInput = new DeleteStreamerCommand
            {
                Id = 8001
            };

            var handler = new DeleteStreamerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(streamerInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }

    }
}
