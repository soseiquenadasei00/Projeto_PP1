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


		private int distancia;

		// construtor 
		public Etapa() 
        {
			distancia = 0;
			tempos = new Dictionary<int, int>();
        }


		//Metodos
		public void SetDistancia(int n)
        {
			distancia = n;
        }

		public float TempoMedio()
        {
			int soma = 0;
			foreach (int tempo in tempos.Values)
            {
				soma += tempo;
            }

			return (soma / tempos.Count);
        }

		public bool ConcorrenteParticipou(int concorrenteID)
        {
			return tempos.ContainsKey(concorrenteID);		
        }

		public int GetTempo(int concorrenteID)
		{  
			int tempo = 0;
			if (ConcorrenteParticipou(concorrenteID)) tempo = tempos[concorrenteID];
			return tempo;
		}

		
	}
}