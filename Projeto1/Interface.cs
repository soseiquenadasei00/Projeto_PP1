using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projeto1
{
    public class Interface
    {

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
                    Console.WriteLine("Lido concorrente ID: {0}\t nome: {1} \tcarro: {2}", valores[0], valores[1], valores[2]);
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
                    string designacaoEtapa = valores[1] + " " + valores[2];


                    
                    //Define o comportamento caso a prova tenha apenas uma etapa, ou seja, P ate C
                    if (designacaoEtapa == "P C")  
                    {
                        Console.WriteLine("Aviso: Comportamento suspeito. A prova contem apenas 1 etapa?");
                        if (p.etapasDaProva.Count == 0)
                        {
                            if (!p.etapasDaProva.ContainsKey(designacaoEtapa))
                            {
                                Etapa novaEtapa = new Etapa(designacaoEtapa);
                                p.AdicionarEtapa(novaEtapa);
                                novaEtapa.AdicionarConcorrenteETempo(Int32.Parse(valores[0]), Int32.Parse(valores[3]));
                                Console.WriteLine("Criada a etapa " + designacaoEtapa + "\tLido concorrenteID: {0}\t tempo: {1}", valores[0], valores[3]);
                            }
                            else
                            {
                                p.etapasDaProva[designacaoEtapa].AdicionarConcorrenteETempo(Int32.Parse(valores[0]), Int32.Parse(valores[3]));
                                Console.WriteLine("Para a etapa " + designacaoEtapa + "\tLido concorrenteID: {0}\t tempo: {1}", valores[0], valores[3]);
                            }
                        }
                        else Console.WriteLine("Erro Etapa " + designacaoEtapa + " invalida!!");
                    }



                    //Define o comportamento caso a prova tenha mais do que uma etapa

                    else if (!p.etapasDaProva.ContainsKey(designacaoEtapa))
                    {
                        Etapa novaEtapa = new Etapa(designacaoEtapa);
                        p.AdicionarEtapa(novaEtapa);
                        novaEtapa.AdicionarConcorrenteETempo(Int32.Parse(valores[0]), Int32.Parse(valores[3]));
                        Console.WriteLine("Criada a etapa " + designacaoEtapa + "\tLido concorrenteID: {0}\t tempo: {1}", valores[0], valores[3]);
                    }
                    else
                    {
                        p.etapasDaProva[designacaoEtapa].AdicionarConcorrenteETempo(Int32.Parse(valores[0]), Int32.Parse(valores[3]));
                        Console.WriteLine("Para a etapa   " + designacaoEtapa + "\tLido concorrenteID: {0}\t tempo: {1}", valores[0], valores[3]);
                    }

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
                            p.etapasDaProva[designacaoEtapa].SetDistancia(distancia);
                            Console.WriteLine("Para a etapa   " + designacaoEtapa + "\tLido distancia: {0}", distancia);
                        }
                        else Console.WriteLine("Erro: A prova nao contem a etapa indicada.");
                    }

                    line = reader.ReadLine();
                }
            }
        }
    }
}