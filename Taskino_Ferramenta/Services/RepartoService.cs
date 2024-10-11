using Taskino_Ferramenta.Models;
using Taskino_Ferramenta.Repos;

namespace Taskino_Ferramenta.Services
{
    public class RepartoService : IService<RepartoDTO>
    {

        private readonly RepartoRepo _reapository;

        public RepartoService(RepartoRepo repository)
        {
            _reapository = repository;
        }

        public RepartoDTO? Cerca (string varCod)
        {
            RepartoDTO? risultato = null;

            Reparto? reparto = _reapository.GetByCodice(varCod);
            if (reparto is not null )
            {
                risultato = new RepartoDTO()
                {
                    Cod=reparto.RepartoCOD,
                    Nom=reparto.Nome,
                    Fil=reparto.Fila
                   
                };
            }
            return risultato;
        }

        public IEnumerable<RepartoDTO> Lista()
        {
            throw new NotImplementedException();
        }
    }
}
