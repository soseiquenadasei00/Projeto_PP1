using System;
using System.Collections;


namespace Projeto1
{

    public class Concorrente
    {
        public int numero;
        public int quantidade;
        public string nome;
        public string carro;
        public int posicao;
        public double tempoEtapa;
        public double tempoTotal;


        public Concorrente(int numero; string nome, string carro)
            {
                this.numero = numero;
                this.nome = nome;
                this.carro = carro;
            }

    public double CalcularTempo()
    {
        tempoTotal = tempoEtapa * numeroEtapas;
    }

    public bool ProvaValida(Concorrente c)
    {

    }
}
