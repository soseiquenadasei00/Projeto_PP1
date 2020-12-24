using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projeto1
{
    class Interface
    {


        
        private Dictionary<int, Provas> provas_dic;


        //Metodo para criar os dados da classe Concorrente
        public static void InicializaConcorrentes()
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

        //Metodo para verificar os dados da lista_concorrentes e atribui-los aos respetivos dicionarios
        public static void VerificaDados(List<string> lista_concorrentes)
        {
             using (StreamReader reader = new StreamReader("concorrentes.txt"))
            {
                string line = "";

                while (!String.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    line // encontrar a propriedade indicada para adicionar cada dado encontrado apos o espaco 

                }

            } 
        }

       





    }
}
