using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yonkoma.Models
{
    public class Manga
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Data { get; set; }
        public string Status { get; set; }
        public int Rating { get; set; }
        public string Genres { get; set; }
    }
}
