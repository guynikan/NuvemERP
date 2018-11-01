using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using NUnit.Framework;
using NuvemERP.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NuvemERP
{
    [TestFixture]
    public class AutomationCore
    {
        public IWebDriver driver;
        public Dsl dsl;
        public PedidoVendaPage pedidoVendaPage;
        public PessoasPage pessoasPage;
        public ProdutoPage produtoPage;
        private LoginPage loginPage;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            driver = new ChromeDriver();
            dsl = new Dsl(driver);
            pedidoVendaPage = new PedidoVendaPage(driver);
            pessoasPage = new PessoasPage(driver);
            produtoPage = new ProdutoPage(driver);
            loginPage = new LoginPage(driver);

            driver.Navigate().GoToUrl(Utils.Versao("Oficial"));
            driver.Manage().Window.Maximize();

            loginPage.Autentica("undefined", "undefined");
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            driver.Quit();
        }

        // Source Itens
        #region
        public static List<TestCaseData> DataItem
        {
            get
            {
                var testCases = new List<TestCaseData>();

                using (var fs = File.OpenRead(@"C:\Users\suporte05\Desktop\NUVEMERP\Testes Automatizados\NuvemERP\NuvemERP\Data\Itens.csv"))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ',' },
                                StringSplitOptions.None);

                            string codigo = split[0];
                            string descricao = split[1];

                            var testCase = new TestCaseData(codigo, descricao);
                            testCases.Add(testCase);
                        }
                    }
                }

                return testCases;
            }
        }
        #endregion

        // Source Pessoas
        #region
        public static List<TestCaseData> DataPessoa
        {
            get
            {
                var testCases = new List<TestCaseData>();

                using (var fs = File.OpenRead(@"C:\Users\suporte05\Desktop\NUVEMERP\Testes Automatizados\NuvemERP\NuvemERP\Data\Pessoa.csv"))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ',' },
                                StringSplitOptions.None);

                            string tipo = split[0];
                            string codigo = split[1];
                            string nome = split[2];
                            string cpf = split[3];
                            string cep = split[4];
                            string numero = split[5];

                            var testCase = new TestCaseData(tipo, codigo, nome, cpf, cep, numero);
                            testCases.Add(testCase);
                        }
                    }
                }

                return testCases;
            }
        }
        #endregion

        [TearDown]
        public void RetornaParaOInicio()
        {
            Thread.Sleep(2000);
            dsl.ClicarBotao(".img-responsive");
        }

        [TestCaseSource("DataItem")]
        public void CadastraNovoProduto(string codigo, string descricao, string ean, string estoqueatual, string precovenda)
        {
            produtoPage.AcessarPagina();
            produtoPage.Cadastrar();
            produtoPage.SetCodigo(codigo);
            produtoPage.SetDescricao(descricao);
            produtoPage.SetEan(ean);
            produtoPage.SetNcm("123456789");
            produtoPage.AcessarEstoque();
            produtoPage.SetEstoqueAtual(estoqueatual);
            produtoPage.SetUnidadeEstoque("UN-Unidade");
            produtoPage.AcessarDadosFinanceiros();
            produtoPage.SetPrecoVenda(precovenda);
            produtoPage.Salvar();
        }

        [TestCaseSource("DataPessoa")]
        public void CadastraNovaPessoa(string tipo = ".fa - info - circle", string codigo = "", string nome = "", string cpf = "", string cep = "", string numero = "")
        {
            pessoasPage.AcessarPagina();
            pessoasPage.Cadastrar();
            pessoasPage.SetTipoCadastro(tipo);
            pessoasPage.SetTipoPessoa("Pessoa Física");
            pessoasPage.SetCodigo(codigo);
            pessoasPage.SetNome(nome);
            pessoasPage.SetCPF(cpf);
            pessoasPage.AcessarImpostoETributacao();
            pessoasPage.SetTipoAquisicao();
            pessoasPage.SetTipoRegime();
            pessoasPage.SetTipoIe();
            pessoasPage.AcessarDadosDeEndereco();
            pessoasPage.SetCep(cep);
            pessoasPage.SetNumero(numero);
            pessoasPage.Salvar();

        }

        [Test]
        public void ExcluiPessoa(string codigo)
        {
            pessoasPage.AcessarPagina();
            pessoasPage.Excluir(codigo);
            Thread.Sleep(2000);
            Assert.IsTrue(driver.FindElement(By.CssSelector(".gritter-title")).Text.Contains("Exclusão foi Realizada"));
        }

        public void CadastraNovoPedido(string codigo, string produto, string quantidade)
        {
            produtoPage.AcessarPagina();
            pedidoVendaPage.AcessarPagina();
            pedidoVendaPage.Cadastrar();
            pedidoVendaPage.SetCodigoCliente(codigo);
            pedidoVendaPage.SetCondicaoPagamento("003 - 12 parcelas - 1ª no ato");
            pedidoVendaPage.SetPagamento("Dinheiro");
            pedidoVendaPage.SetContaBancaria("NUCONTA");
            pedidoVendaPage.SetCategoriaFinanceira("(RECEITA) -Financiamentos e Investimentos");
            pedidoVendaPage.SetProduto(produto, quantidade);
            pedidoVendaPage.SetRecalcula();
            pedidoVendaPage.Salvar();

        }

        }
    }

