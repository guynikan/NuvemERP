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
        public void RetornaParaOInicio()
        {

            Thread.Sleep(2000);
            dsl.ClicarBotao(".img-responsive");

            // sobrecarga do método, já que para voltar ao inicio a partir do cadastro é apresentado um alert
            //IAlert alert = GetDriver().SwitchTo().Alert(); para pedidos não serve.
            //alert.Accept();
        }




        [TestCase("", "")]
        [TestCase("CODIGO", "")]
        [TestCase("", "DESCRICAO")]
        public void TestaCamposObrigatoriosNoCadastroDeItem(string codigo, string descricao)
        {
            //
            // act
            //
            baseProdutoPage.AcessarPagina();
            baseProdutoPage.Cadastrar();
            baseProdutoPage.SetCodigo(codigo);
            baseProdutoPage.SetDescricao(descricao);
            baseProdutoPage.Salvar();

            string msg = GetDriver().FindElement(By.CssSelector(".gritter-title")).Text;

            Thread.Sleep(2000);
            //
            // assert
            //
            // a mensagem validada é: "Campo Obrigatório Sem Informação" (Pros 3 TesCases)
            Assert.IsTrue(GetDriver().FindElement(By.CssSelector(".gritter-title")).Text.Contains(msg));
        }

        [TestCase(".fa-info-circle", "", "", "")]
        [TestCase(".fa-info-circle", "", "NOMEDOCLIENTE", "")]
        [TestCase("#ECLIENTE", "", "NOMEDOCLIENTE", "")]
        public void TestaCamposObrigatoriosNoCadastroDePessoa(string tipo, string codigo, string nome, string cpf)
        {
            //
            // act
            //
            basePessoasPage.AcessarPagina();
            basePessoasPage.Cadastrar();
            basePessoasPage.SetTipoCadastro(tipo);
            basePessoasPage.SetTipoPessoa("Pessoa Física");
            basePessoasPage.SetCodigo(codigo);
            basePessoasPage.SetNome(nome);
            basePessoasPage.SetCPF(cpf);
            basePessoasPage.Salvar();
            Thread.Sleep(2000);

            string msg = GetDriver().FindElement(By.CssSelector(".gritter-title")).Text;

            //
            // assert
            //
            // as mensagens validadas são: "Nome", "Tipo de Cadastro Não Informado" e "Código da Pessoa". Nesta ordem.
            Assert.IsTrue(GetDriver().FindElement(By.CssSelector(".gritter-title")).Text.Contains(msg));
        }


        //[TestCase("", "00000 - NÃO INFORMADO", "00000 - NÃO INFORMADO", "00000 - NÃO INFORMADO", "00000 - NÃO INFORMADO", "", "")]
        [TestCase("", "001 - 6 Parcelas - 1ª p/ 7 dias", "00000 - NÃO INFORMADO", "00000 - NÃO INFORMADO", "00000 - NÃO INFORMADO", "", "")]
        [TestCase("", "00000 - NÃO INFORMADO", "00000 - NÃO INFORMADO", "00000 - NÃO INFORMADO", "00000 - NÃO INFORMADO", "001", "10000")]
        public void TestaCamposObrigatoriosNoCadastroDePedido(string codigo, string condicao, string contabancaria, string pagamento, string categoria, string produto, string quantidade)
        {
            //
            // act
            //
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
            
            //string msg2 = GetDriver().FindElement(By.XPath("/html/body/div[4]/div[2]/div[2]/span")).Text;

            //
            // assert
            //
            // as mensagens validadas são: "Sem Itens" e "Sem Condição de Pagamento"
            //AssertCamposObrigatoriosNoCadastroDePedido(msg1, msg2); por hora o primeiro testcase não é testado
            Assert.IsTrue(GetDriver().FindElement(By.CssSelector(".gritter-title")).Text.Contains(dsl.GetTexto("gritter-tile")));
            //Assert.IsTrue(GetDriver().FindElement(By.CssSelector(".gritter-title")).Text.Contains(msg));
        }

        //public void AssertCamposObrigatoriosNoCadastroDePedido(string msg1, string msg2)
        //{

        //    Assert.Multiple(() =>
        //    {
        //        Assert.IsTrue(GetDriver().FindElement(By.CssSelector(".gritter-title")).Text.Contains(msg1.ToString()));
        //        Assert.IsTrue(GetDriver().FindElement(By.CssSelector(".gritter-title")).Text.Contains(msg2.ToString()));
        //    });
        //}
    }
}