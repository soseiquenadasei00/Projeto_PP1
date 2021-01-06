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
                int maximo = 0;

                while (line != null)
                {
                    string[] valores = line.Split(' ');
                    string designacaoEtapa = valores[1] + " " + valores[2];
                   


                    if (valores[2] != "C")
                    {
                        for (int i = 1; i < 2; i++)
                        {
                            if (((char)valores[2][i]) > maximo) maximo = (char)valores[2][i];
                        }
                    }


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


                    //Teremos entao 3 opcoes possiveis de etapas validas
                    //OPCAO 1 - P - E1
                    //OPCAO 2 - Emax - C
                    //OPCAO 3 - Ei - Ei+1
                    else
                    {
                        //OPCAO 1
                        if ((valores[1] == "P") && (valores[2] == "E1")) //Depois de P, é necessario que venha a etapa E1, para provas com mais de 1 etapa
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
                                Console.WriteLine("Para a etapa   " + designacaoEtapa + "\tLido concorrenteID: {0}\t tempo: {1}", valores[0], valores[3]);
                            }
                        }

                        //OPCAO 2
                        else if (valores[2] == "C" && (valores[1][1] == maximo)) //Se temos C, entao é necessario que venha a etapa E maxima antes
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
                                Console.WriteLine("Para a etapa   " + designacaoEtapa + "\tLido concorrenteID: {0}\t tempo: {1}", valores[0], valores[3]);
                            }
                        }

                        //OPCAO 3
                        else if (((char)valores[1][1]) == (((char)valores[2][1]) - 1)) //Se vamos ter uma etapa no meio, ou seja, nem partida nem chegada, os E tem que ser adjacentes
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
                                Console.WriteLine("Para a etapa   " + designacaoEtapa + "\tLido concorrenteID: {0}\t tempo: {1}", valores[0], valores[3]);
                            }
                        }

                        else
                        {
                            Console.WriteLine("\n\n\n\n\n\n\n\tOOPS DEU RUIM! ERRO NA LEITURA DAS ETAPAS\n\n\n\n\n\n");
                        } 
                    }
                    line = reader.ReadLine();
                } //fim do ciclo while
            } // fim do streamreader
        } //fim do metodo


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
