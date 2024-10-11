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
            try { 
                _context.Prodottos.Add(entity);
                _context.SaveChanges();
                
                risultato = true;
            }
            catch (Exception ex) {
             Console.WriteLine(ex.ToString());
            }
            return risultato;
        }

        public bool Delete(Prodotto id)
        {
            throw new NotImplementedException();
        }

        public Prodotto? Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prodotto> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Prodotto entity)
        {
            throw new NotImplementedException();
        }
    }
}
