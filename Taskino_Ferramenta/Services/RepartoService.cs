using Taskino_Ferramenta.Models;
using Taskino_Ferramenta.Repos;

namespace Taskino_Ferramenta.Services
{
    public class RepartoService : IService<RepartoDTO>
    {

        private readonly RepartoRepo _repository;

        public RepartoService(RepartoRepo repository)
        {
            _repository = repository;
        }

        public bool Aggiorna(RepartoDTO entity)
        {
            bool risultato = false;
            if (!string.IsNullOrWhiteSpace(entity.Cod) && !string.IsNullOrWhiteSpace(entity.Fil))
            {
                Reparto? repartoEsistente = _repository.GetByCodice(entity.Cod);
                if (repartoEsistente is not null)
                {
              
                    repartoEsistente.Nome = entity.Nom;
                    repartoEsistente.Fila = entity.Fil;

                  
                    risultato = _repository.Update(repartoEsistente);
                }
            }

            return risultato;
        }

        public RepartoDTO? Cerca(string varCod)
        {
            RepartoDTO? risultato = null;

            Reparto? reparto = _repository.GetByCodice(varCod);
            if (reparto is not null)
            {
                risultato = new RepartoDTO()
                {
                    Cod = reparto.RepartoCOD,
                    Nom = reparto.Nome,
                    Fil = reparto.Fila

                };
            }
            return risultato;
        }

        public bool Elimina(int id)
        {
            bool risultato = false;

            Reparto? reparto = _repository.Get(id);
            if (reparto is not null)
            {
                risultato = _repository.Delete(reparto.RepartoId);


            }
            return risultato;
        }
        public bool Elimina(string varCodice)
        {
            bool risultato = false;

            // Cerca il reparto tramite il codice
            Reparto? reparto = _repository.GetByCodice(varCodice);
            if (reparto is not null)
            {
                risultato = _repository.Delete(reparto.RepartoId);
            }

            return risultato;
        }
        public bool Inserisci(RepartoDTO rDTO)
        {
            bool risultato = false;
            if (!string.IsNullOrWhiteSpace(rDTO.Nom) && !string.IsNullOrWhiteSpace(rDTO.Fil))
            {
                Reparto rep = new Reparto()
                {
                    RepartoCOD = rDTO.Cod is not null ? rDTO.Cod : Guid.NewGuid().ToString().ToUpper(),
                    Nome = rDTO.Nom,
                    Fila = rDTO.Fil
                };

                return risultato = _repository.Create(rep);
            }

            return risultato;
        }

        public IEnumerable<RepartoDTO> Lista()
        {
            var repDTO = new List<RepartoDTO>();
            IEnumerable<Reparto> reparti = _repository.GetAll();
            foreach (var rep in reparti)
            {
                RepartoDTO temp = new RepartoDTO()
                {
                    Cod = rep.RepartoCOD,
                    Nom = rep.Nome,
                    Fil = rep.Fila

                };
                repDTO.Add(temp);
            }
            return repDTO;
        }
    }
}
