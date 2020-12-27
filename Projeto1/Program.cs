using System;
using System.Collections.Generic;

namespace Projeto1
{
	class Program
	{
		static void Main(string[] args)
		{
			// Read each line of the file into a string array. Each element of the array is one line of the file.
			//encontrado num documento da microsoft e feito o glorioso copy-paste
			//string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\Ficheiro_que_o_prof_vai_mandar.txt");

			//Interface.LerFicheiro();
			Console.WriteLine("TESTE");
			

			//uma vez que estou a deixar a leitura dos ficheiros para depois, vou criar aqui alguns objetos para testar os metodos

			Concorrente joao = new Concorrente(1,"joao", "subaru");
			Concorrente maria = new Concorrente(2,"Maria", "mini cooper s");
			Concorrente jose = new Concorrente(3,"jose", "corolla");

			Etapa p_e1 = new Etapa();
			p_e1.SetDistancia(2500);
			Etapa e1_c = new Etapa();
			e1_c.SetDistancia(4000);

			p_e1.AdicionarConcorrenteETempo(1, 27542);
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



			SortedList<int, int> paraPrintar = rally1.ProvaValidaPor();
			for(int i = 0; i < paraPrintar.Count; i++ )
            {
				Console.WriteLine("{0} , {1} " , paraPrintar.Keys[i], paraPrintar.Values[i]);
            }

			Console.WriteLine("SEPARADOR");

			SortedList<int, float> paraPrintar2 = rally1.TempoDasEtapasParaProvasValidas();
			for (int i = 0; i < paraPrintar2.Count; i++)
			{
				Console.WriteLine("{0} , {1} ", paraPrintar2.Keys[i], paraPrintar2.Values[i]);
			}

			Console.WriteLine(rally1.CarroMaisRapido());

			Console.WriteLine(rally1.PiorEtapaDoVencedor());












			/* 
			exemplo de ficheiro de testo e consequentemente do array de strings - lines
			2 E1 E2 21672
			1 P E1 10501
			1 E1 E2 37203
			2 P E1 12383
			1 E2 C 28465
			2 E2 C 23567
			*/

			// ou seja, sera sempre 1 numero inteiro, seguido de um espaço, seguido de uma string(?) seguido de outro espaço, seguido por um tempo. Para cada etapa.


			//sera que conseguimos transformar esses elementos da primeira string(que é uma linha toda) numa string normal(1 elemento = 1 caracter) assim?
			//string informacoes = (string)string[] lines;

		}
	}
}
