using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain
{
    public class Actor : BaseDomainModel
    {
        public Actor()
        {
            Videos = new HashSet<Video>();
        }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<Video>? Videos { get; set; }
    }
}
