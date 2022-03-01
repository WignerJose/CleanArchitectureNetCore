// See https://aka.ms/new-console-template for more information

using CleanArchitecture.Data;
using CleanArchitecture.Domain;

StreamerDbContext dbContext = new();

await AddNewStreamerWithVideo1();
//Streamer stream = new()
//{
// Name ="Amazon prime",
// Url = "https://www.amazonprime.com"
//};

//dbContext!.Streamers!.Add(stream);
//await dbContext!.SaveChangesAsync();

//var movies = new List<Video>
//{
//    new Video {Name = "Mad Max", StreamerId=stream.Id},
//    new Video {Name ="Batman", StreamerId =stream.Id},
//    new Video {Name ="Crepusculo", StreamerId =stream.Id},
//    new Video {Name ="ExitGame", StreamerId =stream.Id},
//};

//await dbContext!.AddRangeAsync(movies);
//await dbContext!.SaveChangesAsync();

async Task AddNewStreamerWithVideo1()
{
    var batman = new Video
    {
        Name = "Batma el caballero de la noche",
        StreamerId = 3
    };

    await dbContext.AddAsync(batman);
    await dbContext!.SaveChangesAsync();
}
