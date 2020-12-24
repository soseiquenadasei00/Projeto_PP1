using System;
using System.Collections.Generic;

namespace Projeto1
{
	public class Provas
	{
		// Variaveis
		public Dictionary<int, Concorrente> concorrentesEmProva;
		public Dictionary<int, Etapa> etapasDaProva;



		

		//Alinea 2 - Numero de concorrentes em prova
		public int NumeroConcorrentesEmProva()
		{
			return concorrentesEmProva.Count;
		}



		//Aux, testa se um concorrente c tem prova valida
		public bool ConcorrenteComProvaValida(int concorrenteID)
        {
			foreach (Etapa e in etapasDaProva.Values)
            {
				if (!e.ConcorrenteParticipou(concorrenteID)) return false;
            }
			return true;
        }
		

		//Aux, tempo total de um concorrente na prova
		public int TempoTotalDoConcorrente(int concorrenteID) 
		{
			int soma = 0;
			if (etapasDaProva.Count != 0) {
				foreach(Etapa e in etapasDaProva.Values)
				{
					foreach(int i in e.tempos.Keys)
					{
						if (i == concorrenteID) 
						{
							soma += e.GetTempo(concorrenteID);
						}
					} 

				}
			
			}
			return soma;
		}

		//Alinea 3 - Lista ordenada em ordem descrescente com todos concorrentes que efetuaram uma prova valida. 
		//Para pegar o numero de concorrentes -- chamar a funcao com .count. 
		
		//falta garantir a ordem. talvez?
		public SortedList<int,int> ProvaValidaPor()
        {
			SortedList<int,int> aux = new SortedList<int,int>();
			foreach (int concorrenteID in concorrentesEmProva.Keys)
			{
				if (ConcorrenteComProvaValida(concorrenteID)) aux.Add(concorrenteID, TempoTotalDoConcorrente(concorrenteID));
            }
			return aux;
        }

		
		
		
		
	}
}
	
	
