using FluentValidation;
using MinimalApi.Exemplo.Models;

namespace MinimalApi.Exemplo.Validator
{
    /// <summary>
    /// Validator da classe usuário
    /// </summary>
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        /// <summary>
        /// Validador
        /// </summary>
        public UsuarioValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(x => x.Sobrenome).NotEmpty().WithMessage("Sobrenome é obrigatório");
            RuleFor(x => x.DataNascimento).NotEmpty().GreaterThan(DateTime.MinValue).WithMessage("Data de nascimento é obrigatória");
        }
    }
}
