
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class Uvolnenie_PSJ
    {
        public int Id { get; set; }
        public int? SotrudnikId { get; set; }
        public DateTime? Data { get; set; }
        public string? Prichina { get; set; }
    }
}
