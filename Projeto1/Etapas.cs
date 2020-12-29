using System;
using System.Collections.Generic;

namespace Projeto1
{
	public class Etapa
	{
		
		
		//Para o ficheiro:
		//2 E1 E2 21672
		//1 P E1 10501
		//1 E1 E2 37203
		//2 P E1 12383
		//1 E2 C 28465
		//2 E2 C 23567
		//A etapda E1-E2, a sortedList tempos sera igual: 
		//new Dictionary<int,int>().Insert(2, 21672).Insert(1, 37203);
		//i.e ConcorrenteID / tempoDeEtapa;
		public Dictionary<int, int> tempos;


		public string designacao;
		//EX: "E1_E2" // "P_E1" // "E2_C"


		private float distancia;

		// construtor 
		public Etapa(string designacao) 
        {
			this.designacao = designacao;
			distancia = 0;
			tempos = new Dictionary<int, int>();
        }

		//MUITO IMPORTANTE
		//FUNCAO A CORRER PARA CADA CONCORRENTE QUE EFETUOU UMA QUALQUER ETAPA
		public void AdicionarConcorrenteETempo(int concorrenteID, int tempo)
        {
			tempos.Add(concorrenteID, tempo);
        }


		//Metodos
		public void SetDistancia(float n)
        {
			this.distancia = n;
        }


		//tempo medio da etapa por todos os concorrentes
		public float TempoMedio()
        {
			int soma = 0;
			foreach (int tempo in tempos.Values)
            {
				soma += tempo;
            }

			float media = (soma / tempos.Count);

			return media;
        }
		// Função que retornar o menor tempo
		public int TempoMinimo()
        {
			int minimo = 9999999;
			
			foreach(int tempo in tempos.Values)
            {
				if (tempo < minimo) minimo = tempo;
				
            } 
			return minimo;
        }



		//Determina se um concorrente participou da etapa. Utilizada como auxiliar para determinar se o concorrente tem prova valida
		public bool ConcorrenteParticipou(int concorrenteID)
        {
			return tempos.ContainsKey(concorrenteID);		
        }
	}
}