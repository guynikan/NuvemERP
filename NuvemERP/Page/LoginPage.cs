using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemERP.Page
{
    class LoginPage
    {
        private Dsl dsl;

        public LoginPage(IWebDriver driver)
        {
            dsl = new Dsl(driver);
        }

        public void Autentica(string user, string pass)
        {
            dsl.Escrever("#username", user);
            dsl.Escrever("#senha", pass);
            dsl.ClicarBotao("#LOGAR");
        }
    }
}
