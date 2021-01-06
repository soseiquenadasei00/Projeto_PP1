﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projeto1
{
    public class Interface
    {

        //1 Joao Subaru
        //2 Maria Subaru
        //3 Joana BMW
        //5 Jose Lancia
        //6 Carlos Audi


        public static void LerConcorrentes(Provas p, string nomeDoFicheiro)
        {

            using (StreamReader reader = new StreamReader(nomeDoFicheiro))
            {

                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] valores = line.Split(' ');
                    Concorrente novoConcorrente = new Concorrente(Int32.Parse(valores[0]), valores[1], valores[2]);
                    p.AdicionarConcorrente(novoConcorrente);
                    line = reader.ReadLine();
                }
            }
        }

        public static void LerEtapas(Provas p, string nomeDoFicheiro)
        {
            using (StreamReader reader = new StreamReader(nomeDoFicheiro))
            {

                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] valores = line.Split(' ');
                    string DesignacaoEtapa = valores[1] + " " + valores[2];
                    Etapa novaEtapa = new Etapa(DesignacaoEtapa);

                    p.AdicionarEtapa(novaEtapa);
                    novaEtapa.tempos.Add(Int32.Parse(valores[0]), Int32.Parse(valores[3]));


                    line = reader.ReadLine();
                }
            }
        }

        public static void LerDistancias(Provas p, string nomeficheiro)
        {
            using (StreamReader reader = new StreamReader(nomeficheiro))
            {

                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] valores = line.Split(' ');
                    string designacaoEtapa = valores[0] + " " + valores[1];
                    float distancia = float.Parse(valores[2]);
                    foreach (string etapa in p.etapasDaProva.Keys)
                    {
                        if (p.etapasDaProva.ContainsKey(designacaoEtapa))
                        {
                            p.etapasDaProva[designacaoEtapa].distancia = distancia;
                        }
                    }

                    line = reader.ReadLine();
                }
            }
        }







    }


}