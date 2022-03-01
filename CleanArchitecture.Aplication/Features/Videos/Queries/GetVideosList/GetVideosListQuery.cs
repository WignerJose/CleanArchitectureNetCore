using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<List<VideosVm>>
    {
        public string UserName { get; set; } = string.Empty;

        public GetVideosListQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentException(nameof(userName));
        }


    }
}
