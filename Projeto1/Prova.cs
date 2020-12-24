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

		//Alinea 3 - Lista com todos concorrentes que efetuaram uma prova valida. So chamar a funcao com .count. 
		// Retorna uma lista com todos concorrentes c, tais que c passou por todas as etapas
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
	
	
