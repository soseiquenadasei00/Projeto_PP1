using System;

namespace Projeto1
{
	class Program
	{
		static void Main(string[] args)
		{
			// Read each line of the file into a string array. Each element of the array is one line of the file.
			//encontrado num documento da microsoft e feito o glorioso copy-paste
			//string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\Ficheiro_que_o_prof_vai_mandar.txt");


			Console.WriteLine("TESTE");

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
