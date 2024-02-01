using System;
using System.Collections.Generic;

namespace c_sharp_esercizio_giorno_4
{
    internal class Utente
    {
        private string Nome { get; set; }
        private string Password { get; set; }
        private bool IsLoggedIN { get; set; }
        private DateTime UltimoLogin { get; set; }
        private List<DateTime> AllAccess { get; set; } = new List<DateTime>();


        public Utente()
        {

            this.Nome = "";
            this.Password = "";
            this.IsLoggedIN = false;

        }



        public void MenuIniziale()
        {

            Console.WriteLine("\n");
            Console.WriteLine("===============OPERAZIONI==============");
            Console.WriteLine($" Ciao, scegli le operazioni da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Cambiopassword");
            Console.WriteLine("6.: Esci");
            Console.WriteLine("========================================");

            string inputUtente = (Console.ReadLine());


            if (Convert.ToInt32(inputUtente) == 1)
            {
                Login();
            }
            else if (Convert.ToInt32(inputUtente) == 2)
            {
                LogOut();
            }
            else if (Convert.ToInt32(inputUtente) == 3)
            {
                VerificaDataOraLogin();
            }
            else if (Convert.ToInt32(inputUtente) == 4)
            {
                ElencoAccessi();
            }
            else if (Convert.ToInt32(inputUtente) == 5)
            {
                Cambiopassword();
            }
            else if (Convert.ToInt32(inputUtente) == 6)
            {
                Exit();
            }
            else
            {
                Console.WriteLine("input inserito non valido. Riprovare.");
                MenuIniziale();
            }




        }

        public void Login()
        {
            if (this.IsLoggedIN == false)
            {

                this.IsLoggedIN = true;

                Console.WriteLine("inserisci un nome:");
                string nome = Console.ReadLine();
                this.Nome = nome;

                Console.WriteLine($"il nome da te inserito è {this.Nome}, è corretto?  y/n");
                string risposta = Console.ReadLine();
                string passwordUtente;

                if (risposta == "y")
                {

                    try
                    {


                        do
                        {
                            Console.WriteLine("inserisci una password valida. - lenght 6 caratteri e prima lettera Maiuscola.");
                            passwordUtente = Console.ReadLine().Trim();

                            if (passwordUtente.Length != 6 && !char.IsUpper(passwordUtente[0]))
                            {
                                Console.WriteLine("non hai inserito una password Valida.");
                                // fare qualcosa a pas nn valida
                            }
                            else
                            {
                                this.Password = passwordUtente;
                                Console.WriteLine("password inserita con successo.");
                                // per salvare ora e data dell ultimo login
                                this.UltimoLogin = DateTime.Now;

                                // pusho nella lista l'accesso appena fatto 
                                this.AllAccess.Add(this.UltimoLogin);
                                MenuIniziale();
                            }
                        }
                        while (passwordUtente.Length != 6 && !char.IsUpper(passwordUtente[0]));




                    }
                    catch
                    {
                        Console.WriteLine("Errore!");
                    }
                    //aggiungi una password 

                }
                else if (risposta == "n")
                {
                    // reimposta nome e aggiungi password 
                    Console.WriteLine("reimposta Nome Utente.");
                    string nuovoNome = Console.ReadLine();
                    this.Nome = nuovoNome;

                    try
                    {


                        do
                        {
                            Console.WriteLine("inserisci una password valida. - lenght 6 caratteri e prima lettera Maiuscola.");
                            passwordUtente = Console.ReadLine().Trim();

                            if (passwordUtente.Length != 6 && !char.IsUpper(passwordUtente[0]))
                            {
                                Console.WriteLine("non hai inserito una password Valida.");
                                // fare qualcosa a pas nn valida
                            }
                            else
                            {
                                this.Password = passwordUtente;
                                Console.WriteLine("password inserita con successo.");
                                // per salvare ora e data dell ultimo login
                                this.UltimoLogin = DateTime.Now;

                                // pusho nella lista l'accesso appena fatto 
                                this.AllAccess.Add(this.UltimoLogin);
                                MenuIniziale();
                            }
                        }
                        while (passwordUtente.Length != 6 && !char.IsUpper(passwordUtente[0]));




                    }
                    catch
                    {
                        Console.WriteLine("Errore!");
                    }
                    //aggiungi una password 

                }
                else
                {
                    Console.WriteLine("input non valido.");
                    this.Nome = "";
                    IsLoggedIN = false;
                    MenuIniziale();
                }
            }
            else
            {
                Console.WriteLine("sei già Loggato. Scegli un altra operazione.");
                MenuIniziale();
            }
        }

