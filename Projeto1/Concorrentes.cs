using System;
using System.Collections.Generic;


namespace Projeto1
{

    public class Concorrente
    {

        // Variaveis
        public int concorrenteID; 
        public string nome; 
        public string carro; 
        public int posicaoFinal;



        //Construtor
        public Concorrente(int numero,string nome, string carro)
        {
            this.concorrenteID = numero;
            this.nome = nome;
            this.carro = carro;
            posicaoFinal = 0;
        }

        public void MostrarConcorrente()
        {
            Console.WriteLine(concorrenteID);
            Console.WriteLine(nome);
            Console.WriteLine(carro);
        }

        //Instancias
        public int GetID () // devolve o numero do participante
        {
            return concorrenteID;
        }
    
        public string Getnome () // Devolve o nome do participante 
        {
            return nome;
        }

        public string GetCarro () // Devolve o nome do carro
        {
            return carro;
        }

        public void SetConcorrenteID(int concorrenteID)
        {
            this.concorrenteID = concorrenteID;
        }
    }
    
}
