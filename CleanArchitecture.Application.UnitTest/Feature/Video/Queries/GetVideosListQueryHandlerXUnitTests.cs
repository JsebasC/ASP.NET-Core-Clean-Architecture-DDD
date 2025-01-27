﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTest.Mocks;
using CleanArchitecture.Infrastructure.Repositories;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTest.Feature.Video.Queries
{
    public class GetVideosListQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetVideosListQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            MockVideoRepository.AddDataVideoRepository(_unitOfWork.Object.StreamerDbContext);
        }

        [Fact]
        public async Task GetVideoListTest()
        {
            var handler = new GetVideosListQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetVideosListQuery("prueba");
            

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<VideosVm>>();
            result.Count.ShouldBe(1);
        }

    }
}
