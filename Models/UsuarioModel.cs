using System;

namespace Senai.Carfel.Checkpoint.Models
{
    [Serializable]
    public class UsuarioModel : BaseModel
    {
        /// <summary>
        /// Nome do usuário
        /// </summary>
        /// <value></value>
        public string Nome { get; set; }

        /// <summary>
        /// E-mail do usuário. Serve como forma de acesso ao sistema
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha de acesso ao sistema
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Flag que identifica se o usuário é administrador
        /// </summary>
        public bool Administrador { get; set; }

        public UsuarioModel(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            DataCadastro = DateTime.Now;
        }
    }
}