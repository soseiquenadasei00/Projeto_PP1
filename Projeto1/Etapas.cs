using System;

namespace Projeto1
{
	public class Etapas
	{
		// Variaveis
		public int numeroEtapas; // Quantatidade de etapas 
		public double tempoEtapa;    // Tempo de cada etapa 
		public int numeroTotalEtapas; //Numero total de etapas 
		public double tempoTotal;    // Tempo total ( soma dos tempos das etapas)
		

		// construtor 

		public Etapas( int nEtapas, double tEtapa, double tTotal) 
        {
			this.numeroEtapas = nEtapas;
			this.tempoEtapa = tEtapa;
			this.tempoTotal = tTotal;
        }


		//Instancias
		public double CalcularTempototal (int nEtapas, double tEtapas)
			{
			double tptotal;
			tptotal = (nEtapas * tEtapas);
			return (tptotal);   
			}
		
	}
}