namespace SALAODEBELEZA.Models
{
    public class Relatorio
    {
        public DateTime Datainicial { get; set; }
        public DateTime Data {  get; set; }

        /* metodos dependencias 
        public GerarRelatorioAgenda(List<Agenda> agendas)
        {
            return agendas.Select(a => new
            {
                a.Id,
                a.Descricao,
                Data = a.Data.ToString("dd/MM/yyyy")
            }).ToList<dynamic>();
        }

        public GerarRelatorioFinanceiro(List<Caixa> financeiros)
        {
            return financeiros.Select(f => new
            {
                f.Id,
                f.Descricao,
                f.Valor,
                Data = f.Data.ToString("dd/MM/yyyy")
            }).ToList<dynamic>();
        }

        public GerarRelatorioProdutos(List<Produto> produtos)
        {
            return produtos.Select(p => new
            {
                p.Id,
                p.Nome,
                p.Preco,
                p.Quantidade
            }).ToList<dynamic>();
        }

        public GerarRelatorioGeral(List<Agenda> agendas, List<Financeiro> financeiros, List<Produto> produtos)
        {
            return new
            {
                Agenda = GerarRelatorioAgenda(agendas),
                Financeiro = GerarRelatorioFinanceiro(financeiros),
                Produtos = GerarRelatorioProdutos(produtos)
            };
        }*/
    }
}
