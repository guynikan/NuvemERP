using NuvemERP.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemERP.Page
{
    class ProdutoPage:BaseProdutoPage
    {
        //[TestCaseSource("DataItem")] possivelmente, vai ser necessário criar um schema, de forma que, no teste chame o método e através da chamada do teste seja passada a source
        public void CadastraNovoProduto(string codigo, string descricao, string ean, string estoqueatual, string precovenda)
        {
            AcessarPagina();
            Cadastrar();
            SetCodigo(codigo);
            SetDescricao(descricao);
            SetEan(ean);
            SetNcm("123456789");
            AcessarEstoque();
            SetEstoqueAtual(estoqueatual);
            SetUnidadeEstoque("UN-Unidade");
            AcessarDadosFinanceiros();
            SetPrecoVenda(precovenda);
            Salvar();
        }
    }
}
