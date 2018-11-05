using NUnit.Framework;
using NuvemERP.BasePage;
using NuvemERP.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NuvemERP
{
    [TestFixture]
    class CamposObrigatoriosTest : AutomationCore
    {

        BasePessoasPage basePessoasPage = new BasePessoasPage();
        BaseProdutoPage baseProdutoPage = new BaseProdutoPage();
        BasePedidoVendaPage basePedidoVendaPage = new BasePedidoVendaPage();

        [TearDown]
        public new void RetornaParaOInicio()
        {

            Thread.Sleep(2000);
            dsl.ClicarBotao(".img-responsive");

            // sobrecarga do método, já que para voltar ao inicio a partir do cadastro é apresentado um alert
            IAlert alert = GetDriver().SwitchTo().Alert();
            alert.Accept();
        }




        [TestCase("","")]
        [TestCase("CODIGO", "")]
        [TestCase("", "DESCRICAO")]
        public void TestaCamposObrigatoriosNoCadastroDeItem(string codigo, string descricao)
        {
            baseProdutoPage.AcessarPagina();
            baseProdutoPage.Cadastrar();
            baseProdutoPage.SetCodigo(codigo);
            baseProdutoPage.SetDescricao(descricao);
            baseProdutoPage.Salvar();

            Thread.Sleep(2000);
            Assert.IsTrue(GetDriver().FindElement(By.CssSelector(".gritter-title")).Text.Contains("Campo Obrigatório"));
        }

        [TestCase(".fa-info-circle", "", "", "")]
        [TestCase("#ECLIENTE", "", "", "")]
        [TestCase("#ECLIENTE", "CODIGO", "", "")] 
        // faltando testcase??
        public void TestaCamposObrigatoriosNoCadastroDePessoa(string tipo, string codigo, string nome, string cpf)
        {            
            basePessoasPage.AcessarPagina();
            basePessoasPage.Cadastrar();
            basePessoasPage.SetTipoCadastro(tipo);
            basePessoasPage.SetTipoPessoa("Pessoa Física");
            basePessoasPage.SetCodigo();
            basePessoasPage.SetNome(nome);
            basePessoasPage.SetCPF(cpf);
            basePessoasPage.Salvar();

            Thread.Sleep(2000);
            Assert.IsTrue(GetDriver().FindElement(By.CssSelector(".gritter-title")).Text.Contains("Nome"));
            
        }

        [TestCase("", "001 - 6 Parcelas - 1ª p/ 7 dias", "", "", "", "", "")]
        [TestCase("", "", "", "", "", "001", "10000")]
        public void TestaCamposObrigatoriosNoCadastroDePedido(string codigo, string condicao, string contabancaria, string pagamento, string categoria, string produto, string quantidade)
        {
            basePedidoVendaPage.AcessarPagina();
            basePedidoVendaPage.Cadastrar();
            basePedidoVendaPage.SetCodigoCliente(codigo);
            basePedidoVendaPage.SetCondicaoPagamento(condicao);
            basePedidoVendaPage.SetContaBancaria(contabancaria);
            basePedidoVendaPage.SetPagamento(pagamento);
            basePedidoVendaPage.SetCategoriaFinanceira(categoria);
            basePedidoVendaPage.SetProduto(produto, quantidade);
            basePedidoVendaPage.SetRecalcula();
            basePedidoVendaPage.Salvar();

            // campos obrigatorios: itens e condição de pagamento
            Thread.Sleep(2000);
            Assert.IsTrue(GetDriver().FindElement(By.CssSelector(".gritter-title")).Text.Contains("Sem Itens"));
            Assert.IsTrue(GetDriver().FindElement(By.CssSelector(".gritter-title")).Text.Contains("Sem Condição de Pagamento"));
        }
    }
}