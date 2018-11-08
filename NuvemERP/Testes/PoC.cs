using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuvemERP.BasePage;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace NuvemERP.Testes
{
    [TestFixture]
    class PoC : AutomationCore
    {

        [Test]
        public void LocalizaElemento()
        {
            WebDriverWait wait = new WebDriverWait(AutomationCore.GetDriver(), TimeSpan.FromSeconds(20));
            Dsl dsl = new Dsl();
            BasePedidoVendaPage basePedidoVendaPage = new BasePedidoVendaPage();

            basePedidoVendaPage.AcessarPagina();
            basePedidoVendaPage.Cadastrar();
            basePedidoVendaPage.SetCondicaoPagamento("00000 - NÃO INFORMADO");
            basePedidoVendaPage.SetProduto("0001", "10000");
            basePedidoVendaPage.SetRecalcula();
            basePedidoVendaPage.Salvar();
            // só localiza com essa merda aí de XPath ou com o .gritter-title(só serve pra quando é um elemento só)
            string texto = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[4]/div[2]/div[2]/div[1]/span"))).Text;


        }
    }
}
