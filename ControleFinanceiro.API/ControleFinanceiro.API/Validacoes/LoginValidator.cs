using System;
using ControleFinanceiro.API.ViewModels;
using FluentValidation;

namespace ControleFinanceiro.API.Validacoes
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {

            RuleFor(n => n.Email)
                .NotNull().WithMessage("Preencha o e-mail")
                .NotEmpty().WithMessage("Preencha o e-mail")
                .MinimumLength(10).WithMessage("Tamanho mínimo do e-mail é de 10 caracteres")
                .MaximumLength(30).WithMessage("Tamanho máximo do e-mail é de 30 caracteres")
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(n => n.Senha)
                .NotNull().WithMessage("Preencha a senha")
                .NotEmpty().WithMessage("Preencha a senha")
                .MinimumLength(6).WithMessage("Tamanho mínimo a senha é de 6 caracteres")
                .MaximumLength(50).WithMessage("Tamanho máximo a senha é de 50 caracteres");

        }
    }
}
