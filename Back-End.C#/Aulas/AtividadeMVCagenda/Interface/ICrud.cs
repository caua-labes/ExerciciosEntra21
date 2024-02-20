using Microsoft.AspNetCore.Components.Web;

namespace AulaMVC2._1.Interface
{
    public interface ICrud<T>
    {
        bool salvar(T t);
        void excluir(T t);
        bool editar(T t);
        T consultar(int id);
        List<T> consultar(T t);
        
    }
}
