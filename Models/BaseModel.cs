using System;

namespace Senai.Carfel.Checkpoint.Models
{
    [Serializable]
    public class BaseModel
    {
        /// <summary>
        /// Identificação única dos modelos no banco de dados
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Data onde o modelo do banco de dados foi criado
        /// </summary>
        public DateTime DataCadastro { get; set; }
    }
}