        public void LogOut()
        {
            if (IsLoggedIN == false)
            {
                Console.WriteLine("devi prima effettuare il Login.");
                MenuIniziale();
            }
            else
            {
                IsLoggedIN = false;
                Console.WriteLine("Hai effettuato il LogOut.");
                this.Nome = "DEFAULT";
                this.Password = "";
                MenuIniziale();
            }

        }

        public void Cambiopassword()
        {
            if (IsLoggedIN == false)
            {
                Console.WriteLine("Devi Prima Effettuare il Login.");
                MenuIniziale();
            }
            else
            {
                Console.WriteLine("inserisci Vecchia Password.");
                string vecchiaPassword = Console.ReadLine();

                if (this.Password == vecchiaPassword)
                {
                    // inserisci nuova password
                    string nuovaPassword;
                    do
                    {
                        Console.WriteLine("la password combacia.");
                        Console.WriteLine("inserisci nuova Password.- lenght 6 caratteri e prima lettera Maiuscola.");
                        nuovaPassword = Console.ReadLine().Trim();

                        if (nuovaPassword.Length != 6 && !char.IsUpper(nuovaPassword[0]))
                        {
                            Console.WriteLine("non hai inserito una password Valida.");
                            // fare qualcosa a pas nn valida
                        }
                        else
                        {
                            this.Password = nuovaPassword;
                            Console.WriteLine("password cambiata con successo.");
                            MenuIniziale();
                        }
                    }
                    while (nuovaPassword.Length != 6 && !char.IsUpper(nuovaPassword[0]));
                }
                else
                {
                    Console.WriteLine("La password inserita non combacia. Verrai riportato al menù.");
                    MenuIniziale();
                    // hai sbagliato torna al menù. 
                    // elimina possibilità di cambiare nome.
                }
            }

        }

        public void VerificaDataOraLogin()
        {
            if (IsLoggedIN == false)
            {
                Console.WriteLine("devi prima effettuare il Login.");
                MenuIniziale();
            }
            else
            {
                // per controllare inserisci pass:
                Console.WriteLine("Controllo Password: inserisci Password.");
                string checkPassword = Console.ReadLine();

                if (checkPassword == this.Password)
                {
                    Console.WriteLine($"Ultimo accesso effettuato alle: {this.UltimoLogin}");
                    MenuIniziale();
                }
                else
                {
                    Console.WriteLine("Password inserita non corretta. Verrai riportato al menù iniziale.");
                    MenuIniziale();
                }

            }

        }

        public void ElencoAccessi()
        {
            if (IsLoggedIN == false)
            {
                Console.WriteLine("devi prima effettuare il Login.");
                MenuIniziale();
            }
            else
            {
                Console.WriteLine("Controllo Password: inserisci Password.");
                string checkPassword = Console.ReadLine();

                if (checkPassword == this.Password)
                {
                    // mostro contenuto di allAccess
                    for (int i = 0; i < AllAccess.Count; i++)
                    {
                        DateTime singoloAccesso = AllAccess[i];
                        Console.WriteLine($"{i + 1} accesso: {singoloAccesso}");
                    }
                    MenuIniziale();
                }
                else
                {
                    Console.WriteLine("Password inserita non corretta. Verrai riportato al menù iniziale.");
                    MenuIniziale();
                }

            }
        }

        public void Exit()
        {
            Console.WriteLine("Arrivederci!");
            this.IsLoggedIN = false;

        }

    }


}


