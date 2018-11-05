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
        private static Random _random;
        private static readonly object SyncObj = new object();


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
            //driver.Quit();
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
            // tirar a passagem do dado tipo e coloca-lo para repetir-se a cada inserção.
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

                            string tipo = "#ECLIENTE";
                            string nome = split[0];
                            string cep = split[1];



                            var testCase = new TestCaseData(tipo, nome, cep);
                            testCases.Add(testCase);
                        }
                    }
                }

                return testCases;
            }
        }
        #endregion

        private static string GenerateRandomNumber()
        {
            lock (SyncObj)
            {
                if (_random == null)
                    _random = new Random(); // Or exception...
                return _random.Next(100000000, 999999999).ToString();
            }
        }
        public static string NewCpf()
            
        {
            var sum = 0;
            var rest = 0;
            var multiplier1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplier2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var seed = GenerateRandomNumber();

            for (var i = 0; i < 9; i++)
                sum += int.Parse(seed[i].ToString()) * multiplier1[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            seed += rest;
            sum = 0;

            for (var i = 0; i < 10; i++)
                sum += int.Parse(seed[i].ToString()) * multiplier2[i];

            rest = sum % 11;

            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            seed += rest;

            return seed;
        }

        [TearDown]
        public void RetornaParaOInicio()
        {
            Thread.Sleep(2000);
            dsl.ClicarBotao(".img-responsive");
        }

    }
    }

