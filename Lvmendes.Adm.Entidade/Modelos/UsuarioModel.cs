namespace Lvmendes.Adms.Entidade
{
    public class UsuarioModel
    {
        public Int64 Id { get; set; }
        public Int64 IdEmpresa { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Int64 IdPerfil { get; set; }
        public bool Ativo { get; set; }
    }
}
