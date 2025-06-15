using GestionBibliotheque.Models;
using GestionBibliotheque.Services;

namespace GestionBibliotheque.UI
{
    public class BibliothequeConsoleUI
    {
        private readonly IBibliotheque _bibliotheque;

        public BibliothequeConsoleUI(IBibliotheque bibliotheque)
        {
            _bibliotheque = bibliotheque;
        }

        public void Demarrer()
        {
            bool quitter = false;

            while (!quitter)
            {
                Console.Clear();
                Console.WriteLine("=== Menu Gestion Bibliothèque ===");
                Console.WriteLine("1. Lister les livres");
                Console.WriteLine("2. Ajouter un livre");
                Console.WriteLine("3. Filtrer par auteur");
                Console.WriteLine("4. Filtrer par année");
                Console.WriteLine("5. Rechercher par titre");
                Console.WriteLine("6. Supprimer un livre");
                Console.WriteLine("7. Quitter");
                Console.Write("Choix : ");
                var choix = Console.ReadLine();

                switch (choix)
                {
                    case "1": ListerLivres(_bibliotheque.ListerTous()); break;
                    case "2": AjouterLivre(); break;
                    case "3": FiltrerParAuteur(); break;
                    case "4": FiltrerParAnnee(); break;
                    case "5": RechercherParTitre(); break;
                    case "6": SupprimerLivre(); break;
                    case "7": quitter = true; break;
                    default: Console.WriteLine("Choix invalide."); break;
                }

                if (!quitter) Pause();
            }
        }

        private void AjouterLivre()
        {
            Console.Write("Titre : ");
            var titre = Console.ReadLine();
            Console.Write("Auteur : ");
            var auteur = Console.ReadLine();
            Console.Write("Année : ");
            if (int.TryParse(Console.ReadLine(), out int annee))
            {
                _bibliotheque.AjouterLivre(new Livre { Titre = titre, Auteur = auteur, Annee = annee });
                Console.WriteLine("Livre ajouté avec succès !");
            }
            else Console.WriteLine("Année invalide.");
        }

        private void ListerLivres(IEnumerable<Livre> livres)
        {
            Console.WriteLine("\n--- Liste des livres ---");
            if (!livres.Any()) Console.WriteLine("Aucun livre trouvé.");
            else foreach (var livre in livres) Console.WriteLine(livre);
        }

        private void FiltrerParAuteur()
        {
            Console.Write("Nom de l’auteur : ");
            var auteur = Console.ReadLine();
            ListerLivres(_bibliotheque.Filtrer(new FiltreParAuteur(auteur)));
        }

        private void FiltrerParAnnee()
        {
            Console.Write("Année : ");
            if (int.TryParse(Console.ReadLine(), out int annee))
                ListerLivres(_bibliotheque.Filtrer(new FiltreParAnnee(annee)));
            else Console.WriteLine("Année invalide.");
        }

        private void RechercherParTitre()
        {
            Console.Write("Mot-clé du titre : ");
            var titre = Console.ReadLine();
            ListerLivres(_bibliotheque.Filtrer(new FiltreParTitre(titre)));
        }
        private void SupprimerLivre()
        {
            Console.Write("Titre du livre à supprimer : ");
            var titre = Console.ReadLine();
            _bibliotheque.SupprimerLivre(titre);
        }


        private void Pause()
        {
            Console.WriteLine("\nAppuie sur une touche pour continuer...");
            Console.ReadKey();
        }
    }
}
