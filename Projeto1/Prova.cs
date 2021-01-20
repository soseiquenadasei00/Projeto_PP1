using System;
using System.Collections.Generic;
using System.Data;



namespace Projeto1
{
	public class Provas
	{
		// Variaveis
		//concorrenteID / concorrente
		public Dictionary<int, Concorrente> concorrentesEmProva;
		//Designacao da Etapa / etapa
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
				Console.WriteLine("Numero de Concorrente: {0} , tempo total da prova: {1} ", paraPrintar.Values[i], paraPrintar.Keys[i]);
			}

		}
		//Ambos os metodos devem ser chamados em conjunto!
		//A monstruosidade acaba aqui.




		//Alinea 4 - Numero de Provas Validas
		public int NumeroDeProvasValidas()
		{
			return ProvaValidaPor().Count;
		}

		// Alinea 5 - Apresentacao  das médias dos tempos por etapa e ordenado por ordem de ocorrência das etapas para provas validas.
		//Nao seria possivel criar um metodo que retorna a media dos tempos de uma etapa para provas validas na classe etapa
		//Pois, nao ha maneira de verificar, na classe etapa, se um concorrente tem ou nao a prova valida.
		public SortedList<string, float> TempoDasEtapasParaProvasValidas()
		{
			SortedList<string, float> aux = new SortedList<string, float>();
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
				aux.Add(e.designacao, media);
			}
			return aux;
		}

		//Metodo que numera as etapas de forma a podermos apresenta-las em ordem de ocorrencia no ecra.
		public Dictionary<int, string> NumerarEtapas()
        {
			Dictionary<int, string> EtapasNumeradas = new Dictionary<int, string>();
			foreach (Etapa e in etapasDaProva.Values)
            {
				if (e.designacao == "P C") //se apenas existir uma etapa na prova, entao retornamos logo. Obviamente, esta etapa apenas pode ser "P C"
				{
					EtapasNumeradas.Add(0, "P C");
					return EtapasNumeradas;
				} 
				else
                {
					if(e.designacao == "P E1") //Caso contrario, esperamos o foreach inteiro e adicionamos unicamente a primeira etapa
                    {
						if (!EtapasNumeradas.ContainsValue(e.designacao)) EtapasNumeradas.Add(EtapasNumeradas.Count, e.designacao);
					}
                }
            }

			foreach (Etapa e in etapasDaProva.Values) //Depois, enquanto nao aparecer a etapa que tem como ponto final 'C', adicionamos etapas a nossa lista.
            {
				if (e.designacao[3] != 'C')
                {
					if (!EtapasNumeradas.ContainsValue(e.designacao)) EtapasNumeradas.Add(EtapasNumeradas.Count, e.designacao);
				}
            }

			foreach (Etapa e in etapasDaProva.Values) //Finalmente, quando apenas restar uma etapa, esta apenas poderia acacar com 'C', entao, adicionamos ela na lista.
			{
				if (e.designacao[3] == 'C')
				{
					if (!EtapasNumeradas.ContainsValue(e.designacao)) EtapasNumeradas.Add(EtapasNumeradas.Count, e.designacao);
				}
			}
			return EtapasNumeradas;

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

		//Utilizamos o Metodo que nos retorna uma lista em Ordem descrescente de tempo de todos os concorrentes que efeturam uma prova valida.
		//Dessa forma conseguimos ir atribuindo as posicoes finais aos concorrentes por ordem descrescente. Confusingly but workingly!
		public void AtribuirPosF() 
		{
			foreach (int concorrenteID in ProvaValidaPorInversa().Values)
			{
				concorrentesEmProva[concorrenteID].posicaoFinal = ProvaValidaPorInversa().IndexOfValue(concorrenteID) + ProvaValidaPorInversa().Count-1;
			}
		}

		public void AtribuirDifLid()
		{
			foreach (Concorrente c in concorrentesEmProva.Values)
            {
				c.difLid = TempoTotalDoConcorrente(Vencedor()) - TempoTotalDoConcorrente(c.concorrenteID);
            }
		}

		//Para cada concorrente p, comparamos com um concorrente c. Se p estiver uma posicao acima de c, o tempo de c sera o tempo de p menos o tempo de c.
        public void AtribuirDifAnt()
        {
           foreach(Concorrente c in concorrentesEmProva.Values)
           {
				foreach(Concorrente p in concorrentesEmProva.Values)
                {
					if (p.posicaoFinal == c.posicaoFinal - 1)
                    {
						c.difAnt = TempoTotalDoConcorrente(p.concorrenteID) - (TempoTotalDoConcorrente(c.concorrenteID));
                    }
                }
           }
		   foreach (Concorrente c in concorrentesEmProva.Values) //Zera-se a diferenca de tempo para o anterior caso o concorrente seja o vencedor.
           {
				if (c.concorrenteID == Vencedor()) c.difAnt = 0;
           }

        }


		//Metodo importante para termos acesso aos concorrentes de forma ordenada pela posicao final, utilizamos este metodo para construir a tabela.
		public SortedList<int, Concorrente> Podio(){

			SortedList<int, Concorrente> podio = new SortedList<int, Concorrente>();
			foreach(Concorrente c in concorrentesEmProva.Values)
            {
				if (c.posicaoFinal == 1) podio.Add(c.posicaoFinal, c);
            }
			foreach (Concorrente c in concorrentesEmProva.Values)
			{
				if (c.posicaoFinal == podio.Count + 1) podio.Add(c.posicaoFinal, c);
			}
			return podio;
		}

		//Outro metodo para construir a tabela, desta vez, listamos todos os concorrente que nao possuem prova valida e temos entao uma lista para podermo acessa-los facilmente.
		public List<Concorrente> ConcorrentesInvalidos()
        {
			List<Concorrente> aux = new List<Concorrente>();

			foreach(Concorrente c in concorrentesEmProva.Values)
            {
				if (!ConcorrenteComProvaValida(c.concorrenteID)) aux.Add(c);
            }
			return aux;
        }


        //FIM (falta so adicionar a posicao_final de cada concorrente, e formatar os dados);
        public void TabelaClassificativa2()
        {

			AtribuirPosF();
			AtribuirDifLid();
			AtribuirDifAnt();
			List<Concorrente> aux = ConcorrentesInvalidos();
			Console.WriteLine(" ________________________________________________________________________________________________________");
			Console.WriteLine("|" +  " Posição " + "|" + "  Número  " + "|" + "   Nome   " + "|" + "Carro" + "\t\t|\t" + "Tempo da Prova" + "\t|\t" + "Di. Ant." + "|" + "   Di.Ldr." + "\t|");
			Console.WriteLine(" -------------------------------------------------------------------------------------------------------");
			foreach (int i in Podio().Keys)
			{
				
				Console.WriteLine("|" + "   {0}   " + "  |" + "    {1}     " + "|" + " {2} " + "\t|" + "{3}" + "\t\t|\t" + "{4}" + "\t\t|\t" + "{5}" + "\t|\t" + "{6}" + "\t|", Podio()[i].posicaoFinal, Podio()[i].concorrenteID, Podio()[i].nome, Podio()[i].carro, TempoTotalDoConcorrente(Podio()[i].concorrenteID), Podio()[i].difAnt, Podio()[i].difLid);
				Console.WriteLine(" -------------------------------------------------------------------------------------------------------");
			}
            foreach(Concorrente c in ConcorrentesInvalidos())
            {
				Console.WriteLine("|" + "  ---  " + "  |" + "    {0}     " + "|" + " {1} " + "\t|" + "{2}" + "\t\t|\t" + "---" + "\t\t|\t" + "---" + "\t|\t" + "---" + "\t|", c.concorrenteID, c.nome, c.carro);
				Console.WriteLine(" -------------------------------------------------------------------------------------------------------");
            }
        }
	}
}

	
	
