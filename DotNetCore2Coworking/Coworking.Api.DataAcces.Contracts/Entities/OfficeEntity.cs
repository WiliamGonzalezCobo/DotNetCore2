using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAcces.Contracts.Entities
{
    public class OfficeEntity
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

        public bool Active { get; set; }

        public Guid IdAdmin { get; set; }

        public bool HasIndividualWorkSpace { get; set; }

        public int NumberWorkSpaces { get; set; }

        public decimal PriceWorkSpaceDaily { get; set; }

        public decimal PriceWorkSpaceMonthly { get; set; }

        //esta es una relacion 1 a 1
        //Una oficina admite un administrador
        public virtual AdminEntity Admin { get; set; }

        //esta es una relacion 1 a *
        //Una oficina tiene muchos administradores
        //public virtual ICollection<AdminEntity> Admins { get; set; }

        public virtual ICollection<Offices2RoomsEntity> Office2Room { get; set; }
    }
}
