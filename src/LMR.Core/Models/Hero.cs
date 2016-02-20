using System;

namespace LMR.Core.Models
{
    public class Hero
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Set Set { get; set; }
        public Team Team { get; set; }
    }
}
