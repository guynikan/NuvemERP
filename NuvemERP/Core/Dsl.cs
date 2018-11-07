using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace NuvemERP
{
    public class Dsl:AutomationCore
    {
        
        WebDriverWait wait;
        

        public Dsl()
        {
            wait = wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(20));
        }

        /********* Botao ************/

        public void ClicarBotao(string id)
        {

            //wait.Until<IWebElement>(d => d.FindElement(By.CssSelector(id)));
            wait.Until(ExpectedConditions.ElementToBeClickable((By.CssSelector(id))));
            GetDriver().FindElement(By.CssSelector(id)).Click();

        }

        /*********TextBox e TextArea**********/

        public void Escrever(string id, string texto)
        {
            //wait.Until<IWebElement>(d => d.FindElement(By.CssSelector(id)));
            wait.Until(ExpectedConditions.ElementIsVisible((By.CssSelector(id))));
            GetDriver().FindElement(By.CssSelector(id)).Clear();
            GetDriver().FindElement(By.CssSelector(id)).SendKeys(texto);
        }

        /************Pega Texto***************/

        public string GetTexto(string elemento)
        {
            string texto = GetDriver().FindElement(By.CssSelector(elemento)).Text;

            return texto;
        }

        /*********Selecionar numa lista*******/

        public void SelecionarOpcao(string by)
        {
            Thread.Sleep(1000);
            GetDriver().FindElement(By.CssSelector(by)).SendKeys(Keys.ArrowDown);
            GetDriver().FindElement(By.CssSelector(by)).SendKeys(Keys.Enter);
        }

        /********* Radio e Check ************/

        public void ClicarRadio(string by)
        {
            GetDriver().FindElement(By.CssSelector(by)).Click();
        }

        public void ClicarCheck(string by)
        {
            GetDriver().FindElement(By.CssSelector(by)).Click();
        }

        /********* Combo ************/

        //public void SelecionarCombo(string by, string valor)
        //{
        //    AutomationCore.getDriver().FindElement(By.CssSelector(by)).Click();
        //    AutomationCore.getDriver().FindElement(By.CssSelector(valor)).Click();
        //}

        public void SelecionarComboBox(string id, string valor)
        {
            var element = GetDriver().FindElement(By.CssSelector(id));
            var selectElement = new SelectElement(element);

            wait.Until<IWebElement>(d => d.FindElement(By.CssSelector(id)));

            selectElement.SelectByText(valor);
        }

    }
}
