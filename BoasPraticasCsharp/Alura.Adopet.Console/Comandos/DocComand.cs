using System;

namespace Alura.Adopet.Console.Comandos
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DocComand : Attribute
    {
        public DocComand(string instrucao, string documentacao)
        {
            Instrucao = instrucao;
            Documentacao = documentacao;
        }

        public string Instrucao { get; }
        public string Documentacao { get; }
    }
}
