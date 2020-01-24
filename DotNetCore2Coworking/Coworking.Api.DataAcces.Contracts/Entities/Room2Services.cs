using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAcces.Contracts.Entities
{
    public class Room2Services
    {
        public Guid RoomId { get; set; }

        public Guid ServiceId { get; set; }

        public virtual RoomEntity Room { get; set; }

        public virtual ServiceEntity Service { get; set; }

    }
}
