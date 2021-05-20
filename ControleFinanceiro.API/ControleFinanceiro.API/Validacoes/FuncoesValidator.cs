using System;
using ControleFinanceiro.API.ViewModels;
using ControleFinanceiro.BLL.Models;
using FluentValidation;

namespace ControleFinanceiro.API.Validacoes
{
    public class FuncoesValidator : AbstractValidator<FuncoesViewModel>
    {
        public FuncoesValidator()
        {

            RuleFor(n => n.Name)
                .NotNull().WithMessage("Preencha o nome")
                .NotEmpty().WithMessage("Preencha o nome")
                .MinimumLength(6).WithMessage("Tamanho mínimo do nome é de 6 caracteres")
                .MaximumLength(50).WithMessage("Tamanho máximo do nome é de 50 caracteres");

            RuleFor(n => n.Descricao)
                .NotNull().WithMessage("Preencha a descrição")
                .NotEmpty().WithMessage("Preencha a descrição")
                .MinimumLength(6).WithMessage("Tamanho mínimo da descrição é de 6 caracteres")
                .MaximumLength(50).WithMessage("Tamanho máximo da descrição é de 50 caracteres");


        }
    }
}
