using AutoFixture;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.UnitTest.Mocks
{
    public static class MockVideoRepository
    {
        public static void AddDataVideoRepository(StreamerDbContext streamerDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var videos = fixture.CreateMany<Video>().ToList();
            videos.Add(fixture.Build<Video>()
                .With(record => record.CreatedBy, "prueba")
                .Create()
            );
  
            streamerDbContextFake.Videos!.AddRange(videos);
            streamerDbContextFake.SaveChanges();            
        }
    }
}
