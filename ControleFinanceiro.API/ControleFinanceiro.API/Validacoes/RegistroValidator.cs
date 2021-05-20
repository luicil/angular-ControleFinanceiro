using System;
using ControleFinanceiro.API.ViewModels;
using FluentValidation;

namespace ControleFinanceiro.API.Validacoes
{
    public class RegistroValidator : AbstractValidator<RegistroViewModel>
    {
        public RegistroValidator()
        {

            RuleFor(n => n.NomeUsuario)
                .NotNull().WithMessage("Preencha o nome do usuário")
                .NotEmpty().WithMessage("Preencha o nome do usuário")
                .MinimumLength(6).WithMessage("Tamanho mínimo do nome do usuário é de 6 caracteres")
                .MaximumLength(50).WithMessage("Tamanho máximo do nome do usuário é de 50 caracteres");

            RuleFor(n => n.CPF)
                .NotNull().WithMessage("Preencha o CPF")
                .NotEmpty().WithMessage("Preencha o CPF")
                .MinimumLength(1).WithMessage("Tamanho mínimo do CPF é de 1 caracter")
                .MaximumLength(20).WithMessage("Tamanho máximo do CPF é de 20 caracteres");

            RuleFor(n => n.Email)
                .NotNull().WithMessage("Preencha o e-mail")
                .NotEmpty().WithMessage("Preencha o e-mail")
                .MinimumLength(10).WithMessage("Tamanho mínimo do e-mail é de 10 caracteres")
                .MaximumLength(30).WithMessage("Tamanho máximo do e-mail é de 30 caracteres")
                .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(n => n.Profissao)
                .NotNull().WithMessage("Preencha a profissão")
                .NotEmpty().WithMessage("Preencha a profissão")
                .MinimumLength(1).WithMessage("Tamanho mínimo da profissão é de 1 caracter")
                .MaximumLength(30).WithMessage("Tamanho máximo da profissão é de 30 caracteres");

            RuleFor(n => n.Senha)
                .NotNull().WithMessage("Preencha a senha")
                .NotEmpty().WithMessage("Preencha a senha")
                .MinimumLength(6).WithMessage("Tamanho mínimo a senha é de 6 caracteres")
                .MaximumLength(50).WithMessage("Tamanho máximo a senha é de 50 caracteres");

            RuleFor(n => n.Foto)
                .NotNull().WithMessage("Escolha uma foto")
                .NotEmpty().WithMessage("Escolha uma foto");

        }
    }
}
