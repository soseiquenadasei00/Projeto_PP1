using System;
using System.Collections.Generic;

namespace Projeto1
{
	public class Provas
	{
		// Variaveis
		public Dictionary<int, Concorrente> concorrentesEmProva;
		public Dictionary<int, Etapa> etapasDaProva;





		
		public bool ConcorrenteComProvaValida(int concorrenteID)
        {
			foreach (Etapa e in etapasDaProva.Values)
            {
				if (!e.ConcorrenteParticipou(concorrenteID)) return false;
            }
			return true;
        }
		

		// Retorna uma lista com todos concorrentes c, tais que c passou por todas as etapas
		public List<int> ProvaValidaPor()
        {
			List<int> aux = new List<int>();
			foreach (int concorrenteID in concorrentesEmProva.Keys)
			{
				if (ConcorrenteComProvaValida(concorrenteID)) aux.Add(concorrenteID);
            }
			return aux;
        }
	}
}
	
	
