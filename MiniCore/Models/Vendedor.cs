using System.ComponentModel.DataAnnotations;

namespace MiniCore.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public ICollection<Venta> Ventas { get; set; }
    }
}
