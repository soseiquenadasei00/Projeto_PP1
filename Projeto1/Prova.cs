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
		//Se nao existe nenhuma etapa da prova que o concorrente nao tenha participado, entao tem a prova valida.
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
				foreach (Etapa e in etapasDaProva.Values) //Percorremos todas as etapas da prova
				{
					foreach (int i in e.tempos.Keys) //Percorremos todos os tempos de todos concorrentes de uma etapa
					{
						if (i == concorrenteID) //Guardamos a soma de todos os tempos de um concorrente numa variavel que sera retornada pelo metodo
						{
							soma += e.tempos[concorrenteID];
						}
					}

				}

			}
			return soma;
		}

		//Retorna uma lista em ordem crescente com o numero do concorrente e a soma dos tempos das suas etapas, ou seja, o seu tempo total. Apenas para concorrentes com provas Validas!
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


		//Nois Fez esta monstruosidade, que troca as chaves com os valores da funcao ProvaValidaPor, para satisfazer a alinea 3 do enunciado
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
		//Ambos os metodos devem ser chamados em conjunto!
		//A monstruosidade acaba aqui.




		//Alinea 4 - Numero de Provas Validas
		public int NumeroDeProvasValidas()
		{
			return ProvaValidaPor().Count;
		}


		//CHECKAR ISTO NO PAPEL, NAO TENHO A CERTEZA SE ESTE METODO RETORNA A LISTA POR ORDEM DE OCORRENCIA DAS ETAPAS!!!!!
		// Alinea 5 - Apresentacao  das médias dos tempos por etapa e ordenado por ordem de ocorrência das etapas para provas validas.
		//Nao seria possivel criar um metodo que retorna a media dos tempos de uma etapa para provas validas na classe etapa
		//Pois, nao ha maneira de verificar, na classe etapa, se um concorrente tem ou nao a prova valida.
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
						soma += e.tempos[concorrenteID]; //Para cada concorrente que fez uma dada etapa, se esse concorrente tem a prova valida, entao guardamos o tempo dessa etapa na variavel soma
					}
					media = soma / ProvaValidaPor().Count;  //Para ter a media do tempo de cada etapa para provas validas, dividimos essa soma pelo numero de concorrentes com prova valida.
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
			string carromaisrapido = "";
			foreach (int concorrenteID in ProvaValidaPor().Keys)
			{
				if (min == 0) //Quando verificamos pela primeira vez o tempo de um concorrente, o tempo minimo que é possivel fazer uma prova será o tempo desse concorrente!
				{
					min = TempoTotalDoConcorrente(concorrenteID);
					carromaisrapido = concorrentesEmProva[concorrenteID].GetCarro(); //Guardamos entao o carro desse concorrente!
				}
				else if (TempoTotalDoConcorrente(concorrenteID) < min) //Comparamos o tempo de todos os outros concorrentes com o tempo minimo que um concorrente com prova valida fez a prova.
				{                                                       // Atualizando sempre a variavel minimo, com o menor tempototal que encontrarmos.
					min = TempoTotalDoConcorrente(concorrenteID);
					carromaisrapido = concorrentesEmProva[concorrenteID].GetCarro();  //Guardamos o carro do concorrente que tem o menor tempo total de prova
				}
			}
			return carromaisrapido;
		}

		//Exatamente o mesmo que o metodo anterior, no entanto para o concorrente com o carro mais lento
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
				if (tempototalmin == 0)
				{
					tempototalmin = TempoTotalDoConcorrente(concorrenteID);
					idDoVencedor = concorrenteID;
				}
				if (TempoTotalDoConcorrente(concorrenteID) < tempototalmin)
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
				if (concorrenteID == Vencedor()) //Se é o concorrente mais rapido a efetuar uma prova valida, entao é o vencedor.
				{
					foreach (Etapa e in etapasDaProva.Values) //Estamos entao a verificar os tempos de todas as etapas do vencedor
					{
						if (e.tempos[concorrenteID] > max) //Guardamos entao a etapa com o pior tempo
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
			foreach (Etapa e in etapasDaProva.Values) //Para todas as etapas, somamos em TempoMin o tempo minimo dessa etapa
			{
				tempoMin += e.TempoMinimo();
			}
			return tempoMin;
		}

		//Alinea 9 
		public float VelocidadeMedia()
		{
			//Calculo das velocidades medias totais = Tempo Total Prova / Distancia Total Prova 
			float soma_tempos = 0;
			float soma_distancia = 0;
			foreach (int concorrenteID in concorrentesEmProva.Keys)
			{
				if (ConcorrenteComProvaValida(concorrenteID)) //Para todos os concorrentes com prova valida, somamos o tempo total desses concorrentes
				{
					soma_tempos += TempoTotalDoConcorrente(concorrenteID);
				}
			}

			foreach (Etapa e in etapasDaProva.Values)
			{
				soma_distancia = +e.distancia; //Para cada etapa da prova somamos as distancias
			}

			return (soma_tempos / soma_distancia);  //retornamos a soma dos tempos dividido pela soma das distancias

		}
	}

}
	
	
