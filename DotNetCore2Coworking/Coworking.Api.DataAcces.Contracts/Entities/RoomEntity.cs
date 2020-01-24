using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAcces.Contracts.Entities
{
    public class RoomEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public virtual ICollection<Offices2RoomsEntity> Office2Room { get; set; }

        public virtual ICollection<Room2Services> Room2Service { get; set; }

    }
}
