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
    public class Dsl
    {
        private IWebDriver driver;
        WebDriverWait wait;
        

        public Dsl(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        /********* Botao ************/

        public void ClicarBotao(string id)
        {

            //wait.Until<IWebElement>(d => d.FindElement(By.CssSelector(id)));
            wait.Until(ExpectedConditions.ElementToBeClickable((By.CssSelector(id))));
            driver.FindElement(By.CssSelector(id)).Click();

        }

        /*********TextBox e TextArea**********/

        public void Escrever(string id, string texto)
        {
            //wait.Until<IWebElement>(d => d.FindElement(By.CssSelector(id)));
            wait.Until(ExpectedConditions.ElementIsVisible((By.CssSelector(id))));
            driver.FindElement(By.CssSelector(id)).Clear();
            driver.FindElement(By.CssSelector(id)).SendKeys(texto);
        }

        /*********Selecionar numa lista*******/

        public void SelecionarOpcao(string by)
        {
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector(by)).SendKeys(Keys.ArrowDown);
            driver.FindElement(By.CssSelector(by)).SendKeys(Keys.Enter);
        }

        /********* Radio e Check ************/

        public void ClicarRadio(string by)
        {
            driver.FindElement(By.CssSelector(by)).Click();
        }

        public void ClicarCheck(string by)
        {
            driver.FindElement(By.CssSelector(by)).Click();
        }

        /********* Combo ************/

        //public void SelecionarCombo(string by, string valor)
        //{
        //    driver.FindElement(By.CssSelector(by)).Click();
        //    driver.FindElement(By.CssSelector(valor)).Click();
        //}

        public void SelecionarComboBox(string id, string valor)
        {
            var element = driver.FindElement(By.CssSelector(id));
            var selectElement = new SelectElement(element);

            wait.Until<IWebElement>(d => d.FindElement(By.CssSelector(id)));

            selectElement.SelectByText(valor);
        }

    }
}
