using System;
namespace prova.Enity
{
	public class Cliente
	{
		private string Nome { get; set;}
		private string Cognome { get; set; }
		private string CodiceFiscale { get; set; }
		private double Stipendio { get; set; }

		public Cliente(string nome, string cognome,
			string codiceFiscale, double stipendio)
		{
			Nome = nome;
			Cognome = cognome;
			CodiceFiscale = codiceFiscale;
			Stipendio = stipendio;
		}

		public override string ToString()
		{
			return $"Nome: {Nome}, Cognome: {Cognome}, " +
				$"CF: {CodiceFiscale}, Stipendio: {Stipendio}";
		}

        public string GetCodiceFiscale()
        {
			return CodiceFiscale;
        }
    }
}

