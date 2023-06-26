using Lvmendes.Adm.Entidade;

namespace Lvmendes.Adms.Entidade
{
    public class ClienteModel
    {
        public Int64 Id { get; set; }
        public string Telefone { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Referencia { get; set; }
        public bool Ativo { get; set; }

        public ClienteEntidade PassarParaEntidade()
        {
            return new ClienteEntidade
            {
              CEP = CEP,
              Senha = Senha,
              Telefone= Telefone,
              Referencia= Referencia,
              Nome= Nome,
              Endereco= Endereco,
              Id= Id


            };
        }
    }
}
