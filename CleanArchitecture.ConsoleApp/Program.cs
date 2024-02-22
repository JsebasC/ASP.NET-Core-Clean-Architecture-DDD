using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();

await AddNewRecordAsync();
QueryStreaming();
await QueryFilter();

void QueryStreaming()
{
    var streamers = dbContext!.Streamers!.ToList();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

async Task QueryFilter()
{
    var streamers = await dbContext!.Streamers!.Where(streamer => streamer!.Nombre!.Equals("Netflix")).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

    var streamersPartials = await dbContext!.Streamers!.Where(streamer => streamer!.Nombre!.Contains("Netflix")).ToListAsync();
    var streamersFunctions = await dbContext!.Streamers!.Where(streamer => EF.Functions.Like(streamer.Nombre, "")).ToListAsync();

    foreach (var streamer in streamersPartials)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

async Task QueryLinq()
{
    var nombre = "A";
    var streams = await (from i in dbContext.Streamers
                         where EF.Functions.Like(i.Nombre, $"%{nombre}%")
                         select i).ToListAsync();
}

async Task QueryMethods()
{
    var firstAsync = await dbContext!.Streamers!.Where(streamer => streamer!.Nombre!.Equals("Netflix")).FirstAsync();
    var firstOrDefaultAsync = await dbContext!.Streamers!.Where(streamer => streamer!.Nombre!.Equals("Netflix")).FirstOrDefaultAsync();
    var firstOrDefaultAsync_v2 = await dbContext!.Streamers!.FirstOrDefaultAsync(streamer => streamer!.Nombre!.Equals("Netflix"));

    var single = await dbContext!.Streamers!.Where(streamer => streamer!.Nombre!.Equals("Netflix")).SingleAsync();
    var singleOrDefault = await dbContext!.Streamers!.Where(streamer => streamer!.Nombre!.Equals("Netflix")).SingleOrDefaultAsync();

    var Find = await dbContext!.Streamers!.FindAsync(1); // Busca por la clave primaria de la tabla y no se puede actualizar
}


async Task TrackingAndNotTracking()
{
    var streamerWithTracking = await dbContext!.Streamers!.FirstOrDefaultAsync(streamer => streamer!.Nombre!.Equals("Netflix"));

    //No tracking : No actualiza y libera el objeto de la memoria temporal
    var streamerWithNoTracking = await dbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(streamer => streamer!.Nombre!.Equals("Netflix"));

    streamerWithTracking.Nombre = "Actualizar nombre";

    await dbContext!.SaveChangesAsync();
}

async Task AddNewStreamerWithVideo()
{
    var pantalla = new Streamer
    {
        Nombre = "Pantalla"
    };

    var pelicula = new Video
    {
        Nombre = "Pelicula",
        Streamer = pantalla
    };

    await dbContext.AddAsync(pelicula);
    await dbContext.SaveChangesAsync();

}

async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Nombre = "Brad",
        Apellido = "Pitt"
    };

    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}

async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Basteri",
        VideoId = 1
    };

    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}

async Task MultipleEntitiesQuery()
{

    var videoWithActores = await dbContext.Videos.Include(video => video.Actores).FirstOrDefaultAsync(video => video.Id == 1);

    var actor = await dbContext!.Actores!.Select(actor => actor.Nombre).ToListAsync();

    var videoWithDirector = await dbContext.Videos
        .Where(video => video.Director != null)
        .Include(video => video.Director).Select(video => new
     {
         Director_Nombre_Completo = $"{video.Director.Nombre} {video.Director.Apellido}",
         Movie = video.Nombre
     }
    ).ToListAsync();
}

async Task AddNewRecordAsync()
{
    Streamer streamer = new()
    {
        Nombre = "Disney",
        Url = "www.disney.com"
    };

    dbContext!.Streamers!.Add(streamer);
    await dbContext.SaveChangesAsync();

    var movies = new List<Video>
{
    new Video
    {
        Nombre = "Mad Max",
        StreamerId = 1
    },
    new Video
    {
        Nombre = "Matrix",
        StreamerId = streamer.Id
    },
    new Video
    {
        Nombre = "Batman",
        StreamerId = streamer.Id
    }
};

    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();
}