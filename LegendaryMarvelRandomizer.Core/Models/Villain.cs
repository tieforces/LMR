using System;

namespace LegendaryMarvelRandomizer.Core.Models
{
    public class Villain
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Set Set { get; set; }
    }
}
