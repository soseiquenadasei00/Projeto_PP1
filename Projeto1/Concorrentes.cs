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
        public int difAnt;
        public int difLid;



        //Construtor
        public Concorrente(int numero,string nome, string carro)
        {
            this.concorrenteID = numero;
            this.nome = nome;
            this.carro = carro;
            this.posicaoFinal = 0;
            this.difAnt = 0;
            this.difLid = 0;
        }

        public void MostrarConcorrente()
        {
            Console.WriteLine(concorrenteID);
            Console.WriteLine(nome);
            Console.WriteLine(carro);
            Console.WriteLine(posicaoFinal);
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

        public int GetPosicao() // Devolve posicao final 
        {
            return posicaoFinal;
        }

        public void SetConcorrenteID(int concorrenteID)
        {
            this.concorrenteID = concorrenteID;
        }

        public int GetPosF()
        {
            return posicaoFinal;
        }
        
        public int GetDifLid()
        {
            return difLid;
        }

        public int GetDifAnt()
        {
            return difAnt;
        }
    }
}
