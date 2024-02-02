using System;
namespace prova.Enity
{
	public class Prestito
	{
		private Cliente Intestatario { get; set; }
		private double Ammontare { get; set; }
		private double RataMensile { get; set; }
		private DateTime DataInizio { get; set; }
		private DateTime DataFine { get; set; }

		public Prestito(Cliente intestatario, double ammontare
			, double rataMensile, DateTime dataInizio
			, DateTime dataFine)
		{
			Intestatario = intestatario;
			Ammontare = ammontare;
			RataMensile = rataMensile;
			DataInizio = dataInizio;
			DataFine = dataFine;
		}

        public override string ToString()
        {
			return $"Cliente: {Intestatario}" +
				$", Ammontare: {Ammontare}" +
				$", RataMensile: {RataMensile}" +
				$", DataInizio: {DataInizio.ToString("s")} " +
				$", DataFine: {DataFine.ToString("s")}";
		}

        public Cliente GetCliente()
        {
			return Intestatario;
        }

        public double GetAmmontare()
        {
			return Ammontare;
        }
    }
}

