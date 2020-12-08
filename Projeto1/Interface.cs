using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projeto1
{
    class Interface
    {
        //Metodo para criar os dados da classe Concorrente
        public static void Concorrentes()
        {
            //Leitura do ficheiro do texto para criar os Concorrentes
            List<string> lista_concorrentes = new List<string>();
            using (StreamReader reader = new StreamReader("concorrentes.txt"))
            {

                string line = "";

                while (!String.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    lista_concorrentes.Add(line);

                }

                // Imprimir ficheiro na consola
                foreach (var item in lista_concorrentes)
                {
                    Console.WriteLine(item);
                }


            }

        }
    }
}
