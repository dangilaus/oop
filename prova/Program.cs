using System;
using prova.Enity;

namespace Prova
{
    public class Program
    {
        static void Main(string[] args)
        {
            Banca banca = MockupBanca();

            while (true)
            {
                try
                {
                    ShowMenu();
                    int scelta = SceltaMenu();
                    switch (scelta)
                    {
                        case 0:
                            return;

                        case 1:
                            // Aggiungi cliente
                            Cliente cliente = RichiediDatiNuovoCliente();
                            banca.AddCliente(cliente);
                            break;

                        case 2:
                            // Cerca cliente
                            string codiceFiscaleDaCercare = RichiediCodiceFiscale();
                            Cliente clienteTrovato = banca.SearchCliente(codiceFiscaleDaCercare);
                            Console.WriteLine($"Cliente trovato: {clienteTrovato}");
                            break;

                        case 3:
                            // Elimina cliente
                            string codiceFiscaleDaEliminare = RichiediCodiceFiscale();
                            banca.RemoveCliente(codiceFiscaleDaEliminare);
                            Console.WriteLine("Cliente eliminato");
                            break;

                        case 4:
                            // Aggiungi prestito
                            string codiceFiscalePerPrestito = RichiediCodiceFiscale();
                            Cliente clientePerPresito = banca.SearchCliente(codiceFiscalePerPrestito);
                            Prestito prestito = RichiediDatiNuovoPrestito(clientePerPresito);
                            banca.AddPrestito(prestito);
                            break;

                        case 5:
                            // Cerca prestito per cliente
                            string codiceFiscalePerRicercaPrestito = RichiediCodiceFiscale();
                            List<Prestito> prestitiCliente = banca.SearchPrestitiCliente(codiceFiscalePerRicercaPrestito);
                            foreach(Prestito prestitoCliente in prestitiCliente)
                            {
                                Console.WriteLine($"Prestito: {prestitoCliente}");
                            }
                            break;

                        case 6:
                            // Cerca prestito per cliente
                            string codiceFiscalePerRicercaAmmontare = RichiediCodiceFiscale();
                            List<Prestito> prestitiClientePerAmmontare = banca.SearchPrestitiCliente(codiceFiscalePerRicercaAmmontare);
                            double ammontareTotale = 0;
                            foreach (Prestito prestitoCliente in prestitiClientePerAmmontare)
                            {
                                ammontareTotale += prestitoCliente.GetAmmontare();
                            }
                            Console.WriteLine($"Totale: {ammontareTotale}");
                            break;

                        default:
                            Console.WriteLine("Funzione sconosciuta");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Errore: {e.Message}");
                }
            }
        }

        private static void ShowMenu() 
        {
            Console.WriteLine("**** MENU ****");
            Console.WriteLine("1:\tAggiungi Cliente");
            Console.WriteLine("2:\tCerca Cliente");
            Console.WriteLine("3:\tElimina Cliente");
            Console.WriteLine("4:\tAggiungi prestito");
            Console.WriteLine("5:\tPrestiti per cliente");
            Console.WriteLine("6:\tAmmontare per cliente");
            Console.WriteLine();
            Console.WriteLine("Premi 0 per uscire");
        }

        private static int SceltaMenu()
        {
            int scelta = 0;
            bool isOk = false;
            while(!isOk)
            {
                var text = Console.ReadLine();
                isOk = int.TryParse(text, out scelta);
            }
            return scelta;
        }

        private static Cliente RichiediDatiNuovoCliente()
        {
            Console.Write("Inserire il nome: ");
            string nome = Console.ReadLine();

            Console.Write("Inserire il cognome: ");
            string cognome = Console.ReadLine();

            Console.Write("Inserire il codice fiscale: ");
            string cf = Console.ReadLine();

            Console.Write("Inserire lo stipendio RAL: ");
            double stipendio = Convert.ToDouble(Console.ReadLine());

            Cliente cliente = new Cliente(nome,
                cognome,
                cf,
                stipendio);

            return cliente;
        }

        private static Prestito RichiediDatiNuovoPrestito(Cliente cliente)
        {
            Console.Write("Inserire l'ammontare: ");
            double ammontare = Convert.ToDouble(Console.ReadLine());

            Console.Write("Inserire la rata: ");
            double rata = Convert.ToDouble(Console.ReadLine());

            Console.Write("Inserire la data inizio: ");
            DateTime dataInizio = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Inserire la data fine: ");
            DateTime dataFine = Convert.ToDateTime(Console.ReadLine());

            Prestito prestito = new Prestito(
                    cliente,
                    ammontare,
                    rata,
                    dataInizio,
                    dataFine);

            return prestito;
        }

        private static string RichiediCodiceFiscale()
        {
            Console.Write("Inserire il codice fiscale: ");
            string cf = Console.ReadLine();
            return cf;
        }

        private static Banca MockupBanca()
        {
            Cliente cliente1 = new Cliente(
                                "Mario",
                                "Rossi",
                                "RSSMRA90P23H294N",
                                20000.30
                            );

            Cliente cliente2 = new Cliente(
                    "Gianluca",
                    "Verdi",
                    "VRDGNL90P23H294N",
                    50000.30
                );

            Prestito prestito1 = new Prestito(
                    cliente1,
                    10000,
                    1000,
                    new DateTime(2024, 02, 01),
                    new DateTime(2024, 11, 30)
                );

            List<Cliente> clienti = new List<Cliente>();
            clienti.Add(cliente1);
            clienti.Add(cliente2);

            List<Prestito> prestiti = new List<Prestito>();
            prestiti.Add(prestito1);

            Banca banca = new Banca(clienti, prestiti);
            return banca;
        }
    }
}