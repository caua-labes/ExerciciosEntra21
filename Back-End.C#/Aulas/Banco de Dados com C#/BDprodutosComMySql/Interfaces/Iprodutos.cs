namespace BDprodutosGenerics_.Interfaces
{
    public interface Iprodutos<T>
    {
        public bool add(T t);
        public void Consultar(T t);
        public bool Alterar(T t);
        public void Excluir(T t);
        public void ConsultarID(T t);
    }
}
