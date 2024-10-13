using Taskino_Ferramenta.Models;
using Taskino_Ferramenta.Repos;

namespace Taskino_Ferramenta.Services
{
    public class ProdottoService : IService<ProdottoDTO>
    {

        private readonly ProdottoRepo _repository;
        public ProdottoService(ProdottoRepo repository)
        {
            _repository = repository;
        }

        public bool Aggiorna(ProdottoDTO entity)
        {
            bool risultato = false;
            if (!string.IsNullOrWhiteSpace(entity.CodBar) && !string.IsNullOrWhiteSpace(entity.Desc))
            {
                Prodotto? prodottoEsistente = _repository.GetByCodice(entity.CodBar);
                if (prodottoEsistente is not null)
                {

                    prodottoEsistente.Nome = entity.Nom;
                    prodottoEsistente.Descrizione= entity.Desc;
                    prodottoEsistente.Prezzo= entity.Prez;
                    prodottoEsistente.Quantita= entity.Quant;
                    prodottoEsistente.RepartoRIF= entity.RepRif;



                    risultato = _repository.Update(prodottoEsistente);
                }
            }

            return risultato;
        }

        public ProdottoDTO? Cerca(string varCod)
        {
            ProdottoDTO? risultato = null;
            Prodotto? prodotto = _repository.GetByCodice(varCod);
            if (prodotto is not null)
            {
                risultato = new ProdottoDTO()
                {
                    CodBar = prodotto.CodiceBarre,
                    Nom = prodotto.Nome,
                    Desc = prodotto.Descrizione,
                    Prez = prodotto.Prezzo,
                    Quant = prodotto.Quantita,
                    RepRif = prodotto.RepartoRIF

                };
            }
            return risultato;
        }

        public bool Elimina(int id)
        {
            bool risultato = false;
            Prodotto?  prodotto = _repository.Get(id);
            if (prodotto is not null)
            {
                risultato=_repository.Delete(prodotto.ProdottoID);
            }
            return risultato;
        }
        public bool Elimina(string varCodice)
        {
            bool risultato = false;

            // Cerca il reparto tramite il codice
            Prodotto? reparto = _repository.GetByCodice(varCodice);
            if (reparto is not null)
            {
                risultato = _repository.Delete(reparto.ProdottoID);
            }

            return risultato;
        }

        public bool Inserisci(ProdottoDTO pDTO)
        {
            bool risultato = false;
            if (!string.IsNullOrWhiteSpace(pDTO.Nom) && !string.IsNullOrWhiteSpace(pDTO.Desc))
            {
                Prodotto pro = new Prodotto()
                {
                    CodiceBarre = pDTO.CodBar is not null ? pDTO.CodBar : Guid.NewGuid().ToString().ToUpper(),
                    Nome = pDTO.Nom,
                    Descrizione = pDTO.Desc,
                    Prezzo= pDTO.Prez,
                    Quantita=pDTO.Quant,
                    RepartoRIF=pDTO.RepRif,

                };

                return risultato = _repository.Create(pro);
            }

            return risultato;
        }

        public IEnumerable<ProdottoDTO> Lista()
        {
            var proTDO = new List<ProdottoDTO>();
            IEnumerable<Prodotto> prods = _repository.GetAll();
            foreach (var pro in prods)
            {
                ProdottoDTO temp = new ProdottoDTO()
                {
                    CodBar = pro.CodiceBarre,
                    Nom = pro.Nome,
                    Desc = pro.Descrizione,
                    Prez = pro.Prezzo,
                    Quant = pro.Quantita,
                    RepRif = pro.RepartoRIF,

                };
                proTDO.Add(temp);
            }
            return proTDO; ;
        }
    }
}
