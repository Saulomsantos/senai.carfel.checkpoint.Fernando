using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Senai.Carfel.Checkpoint.Interfaces;
using Senai.Carfel.Checkpoint.Models;

namespace Senai.Carfel.Checkpoint.Repositorios
{
    public class UsuarioRepositorioSerializacao : IUsuarioRepositorio
    {
        /// <summary>
        /// A lista que armazena todos os usuários persistidos no sistema
        /// Esta lista é utilizada para realizar a serialização
        /// </summary>
        public List<UsuarioModel> UsuariosSalvos {get; private set;}

        // Construtor
        public UsuarioRepositorioSerializacao()
        {
            if (!File.Exists("usuarios.dat"))
            {
                UsuariosSalvos = new List<UsuarioModel>();
            }
        }

        /// <summary>
        /// Desserializa o conteúdo do arquivo de dados no objeto
        /// UsuariosSalvos
        /// </summary>
        private void DesserializarLista()
        {
            byte[] bytesDoArquivo = File.ReadAllBytes("usuarios.dat");
            MemoryStream memoria = new MemoryStream(bytesDoArquivo);
            BinaryFormatter serializador = new BinaryFormatter();

            UsuariosSalvos = serializador.Deserialize(memoria) as List<UsuarioModel>;
        }

        /// <summary>
        /// Serializa a lista no arquivo de dados no estado atual dela
        /// </summary>
        private void SerializarLista()
        {
            // Guarda os dados do objeto que foi serializado
            MemoryStream memoria = new MemoryStream();

            // Realiza o processo de serialização
            BinaryFormatter serializador = new BinaryFormatter();

            // Serializar, gravar os bytes na memória e salvar os bytes no arquivo
            // Transforma a lista de usuários em bytes e atribui ao objeto memória
            serializador.Serialize(memoria, UsuariosSalvos);
            // Converte a memoria em um arranjo de bytes e escreve no arquivo usuarios.dat
            File.WriteAllBytes("usuarios.dat", memoria.ToArray());
        }
        public void Cadastrar(UsuarioModel usuario)
        {
            // Define o ID do usuário como sendo o tamanho da lista + 1
            usuario.ID = UsuariosSalvos.Count + 1;
            // Adiciona o usuário recém criado na lista
            UsuariosSalvos.Add(usuario);

            SerializarLista();
        }

        public List<UsuarioModel> Listar()
        {
            throw new System.NotImplementedException();
        }

        public UsuarioModel Login(string email, string senha)
        {
            foreach (var usuario in UsuariosSalvos)
            {
                if (usuario.Email == email &&
                    usuario.Senha == senha)
                {
                    return usuario;
                }
            }
        }
    }
}