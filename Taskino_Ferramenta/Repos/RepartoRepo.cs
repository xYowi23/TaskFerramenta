using Azure.Core;
using Taskino_Ferramenta.Models;

namespace Taskino_Ferramenta.Repos
{
    public class RepartoRepo : IRepo<Reparto>
    {
        private readonly ParadisoGiovanninoContex _context;

        public RepartoRepo (ParadisoGiovanninoContex context)
        {
            _context = context;
        }

        public bool Create(Reparto entity)
        {
            bool risultato = false;
            try
            {
                _context.Repartos.Add(entity);
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
                Reparto repa = _context.Repartos.Single(r => r.RepartoId == id);
                _context.Repartos.Remove(repa);
                _context.SaveChanges();
                risultato = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return risultato;
        }

        public Reparto? Get(int id)
        {
            return _context.Repartos.Find(id);
        }

        public IEnumerable<Reparto> GetAll()
        {
            return _context.Repartos.ToList();
        }

        public bool Update(Reparto entity)
        {
            bool risultato = false;
            try
            {
              
                Reparto? repartoEsistente = _context.Repartos.Find(entity.RepartoId);
                if (repartoEsistente is not null)
                {
                
                    repartoEsistente.RepartoCOD = entity.RepartoCOD;
                    repartoEsistente.Nome = entity.Nome;
                    repartoEsistente.Fila = entity.Fila;

                 
                    _context.SaveChanges();
                    risultato = true;
                }
                else
                {
                    Console.WriteLine("Reparto non trovato");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return risultato;
        }
        public Reparto? GetByCodice(string cod)
        {
            return _context.Repartos.FirstOrDefault(v => v.RepartoCOD == cod);
        }

     
    }
}
