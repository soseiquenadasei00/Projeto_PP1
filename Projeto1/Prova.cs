using System;
using System.Collections.Generic;

namespace Projeto1
{
	public class Provas
	{
		// Variaveis
		//concorrenteID / concorrente
		public Dictionary<int, Concorrente> concorrentesEmProva;
		//numero da Etapa / etapa
		public Dictionary<int, Etapa> etapasDaProva;
		int numeroEtapas; //auxiliar, pouco importante, usado para adicionar etapas quando criamos o objeto provas


		//Construtor e Metodos basicos
		public Provas()
        {
			concorrentesEmProva = new Dictionary<int, Concorrente>();
			etapasDaProva = new Dictionary<int, Etapa>();
			numeroEtapas = 0;
        }

		public void AdicionarEtapa(Etapa e)
		{
			numeroEtapas++;
			if (!etapasDaProva.ContainsValue(e))
			{
					etapasDaProva.Add(numeroEtapas, e);
			}
		}

		public void AdicionarConcorrente(Concorrente c)
        {
			if (!concorrentesEmProva.ContainsValue(c))
			{	
				concorrentesEmProva.Add(c.concorrenteID, c);
			}	
        }
		

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
							soma += e.tempos[concorrenteID];
						}
					} 

				}
			
			}
			return soma;
		}

		//Metodo auxilar, para fazer tudo o resto, nao mexer!!!!!
		public SortedList<int, int> ProvaValidaPor()
		{

			SortedList<int, int> aux = new SortedList<int, int>();

			foreach (int concorrenteID in concorrentesEmProva.Keys)
			{
				if (ConcorrenteComProvaValida(concorrenteID))
				{
					aux.Add(concorrenteID, TempoTotalDoConcorrente(concorrenteID));
				}

			}
			return aux;
		}






		//Nois Fez esta monstruosidade, que troca as chaves com os valores da funcao a cima para poder printar em ordem descrecente depois
		//Alinea 3 - Lista ordenada em ordem descrescente com todos concorrentes que efetuaram uma prova valida. 
		//Alinea 4 - Para pegar o numero de concorrentes -- chamar a funcao com .count. 
		public SortedList<int, int> ProvaValidaPorInversa()
		{

			SortedList<int, int> aux = new SortedList<int, int>();

			foreach (int concorrenteID in concorrentesEmProva.Keys)
			{
				if (ConcorrenteComProvaValida(concorrenteID))
				{
					aux.Add(TempoTotalDoConcorrente(concorrenteID), concorrenteID);
				}

			}
			return aux;
		}
		//Função que printa o tempo(valido) dos concorrentes do maior para o menor.
		public void printTempoDecre()
		{

			SortedList<int, int> paraPrintar = ProvaValidaPorInversa();
			for (int i = 0; i < paraPrintar.Count; i++)
			{
				Console.WriteLine("Numero de Concorrente: {0} , tempo: {1} ", paraPrintar.Values[i], paraPrintar.Keys[i]);
			}

		}
		//A monstruosidade acaba aqui.






		//Alinea 4 - Numero de Provas Validas
		public int NumeroDeProvasValidas()
        {
			return ProvaValidaPor().Count;
        }

		// Alinea 5 - Apresentacao  das médias dos tempos por etapa e ordenado por ordem de ocorrência das etapas para provas validas.
		public SortedList<int, float> TempoDasEtapasParaProvasValidas()
        {
            int contador = 1;
            SortedList<int, float> aux = new SortedList<int, float>();
            foreach (Etapa e in etapasDaProva.Values)
            {
				int soma = 0;
				float media = 0;
				foreach (int concorrenteID in e.tempos.Keys)
                {
                    if (ConcorrenteComProvaValida(concorrenteID))
                    {
						soma += e.tempos[concorrenteID];
                    }
					media = soma / ProvaValidaPor().Count;
				}
				aux.Add(contador, media);
				contador++;
			}
            return aux;
        }

		// Alinea 6  - Apresentação do carro mais rápido / mais lento a efetuar uma prova válida;
		public string CarroMaisRapido()
        {
			int min = 0;
			string carro = "";
			foreach (int concorrenteID in ProvaValidaPor().Keys)
            {
				if (min == 0 ) min = TempoTotalDoConcorrente(concorrenteID);
				else if (TempoTotalDoConcorrente(concorrenteID) < min)
				{
					min = TempoTotalDoConcorrente(concorrenteID);
					carro = concorrentesEmProva[concorrenteID].GetCarro();
				}
            }
			return carro;
        }

		//Alinea 7 - Cálculo do tempo da etapa mais lenta do concorrente mais rápido a efetuar uma prova valida
		public int PiorEtapaDoVencedor()
        {
			string carroDoVencedor = CarroMaisRapido();
			int max = 0;
			foreach(int concorrenteID in concorrentesEmProva.Keys)
            {
				if (concorrentesEmProva[concorrenteID].carro == carroDoVencedor)
                {
					foreach(int numeroEtapa in etapasDaProva.Keys)
                    {
						max = etapasDaProva[numeroEtapa].tempos[concorrenteID];
						if (etapasDaProva[numeroEtapa].tempos[concorrenteID] > max) max = etapasDaProva[numeroEtapa].tempos[concorrenteID];
					}
                }
            }
			return max;
        }

		//Alinea 8 - Cálculo do menor tempo em que é possível efetuar a prova na totalidade, ou seja, soma
					//dos tempos mínimos por etapa independentemente de terem sido efetuados por
					//concorrentes com provas válidas ou não;

		//public int MenorTempoPossivel()
  //      {
		//	int tempoMin = 0;
		//	foreach(Etapa e in etapasDaProva.Values)
  //          {
		//		foreach(int concorrenteID in e.tempos.Keys)
  //              {
		//			tempoMin =
  //              }
  //          }
  //      }

    }
}
	
	
