using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAcces.Contracts.Entities
{
    public class BookingEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid OfficeID { get; set; }

        public bool RentWorkSpace { get; set; }

        public Guid? RoomId { get; set; }

        public virtual UserEntity User { get; set; }

        public virtual OfficeEntity Office { get; set; }


    }
}
