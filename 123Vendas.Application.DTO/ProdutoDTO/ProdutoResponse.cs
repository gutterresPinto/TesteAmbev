using _123Vendas.Domain;


namespace _123Vendas.Application.DTO.ProdutoDTO;

public class ProdutoResponse
{
    public required string ProdutoID { get; set; }
    public int CodigoProduto { get; set; }
    public required string Nome { get; set; }
    public decimal Valor { get; set; }

    public static implicit operator ProdutoResponse(Produto parametro)
    {
        if (parametro is null)
            return null;

        ProdutoResponse retorno = new ProdutoResponse()
        {
            ProdutoID = parametro.UID.ToString(),
            CodigoProduto = parametro.CodigoProduto,
            Nome = parametro.Nome,
            Valor = parametro.Valor
        };

        return retorno;
    }
}
