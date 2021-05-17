using System;
using ControleFinanceiro.BLL.Models;
using FluentValidation;

namespace ControleFinanceiro.API.Validacoes
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {

        public CategoriaValidator()
        {
            RuleFor(n => n.Nome)
                .NotNull().WithMessage("Preencha o nome")
                .NotEmpty().WithMessage("Preencha o nome")
                .MinimumLength(6).WithMessage("Tamanho mínimo de 6 caracteres")
                .MaximumLength(50).WithMessage("Tamanho máximo de 50 caracteres");

            RuleFor(n => n.Icone)
                .NotNull().WithMessage("Preencha o nome do ícone")
                .NotEmpty().WithMessage("Preencha o nome do ícone")
                .MinimumLength(1).WithMessage("Tamanho mínimo de 1 caracter")
                .MaximumLength(15).WithMessage("Tamanho máximo de 15 caracteres");

            RuleFor(n => n.TipoID)
                .NotNull().WithMessage("Escolha o tipo")
                .NotEmpty().WithMessage("Escolha o tipo");


        }
    }
}