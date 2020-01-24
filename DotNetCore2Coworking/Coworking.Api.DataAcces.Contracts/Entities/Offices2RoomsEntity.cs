using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAcces.Contracts.Entities
{
    public class Offices2RoomsEntity
    {
        public Guid OfficeId { get; set; }

        public Guid RoomId { get; set; }

        public virtual OfficeEntity Office { get; set; }
        
        public virtual RoomEntity   Room { get; set; }
    }
}
