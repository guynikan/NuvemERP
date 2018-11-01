using NUnit.Framework;
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
        [TearDown]
        public new void RetornaParaOInicio()
        {

            Thread.Sleep(2000);
            dsl.ClicarBotao(".img-responsive");
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }




        [TestCase("","")]
        [TestCase("CODIGO", "")]
        [TestCase("", "DESCRICAO")]
        public void TestaCamposObrigatoriosNoCadastroDeItem(string codigo, string descricao)
        {
            produtoPage.AcessarPagina();
            produtoPage.Cadastrar();
            produtoPage.SetCodigo(codigo);
            produtoPage.SetDescricao(descricao);
            produtoPage.Salvar();

            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.CssSelector(".gritter-title")).Text.Contains("Campo Obrigatório"));
        }

        [TestCase(".fa-info-circle", "", "", "")]
        [TestCase("#ECLIENTE", "", "", "")]
        [TestCase("#ECLIENTE", "CODIGO", "", "")] 
        // faltando testcase??
        public void TestaCamposObrigatoriosNoCadastroDePessoa(string tipo, string codigo, string nome, string cpf)
        {            
            pessoasPage.AcessarPagina();
            pessoasPage.Cadastrar();
            pessoasPage.SetTipoCadastro(tipo);
            pessoasPage.SetTipoPessoa("Pessoa Física");
            pessoasPage.SetCodigo(codigo);
            pessoasPage.SetNome(nome);
            pessoasPage.SetCPF(cpf);
            pessoasPage.Salvar();

            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.CssSelector(".gritter-title")).Text.Contains("Nome"));
            
        }

        [TestCase("", "001 - 6 Parcelas - 1ª p/ 7 dias", "", "", "", "", "")]
        [TestCase("", "", "", "", "", "001", "10000")]
        public void TestaCamposObrigatoriosNoCadastroDePedido(string codigo, string condicao, string contabancaria, string pagamento, string categoria, string produto, string quantidade)
        {
            pedidoVendaPage.AcessarPagina();
            pedidoVendaPage.Cadastrar();
            pedidoVendaPage.SetCodigoCliente(codigo);
            pedidoVendaPage.SetCondicaoPagamento(condicao);
            pedidoVendaPage.SetContaBancaria(contabancaria);
            pedidoVendaPage.SetPagamento(pagamento);
            pedidoVendaPage.SetCategoriaFinanceira(categoria);
            pedidoVendaPage.SetProduto(produto, quantidade);
            pedidoVendaPage.SetRecalcula();
            pedidoVendaPage.Salvar();

            // campos obrigatorios itens e condição de pagamento
            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.CssSelector(".gritter-title")).Text.Contains("Sem Itens"));
            Assert.IsTrue(driver.FindElement(By.CssSelector(".gritter-title")).Text.Contains("Sem Condição de Pagamento"));
        }
    }
}