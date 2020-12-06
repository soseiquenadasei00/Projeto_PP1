using System;
using System.Collections;


namespace Projeto1
{

    public class Concorrente
    {

        // Variaveis
        public int numero;
        public int quantidade;
        public string nome;
        public string carro;


        //Construtor

        public Concorrente(int numero, string nome, string carro)
        {
            this.numero = numero;
            this.nome = nome;
            this.carro = carro;
        }

        public int nParticipante (int n)
        {
            return (n = numero);
        }

    }
    
}
