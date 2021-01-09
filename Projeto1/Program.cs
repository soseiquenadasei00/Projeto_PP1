using System;
using System.Collections.Generic;

namespace Projeto1
{
	class Program
	{
		static void Main(string[] args)
		{

		    Provas rally2 = new Provas();

			int opc = 1;

			Console.WriteLine("Competição de carros do EDJD");
			while (opc != 0)
			{
				Console.WriteLine("Por favor, introduza o nome do ficheiro com os concorrentes");
				string ficheirosconcorrentes = Console.ReadLine();
				try
				{
					Interface.LerConcorrentes(rally2, ficheirosconcorrentes);
				}
				catch
				{
					Console.WriteLine("POXA PROFESSOR, PRECISA COLOCAR O NOME CERTO.");
				}

				Console.WriteLine("Por favor, introduza o nome do ficheiro com as etapas");
				string ficheirodasetapas = Console.ReadLine();
				try
				{
					Interface.LerEtapas(rally2, ficheirodasetapas);
				}
				catch
				{
					Console.WriteLine("DE NOVO??? POXA PROFESSOR, PRECISA COLOCAR O NOME CERTO.");
				}

				Console.WriteLine("Por favor, introduza o nome do ficheiro com as distancias");
				string ficheiroDasDistancias = Console.ReadLine();
				try
				{
					Interface.LerDistancias(rally2, ficheiroDasDistancias);
				}
				catch
				{
					Console.WriteLine("BRINCADEIRA VIU!! ERROU DE NOVO??? COLOCA O NOME CERTO PELO AMOR");
				}
				Console.WriteLine("Verifique que não há neenhum erro, digite 0 para continuar");
				opc = int.Parse(Console.ReadLine());
			}

			Console.Clear();

			Console.WriteLine();

			Console.WriteLine("Competição de carros do EDJD");

			Console.WriteLine("1-Para saber o número de concorrentes que estão em prova");
			Console.WriteLine("2-Para saber o número de concorrentes que possuem as provas validas");
			Console.WriteLine("3-Para saber o tempo de todos os concorrentes que efetuaram uma prova valida por ordem decrescente");
			Console.WriteLine("4-Para saber as médias dos tempos por etapa");
			Console.WriteLine("5-Pra saber quem foi o carro mais rápido e o mais lento na competição");
			Console.WriteLine("6-Para saber qual foi a etapa mais lenta do melhor concorrente");
			Console.WriteLine("7-Para saber qual é o menor tempo em que é possível efetuar a prova na totalidade independentemente de ser uma prova vailida ou não");
			Console.WriteLine("8-Para saber quem foi o vencedor");
			Console.WriteLine("9-Tabela classificativa da prova");
			Console.WriteLine("0 - Sair");
			int op;
			op = int.Parse(Console.ReadLine());
			do
			{
				switch (op)
				{
					case 1:
						Console.WriteLine(rally2.NumeroConcorrentesEmProva());
						break;

					case 2:
						Console.WriteLine(rally2.NumeroDeProvasValidas());
						break;
					case 3:
						rally2.printTempoDecre();
						break;
					case 4:
						Console.WriteLine(rally2.TempoDasEtapasParaProvasValidas());
						break;
					case 5:
						Console.WriteLine("O carro mais rapido foi :" + rally2.CarroMaisRapido() + "O carro mais lento foi:" + rally2.CarroMaisLento());
						break;
					case 6:
						Console.WriteLine("A etapa mais lenta do vencedor foi:" + rally2.PiorEtapaDoVencedor());
						break;
					case 7:
						Console.WriteLine(rally2.MenorTempoPossivel());
						break;
					case 8:
						Console.WriteLine(rally2.Vencedor());
						break;
					//case 9:Console.WriteLine();

					default:
						Console.WriteLine("Escreva o numero corretamente");
						break;
				}
			} while (op != 0 && op < 10);
			
			return;



			//Metodos da classe etapa

			Console.WriteLine("tempo medio para a etapa P E1:  " + rally2.etapasDaProva["P E1"].TempoMedio()); 
			Console.WriteLine("concorrente 1 participou da etapa E1 E2?" + rally2.etapasDaProva["E1 E2"].ConcorrenteParticipou(1)); //retorna true

			Console.WriteLine("tempo medio para a etapa E2 C:  " + rally2.etapasDaProva["E2 C"].TempoMedio());


			//metodos da classe prova

			Console.WriteLine("numero de concorrentes em prova :" + rally2.NumeroConcorrentesEmProva()); 
			Console.WriteLine("Concorrente 1 tem prova valida?" + rally2.ConcorrenteComProvaValida(1)); 
			Console.WriteLine("tempo total do concorrente 1 : " + rally2.TempoTotalDoConcorrente(1));
			Console.WriteLine("Velocidade Media da etapa 1:  " + rally2.VelocidadeMedia());

			rally2.printTempoDecre();

			Console.WriteLine("SEPARADOR");

			SortedList<int, float> paraPrintar2 = rally2.TempoDasEtapasParaProvasValidas();
			for (int i = 0; i < paraPrintar2.Count; i++)
			{
				Console.WriteLine("etapa: {0} ,tempo medio da etapa: {1} ", paraPrintar2.Keys[i], paraPrintar2.Values[i]);
			}

			Console.WriteLine("Carro do vencedor: {0} ", rally2.CarroMaisRapido());

			Console.WriteLine("Pior etapa do vencedor {0} ", rally2.PiorEtapaDoVencedor());













			return;




			//uma vez que estou a deixar a leitura dos ficheiros para depois, vou criar aqui alguns objetos para testar os metodos

			Concorrente joao = new Concorrente(1,"joao", "subaru");
			Concorrente maria = new Concorrente(2,"Maria", "mini cooper s");
			Concorrente jose = new Concorrente(3,"jose", "corolla");
			
			


			Etapa p_e1 = new Etapa("p_e1");
			p_e1.SetDistancia(2500);
			Etapa e1_c = new Etapa("e1_c");
			e1_c.SetDistancia(4000);

			p_e1.AdicionarConcorrenteETempo(1, 18000);
			e1_c.AdicionarConcorrenteETempo(1, 54234);

			p_e1.AdicionarConcorrenteETempo(2, 43235);

			p_e1.AdicionarConcorrenteETempo(3, 23453);
			e1_c.AdicionarConcorrenteETempo(3, 45642);


			Provas rally1 = new Provas();

			rally1.AdicionarConcorrente(joao);
			rally1.AdicionarConcorrente(maria);
			rally1.AdicionarConcorrente(jose);
			rally1.AdicionarEtapa(p_e1);
			rally1.AdicionarEtapa(e1_c);

			

			//metodos da classe etapa

			Console.WriteLine("tempo medio para a etapa 1:  " + p_e1.TempoMedio()); //retorna algo por volta de 35000
			Console.WriteLine("concorrente 1 participou?" + p_e1.ConcorrenteParticipou(1)); //retorna true

			Console.WriteLine("tempo medio para a etapa 2:  " + e1_c.TempoMedio()); //retorna 54234
			Console.WriteLine("concorrente 2 participou?" + e1_c.ConcorrenteParticipou(2)); //retorna false

			//metodos da classe prova

			Console.WriteLine("numero de concorrentes em prova :" + rally1.NumeroConcorrentesEmProva()); //retorna 3
			Console.WriteLine("Concorrente 1 tem prova valida?" + rally1.ConcorrenteComProvaValida(1)); //retorna true
			Console.WriteLine("tempo total do concorrente 1 : " + rally1.TempoTotalDoConcorrente(1)); //retorna +-83000

			rally1.printTempoDecre();

			Console.WriteLine("SEPARADOR");

			SortedList<int, float> paraPrintar3 = rally1.TempoDasEtapasParaProvasValidas();
			for (int i = 0; i < paraPrintar3.Count; i++)
			{
				Console.WriteLine("etapa: {0} ,tempo medio da etapa: {1} ", paraPrintar3.Keys[i], paraPrintar3.Values[i]);
			}

			Console.WriteLine("Carro do vencedor: {0} " , rally1.CarroMaisRapido());

            Console.WriteLine("Pior etapa do vencedor {0} ", rally1.PiorEtapaDoVencedor());



		}
	}
}
