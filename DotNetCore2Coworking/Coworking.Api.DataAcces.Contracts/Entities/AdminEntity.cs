using System;
using System.Collections.Generic;
using System.Text;

namespace Coworking.Api.DataAcces.Contracts.Entities
{
    public class AdminEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
