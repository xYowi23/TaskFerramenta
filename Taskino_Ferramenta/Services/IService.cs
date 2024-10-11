namespace Taskino_Ferramenta.Services
{
    public interface IService<T>
    {
        IEnumerable<T> Lista();
        T? Cerca(string varCod);
    }
}
