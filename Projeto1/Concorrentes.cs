using System;
using System.Collections;


namespace Projeto1
{

    public class Concorrente
    {

        // Variaveis
        public int numero; // Numero do participante
        public int quantidade; // Quantidade de participantes
        public string nome; // Nome do participante
        public string carro; // Carro do participante
        public string[] etapa_realizada; //Atribuir as etapas realizadas, aquando a leitura do ficheiro. (Exemplo 2 E1 E2)

        //teste

        //Construtor

        public Concorrente(int numero, string nome, string carro)
        {
            this.numero = numero;
            this.nome = nome;
            this.carro = carro;
        }


        //Instancias
        public int nParticipante (int n) // devolve o numero do participante
        {
            return (n = numero);
        }

        public int nquant (int qt) // Devolve a quantidade de participantes 
        {
            return (qt = quantidade);
        }
        
        public string nomePart (string nm) // Devolve o nome do participante 
        {
            return (nm = nome);
        }

        public string ncarro (string car) // Devolve o nome do carro
        {
            return (car = carro);
        }




    }
    
}
