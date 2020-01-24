using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAcces.Contracts.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
