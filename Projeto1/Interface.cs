using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projeto1
{
    public class Interface
    {


        //Primeiro valor = conccorenteID
        //Segundo valor = objeto da classe Etapa
        //Terceriro valor = Dicitionary<ConcorrenteID, tempo> tempos



        //Metodo para criar as diversas classes
        public static void LerFicheiro(Concorrente a)
        {
            using (StreamReader reader = new StreamReader("concorrentes.txt"))
            {
                //Leitura de todos os caracteres do ficheiro de texto
                string s = reader.ReadLine();
                //Utilizacao do array conteudo para guardar cada um dos valores econtrados apos um espaco(split);
                //Primeiro e ultimo valor tambem sao armazenados
                string[] conteudo = s.Split(' ');

                //Escrita dos valores do array conteudo

                foreach (var item in conteudo)
                {
                    Console.WriteLine(item.ToString());
                }



                //Atribuicao dados do array conteudo nas respetivas variaveis
                /*a.concorrenteID = (int)conteudo.GetValue(0);*/
                
                

               



            }

    }


        /*
        //Metodo para verificar os dados da lista_concorrentes e atribui-los aos respetivos dicionarios
        public static void VerificaDados(List<string> lista_concorrentes)
        {
             using (StreamReader reader = new StreamReader("concorrentesteste.txt"))
            {
                string line = "";

                while (!String.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    line // encontrar a propriedade indicada para adicionar cada dado encontrado apos o espaco 

                }

            } 
        }
        */



    }
}
