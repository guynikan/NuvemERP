using NuvemERP.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemERP.Page
{
    class PedidoVendaPage:BasePedidoVendaPage
    {

        public void CadastraNovoPedido(string codigo, string produto, string quantidade)
        {
            AcessarPagina();
            AcessarPagina();
            Cadastrar();
            SetCodigoCliente(codigo);
            SetCondicaoPagamento("003 - 12 parcelas - 1ª no ato");
            SetPagamento("Dinheiro");
            SetContaBancaria("NUCONTA");
            SetCategoriaFinanceira("(RECEITA) -Financiamentos e Investimentos");
            SetProduto(produto, quantidade);
            SetRecalcula();
            Salvar();

        }
    }
}
