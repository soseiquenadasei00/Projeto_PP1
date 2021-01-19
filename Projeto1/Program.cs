using System;
using System.Collections.Generic;
using System.Data;

namespace Projeto1
{
	class Program
	{
		static void Main(string[] args)
		{

		    Provas rally2 = new Provas();
			int opc = 1;
			Console.WriteLine("\t" + "\t" + "Competição de carros do EDJD");
			Console.WriteLine("\n" + "\n");
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
				Console.WriteLine("\n" + "\n");


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
				Console.WriteLine("\n" + "\n");


				Console.WriteLine("Por favor, introduza o nome do ficheiro com as distancias");
				string ficheirodasdistancias = Console.ReadLine();
				try
				{
					Interface.LerDistancias(rally2, ficheirodasdistancias);
				}
				catch
				{
					Console.WriteLine("BRINCADEIRA VIU!! ERROU DE NOVO??? COLOCA O NOME CERTO PELO AMOR");
				}
				Console.WriteLine("\n");
			
				
				Console.WriteLine("Verifique que não há nenhum erro, digite 0 para entrar no santuário!");
				opc = int.Parse(Console.ReadLine());
				Console.Clear();
			}


			Console.WriteLine("\t" + "\t" + "Competição de carros do EDJD");
			Console.WriteLine("\n" + "\n");

			int op = -1;
			do
            {
				Console.WriteLine("1 - Para saber o número de concorrentes que estão em prova / número de concorrentes que efetuaram uma prova válida");
				Console.WriteLine("2 - Para saber o tempo de todos os concorrentes que efetuaram uma prova valida por ordem decrescente");
				Console.WriteLine("3 - Para saber as médias dos tempos por etapa");
				Console.WriteLine("4 - Para saber quem foi o carro mais rápido e o mais lento na competição");
				Console.WriteLine("5 - Para saber qual foi a etapa mais lenta do melhor concorrente, que confuso!");
				Console.WriteLine("6 - Para saber qual é o menor tempo em que é possível efetuar a prova");
				Console.WriteLine("7 - Para saber quem foi o vencedor");
				Console.WriteLine("8 - Para saber a velocidade média da prova");
				Console.WriteLine("9 - Para ter acesso à tabela classificativa da prova");
				Console.WriteLine("0 - Se estiver pronto para avaliar este grupo com a cotação máxima e sair do programa!");
				op = int.Parse(Console.ReadLine());
				switch (op)
                {
                    case 1:
						Console.Clear();
                        Console.WriteLine("Numero de concorrentes em prova: {0}" + "\n" + "Numero de provas validas: {1}", rally2.NumeroConcorrentesEmProva(), rally2.NumeroDeProvasValidas());
						Console.WriteLine("\n" + "\n" + "\n");
						break;
                    case 2:
						Console.Clear();
						rally2.printTempoDecre();
						Console.WriteLine("\n" + "\n" + "\n");
						break;
                    case 3:
						Console.Clear();
						for (int i = 0; i < rally2.TempoDasEtapasParaProvasValidas().Count; i++)
						{
							Console.WriteLine(rally2.TempoDasEtapasParaProvasValidas().Keys[i] + ": " + rally2.TempoDasEtapasParaProvasValidas().Values[i]);
                        }
						Console.WriteLine("\n" + "\n" + "\n");
						break;
                    case 4:
						Console.Clear();
						Console.WriteLine("O carro mais rapido foi: " + rally2.CarroMaisRapido() + "\n" + "O carro mais lento foi: " + rally2.CarroMaisLento());
						Console.WriteLine("\n" + "\n" + "\n");
						break;
                    case 5:
						Console.Clear();
						Console.WriteLine("A etapa mais lenta do vencedor foi: " + rally2.PiorEtapaDoVencedor());
						Console.WriteLine("\n" + "\n" + "\n");
						break;
                    case 6:
						Console.Clear();
						Console.WriteLine("*BEEP BEEP*...O menor tempo possivel efetuar para uma prova valida, segundo meus calculos é: {0} " , rally2.MenorTempoPossivel());
						Console.WriteLine("\n" + "\n" + "\n");
						break;
                    case 7:
						Console.Clear();
						foreach (Concorrente c in rally2.concorrentesEmProva.Values)
                        {
							if (c.concorrenteID == rally2.Vencedor()) Console.WriteLine("O vencedor foi o concorrente nº: {0}" + "\t" + "Parabens, {1}!", c.concorrenteID, c.nome);
                        }
						
						Console.WriteLine("\n" + "\n" + "\n");
						break;
                    case 8:
						Console.Clear();
						Console.WriteLine("A velocidade média da prova foi: {0}" + "\n" + "Que rápido!", rally2.VelocidadeMedia());
						Console.WriteLine("\n" + "\n" + "\n");
						break;
                    case 9:
						Console.Clear();
						rally2.TabelaClassificativa();
						Console.WriteLine("\n" + "\n" + "\n");
						break;
					case 0:
						Console.Clear();
						break;
                    default:
                        Console.WriteLine("Escreva o numero corretamente!");
                        break;
                }
            } while (op != 0);

			Console.WriteLine("Esperamos que o entediante trabalho de avaliar trabalhos tenha sido menos monótono!" + "\n" + "Até ao próximo semestre, professor!");
            return;

		}
	}
}
