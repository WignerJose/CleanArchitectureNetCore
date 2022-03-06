using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger)
        {
            if (!context.Streamers!.Any())
            {
                context.Streamers!.AddRange(GetPreconfiguretStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos Insertando nuevos records ala DB {context}", typeof(StreamerDbContext).Name);
            }
        }

        private static IEnumerable<Streamer> GetPreconfiguretStreamer()
        {
            return new List<Streamer> { new Streamer { CreateBy = "wigner" , Name = "Wigner Premiun", Url="http://www.premiun.com"},
                                        new Streamer { CreateBy = "admin", Name = "Amazon vip", Url = "http://www.amazonVip.com"}};
        }
    }
}
