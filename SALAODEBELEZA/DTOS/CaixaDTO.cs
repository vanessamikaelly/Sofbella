﻿using System.ComponentModel.DataAnnotations;

namespace SALAODEBELEZA.DTOS
{
    public class CaixaDTO
    {
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string UsuarioCaixa { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public double ValorInicial { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public double EntradaCaixa { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public double SaidaCaixa { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório!")]
        public double SaldoFinal { get; set; }

    }
}
