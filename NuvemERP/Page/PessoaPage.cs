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
       
        public void CadastraNovaPessoa(string tipo = ".fa - info - circle", string nome = "", string cpf = "", string cep = "")
        {
            
            AcessarPagina();
            Cadastrar();
            SetTipoCadastro(tipo);
            SetTipoPessoa("Pessoa Física");
            SetCodigo();
            SetNome(nome);
            SetCPF(cpf);
            AcessarImpostoETributacao();
            SetTipoAquisicao();
            SetTipoRegime();
            SetTipoIe();
            AcessarDadosDeEndereco();
            SetCep(cep);
            SetNumero();
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
