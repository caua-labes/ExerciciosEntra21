namespace BDprodutosGenerics_
{
    public class Categoria
    {
        public int categoriaId { get; set; }
        public string nomeCategoria { get; set; }

        public string ToString()
        {
            return $"{categoriaId} {nomeCategoria.Trim()}";
        }
    }
}
