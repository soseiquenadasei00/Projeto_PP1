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
        public string[] etapa_realizada; //Atribuir as etapas realizadas, aquando a leitura do ficheiro. (Exemplo 2 E1 E2) ????????????
        public int posicaoFinal;
        public int tempoTotalDaProva;

        //Construtor

        public Concorrente(int numero, string nome, string carro)
        {
            this.concorrenteID = numero;
            this.nome = nome;
            this.carro = carro;
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
    }
    
}
