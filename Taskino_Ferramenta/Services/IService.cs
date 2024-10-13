namespace Taskino_Ferramenta.Services
{
    public interface IService<T>
    {
        IEnumerable<T> Lista();
        T? Cerca(string varCod);

        bool Inserisci (T entity);
        bool Aggiorna (T entity);

        bool Elimina (int id );

        bool Elimina(string varCod);
    }
}
