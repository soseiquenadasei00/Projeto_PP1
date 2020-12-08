using System;

namespace Projeto1
{
	public class Etapas
	{
		// Variaveis
		public int numeroEtapas; // Quantidade de etapas 
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
		/*public double CalcularTempoTotal (int nEtapas, double tEtapas) //Calcular o tempo total de todos os participantes!!
			{				
			double tptotal;
			tptotal = (nEtapas * tEtapas);
			return (tptotal);   
			}*/


		/* este nao deve funcionar porque o tempo de cada etapa vai ser diferente, ou seja, o tempo total sera a soma de cada uma das etapas,
		 * e não uma etapa * nEtapas.
		 * talvez pudessemos fazer uma SortedList para as etapas? nome da etapa como chave tempo como valor? mas como o tempo é para cada participante, não tenho a certeza se funcionaria
		 */
		
	}
}