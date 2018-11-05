using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NuvemERP.Page;

namespace NuvemERP
{
   [TestFixture]
   public class CadastroPessoaTest:AutomationCore
    {
        PessoaPage pessoaPage = new PessoaPage();

        [TestCaseSource("DataPessoa")] 
        public void CadastroPessoa(string tipo, string nome, string cep)
        {
            pessoaPage.CadastraNovaPessoa(tipo, nome, NewCpf(), cep);
        }
    }
}
