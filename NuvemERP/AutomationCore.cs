using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using NUnit.Framework;
using NuvemERP.BasePage;
using NuvemERP.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NuvemERP
{
    [TestFixture]
    public class AutomationCore
    {
        protected Dsl dsl;

        public AutomationCore()
        {
            dsl = new Dsl();
        }

        BaseLoginPage loginPage = new BaseLoginPage();
        private static IWebDriver driver;

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void killDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
       
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            driver.Navigate().GoToUrl(Utils.Versao("Oficial"));
            GetDriver().Manage().Window.Maximize();

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

    }
    }

