using System;
namespace prova.Enity
{
	public class Banca
	{
        private List<Cliente> Clienti { get; set; }
        private List<Prestito> Prestiti { get; set; }

        public Banca(List<Cliente> clienti, List<Prestito> prestiti)
		{
			Clienti = clienti;
			Prestiti = prestiti;
		}

		public void AddCliente(Cliente cliente)
		{
            Cliente clienteTrovato = SearchCliente(cliente.GetCodiceFiscale());
            if (clienteTrovato != null)
            {
                throw new ApplicationException("Cliente già presente");
            }

            Clienti.Add(cliente);
		}

		public void RemoveCliente(string codiceFiscale)
		{
            Cliente clienteTrovato = SearchCliente(codiceFiscale);
			if (clienteTrovato == null)
			{
                throw new ApplicationException("Cliente non trovato");
            }

			Clienti.Remove(clienteTrovato);
        }

        public Cliente SearchCliente(string codiceFiscale)
		{
			foreach(Cliente c in Clienti)
			{
				if (c.GetCodiceFiscale() == codiceFiscale)
				{
					return c;
				}
			}

			return null;
		}

        public void AddPrestito(Prestito prestito)
        {
			Prestiti.Add(prestito);
        }

        public List<Prestito> SearchPrestitiCliente(string codiceFiscale)
        {
			List<Prestito> prestitiCliente = new List<Prestito>();
			foreach (Prestito prestito in Prestiti)
			{
				if (prestito.GetCliente().GetCodiceFiscale() == codiceFiscale)
				{
					prestitiCliente.Add(prestito);
				}
			}

			return prestitiCliente;
        }
    }
}