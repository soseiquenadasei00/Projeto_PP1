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
		public Dictionary<string, Etapa> etapasDaProva;
		

		//Construtor e Metodos basicos
		public Provas()
		{
			concorrentesEmProva = new Dictionary<int, Concorrente>();
			etapasDaProva = new Dictionary<string, Etapa>();
		}
		public void AdicionarEtapa(Etapa e)
		{
			if (!etapasDaProva.ContainsKey(e.designacao))
			{
				etapasDaProva.Add(e.designacao, e);
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
			if (etapasDaProva.Count != 0)
			{
				foreach (Etapa e in etapasDaProva.Values)
				{
					foreach (int i in e.tempos.Keys)
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
			for (int i = paraPrintar.Count - 1; i >= 0; i--)
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

		//TO DO: RETORNAR CONCORRENTE
		// Alinea 6  - Apresentação do carro mais rápido / mais lento a efetuar uma prova válida;
		public string CarroMaisRapido()
		{
			int min = 0;
			string carromaisrapido = "";
			foreach (int concorrenteID in ProvaValidaPor().Keys)
			{
				if (min == 0)
				{
					min = TempoTotalDoConcorrente(concorrenteID);
					carromaisrapido = concorrentesEmProva[concorrenteID].GetCarro();
				}
				else if (TempoTotalDoConcorrente(concorrenteID) < min)
				{
					min = TempoTotalDoConcorrente(concorrenteID);
					carromaisrapido = concorrentesEmProva[concorrenteID].GetCarro();
				}
			}
			return carromaisrapido;
		}
		public string CarroMaisLento()
		{
			int max = 0;
			string carromaislento = "";
			foreach (int concorrenteID in ProvaValidaPor().Keys)
			{
				if (max == 0)
				{
					max = TempoTotalDoConcorrente(concorrenteID);
					carromaislento = concorrentesEmProva[concorrenteID].GetCarro();
				}
				else if (TempoTotalDoConcorrente(concorrenteID) > max)
				{
					max = TempoTotalDoConcorrente(concorrenteID);
					carromaislento = concorrentesEmProva[concorrenteID].GetCarro();
				}
			}
			return carromaislento;
		}

		//Metodo Auxiliar - De todos os que realizaram uma prova valida, retorna o vencedor
		public int Vencedor()
		{
			int idDoVencedor = 0;
			int tempototalmin = 0;
			foreach (int concorrenteID in ProvaValidaPor().Keys)
			{
				if (TempoTotalDoConcorrente(concorrenteID) > tempototalmin)
				{
					tempototalmin = TempoTotalDoConcorrente(concorrenteID);
					idDoVencedor = concorrenteID;
				}
			}
			return idDoVencedor;
		}

		//Alinea 7 - Cálculo do tempo da etapa mais lenta do concorrente mais rápido a efetuar uma prova valida
		public int PiorEtapaDoVencedor()
		{
			int max = 0;
			foreach (int concorrenteID in concorrentesEmProva.Keys)
			{
				if (concorrenteID == Vencedor())
				{
					foreach (Etapa e in etapasDaProva.Values)
					{
						if (e.tempos[concorrenteID] > max)
						{
							max = e.tempos[concorrenteID];
						}
					}
				}
			}
			return max;
		}

		//Alinea 8 - Cálculo do menor tempo em que é possível efetuar a prova na totalidade, ou seja, soma
		//dos tempos mínimos por etapa independentemente de terem sido efetuados por
		//concorrentes com provas válidas ou não;

		public int MenorTempoPossivel()
		{
			int tempoMin = 0;
			foreach (Etapa e in etapasDaProva.Values)
			{
				tempoMin += e.TempoMinimo();
			}
			return tempoMin;
		}

		//Alinea 9 
		public float VelocidadeMedia()
		{
			//Calculo das velocidades medias totais = Tempo Total Prova / Distancia Total Prova 
			float velocidademedia = 0;
			float soma_tempos = 0;
			float soma_distancia = 0;
			foreach (int concorrenteID in concorrentesEmProva.Keys)
			{
				if (ConcorrenteComProvaValida(concorrenteID) == true)
				{
					foreach (Etapa e in etapasDaProva.Values)
					{
						foreach (int i in e.tempos.Values)
						{
							soma_tempos += i;
						}
					}
				}
			}

			foreach(Etapa e in etapasDaProva.Values)
            {
				soma_distancia =+ e.distancia;
            }

			velocidademedia = soma_tempos / soma_distancia;

				return velocidademedia;
			}
		}
	}


	
	
