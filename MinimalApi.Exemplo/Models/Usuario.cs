namespace MinimalApi.Exemplo.Models
{
    /// <summary>
    /// Usuário
    /// </summary>
    /// <param name="Id">Identificador do usuário</param>
    /// <param name="Nome">Nome do usuário</param>
    /// <param name="Sobrenome">Sobrenome do usuário</param>
    /// <param name="DataNascimento">Data de nascimento do usuário</param>
    public record Usuario(Guid Id, string Nome, string Sobrenome, DateTime DataNascimento);
}
