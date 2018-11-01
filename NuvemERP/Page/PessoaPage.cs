using NuvemERP.BasePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvemERP.Page
{
   public class PessoaPage:BasePessoasPage
    {
        //[TestCaseSource("DataPessoa")] possivelmente, vai ser necessário criar um schema, de forma que, no teste chame o método e através da chamada do teste seja passada a source
        public void CadastraNovaPessoa(string tipo = ".fa - info - circle", string codigo = "", string nome = "", string cpf = "", string cep = "", string numero = "")
        {
            AcessarPagina();
            Cadastrar();
            SetTipoCadastro(tipo);
            SetTipoPessoa("Pessoa Física");
            SetCodigo(codigo);
            SetNome(nome);
            SetCPF(cpf);
            AcessarImpostoETributacao();
            SetTipoAquisicao();
            SetTipoRegime();
            SetTipoIe();
            AcessarDadosDeEndereco();
            SetCep(cep);
            SetNumero(numero);
            Salvar();

        }
        public void ExcluiPessoa(string codigo)
        {
            AcessarPagina();
            PesquisarCadastroPessoa(codigo);
            Excluir();
            
        }
    }
}
