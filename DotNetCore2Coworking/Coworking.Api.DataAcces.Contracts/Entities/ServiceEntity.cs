using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAcces.Contracts.Entities
{
    public class ServiceEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Room2Services> Room2Service { get; set; }

    }
}
