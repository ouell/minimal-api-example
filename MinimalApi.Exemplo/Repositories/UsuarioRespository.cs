using MinimalApi.Exemplo.Models;

namespace MinimalApi.Exemplo.Repositories
{
    /// <summary>
    /// Repositório para entidade usuário
    /// </summary>
    public class UsuarioRespository
    {
        /// <summary>
        /// Repositório fake
        /// </summary>
        private readonly Dictionary<Guid, Usuario> _usuarios = new();

        /// <summary>
        /// Criar um usuário
        /// </summary>
        /// <param name="usuario"></param>
        public void Criar(Usuario? usuario)
        {
            if (usuario is null)
                return;

            _usuarios[usuario.Id] = usuario;
        }

        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        /// <returns>Lista de usuários <seealso cref="List{Usuario}"/></returns>
        public List<Usuario> BuscarTodos()
        {
            return _usuarios.Values.ToList();
        }

        /// <summary>
        /// Buscar usuários por id
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <returns>Usuário <seealso cref="Usuario"/></returns>
        public Usuario? BuscarPorId(Guid id)
        {
            return _usuarios.GetValueOrDefault(id);
        }

        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="usuario">Dados do usuário que serão atualizados</param>
        public void Update(Usuario usuario)
        {
            var usuarioExistente = BuscarPorId(usuario.Id);
            if (usuarioExistente is null)
                return;

            _usuarios[usuario.Id] = usuario;
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        public void Delete(Guid id)
        {
            _usuarios.Remove(id);
        }
    }
}
