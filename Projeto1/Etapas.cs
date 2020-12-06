using System;

namespace Projeto1
{
	public class Etapas
	{
		// Variaveis
		public int numeroEtapas;      // Etapa atual  
		public double tempoEtapa;     // Tempo de cada etapa 
		public int numeroTotalEtapas; //Numero total de etapas 
		public double tempoTotal;     // Tempo total ( soma dos tempos das etapas)
		

		// construtor 

		public Etapas( int nEtapas, double tEtapa, double tTotal) 
        {
			this.numeroEtapas = nEtapas;
			this.tempoEtapa = tEtapa;
			this.tempoTotal = tTotal;
        }


		//Instancias
		
		public int etapaAtual (int etapa) // Devolve a etapa
		{
			return (etapa = numeroEtapas); 
		}
		
		public double tempoDaEtapa (double temp) // Tempo de uma etapa 
        {
			return (temp = tempoEtapa);
        }

		public int ntEtapas (int et) // Devolve o numero de etapas 
        {
			return (et = numeroTotalEtapas);
        }
		
		public double CalcularTempototal (int nEtapas, double tEtapas) // Calcula o tempo total das etapas 
			{
			double tptotal;
			tptotal = (nEtapas * tEtapas);
			return (tptotal);   
			}
		
	}
}