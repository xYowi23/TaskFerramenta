using System.ComponentModel.DataAnnotations.Schema;

namespace Taskino_Ferramenta.Models
{

    [Table("Prodotto")]
    public class Prodotto
    {
        public int Id { get; set; }
        public string CodiceBarre { get; set; } = null!;
        public string Nome { get; set; } = null!;

        public string ?Descrizione { get; set;}

        public int Prezzo {  get; set; }

        public int Quantita { get; set; }


        public int RepartoRIF { get; set; }
    }
}
