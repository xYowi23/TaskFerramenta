using Taskino_Ferramenta.Models;

namespace Taskino_Ferramenta.Repos
{
    public class ProdottoRepo : IRepo<Prodotto>
    {
        private readonly ParadisoGiovanninoContex _context;

        public ProdottoRepo (ParadisoGiovanninoContex context)
        {
            _context = context;
        }

        public bool Create(Prodotto entity)
        {
            bool risultato = false;
            try
            {
                _context.Prodottos.Add(entity);
                _context.SaveChanges();

                risultato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return risultato;
        }

        public bool Delete(int id)
        {
            bool risultato = false;
            try
            {
                Prodotto pro = _context.Prodottos.Single(r => r.ProdottoID == id);
                _context.Prodottos.Remove(pro);
                _context.SaveChanges();
                risultato = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return risultato;
        }

        public Prodotto? Get(int id)
        {

            return _context.Prodottos.Find(id);
        }

        public IEnumerable<Prodotto> GetAll()
        {
            return _context.Prodottos.ToList();
        }

        public bool Update(Prodotto entity)
        {
            bool risultato = false;
            try
            {

                Prodotto? prodottoEsistente = _context.Prodottos.Find(entity.ProdottoID);
                if (prodottoEsistente is not null)
                {

                    prodottoEsistente.CodiceBarre = entity.CodiceBarre;
                    prodottoEsistente.Nome = entity.Nome;
                    prodottoEsistente.Descrizione = entity.Descrizione;
                    prodottoEsistente.Prezzo = entity.Prezzo;
                    prodottoEsistente.Quantita = entity.Quantita;
                    prodottoEsistente.RepartoRIF = entity.RepartoRIF;




                    _context.SaveChanges();
                    risultato = true;
                }
                else
                {
                    Console.WriteLine("Prodotto non trovato");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return risultato;
        }
        public Prodotto? GetByCodice(string cod)
        {
            return _context.Prodottos.FirstOrDefault(p => p.CodiceBarre == cod);
        }

    }
}
