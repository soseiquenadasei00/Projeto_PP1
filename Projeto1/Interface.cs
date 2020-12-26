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
        public static void LerFicheiro()
        {
            using (StreamReader reader = new StreamReader("concorrentes.txt"))
            {

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                  
                    
                }

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
