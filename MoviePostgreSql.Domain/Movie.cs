using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePostgreSql.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = String.Empty;
        public int Year { get; set; }
        public string Summary { get; set; } = String.Empty;
        [MaxLength(3)]
        public List<Actor> Actors { get; set; }
    }
}
