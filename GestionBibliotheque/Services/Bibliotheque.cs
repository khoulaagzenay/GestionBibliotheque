using GestionBibliotheque.Models;

namespace GestionBibliotheque.Services
{

        public class Bibliotheque : IBibliotheque
        {
            private readonly List<Livre> livres = new();

            public void AjouterLivre(Livre livre)
            {
                livres.Add(livre);
            }

            public IEnumerable<Livre> ListerTous() => livres;

            public IEnumerable<Livre> Filtrer(IFiltreLivre filtre)
            {
                return livres.Where(filtre.EstValide).ToList();
            }
        public void SupprimerLivre(string titre)
        {
            var livreASupprimer = livres.FirstOrDefault(l => l.Titre.Equals(titre, StringComparison.OrdinalIgnoreCase));
            if (livreASupprimer != null)
            {
                livres.Remove(livreASupprimer);
                Console.WriteLine($"Le livre '{titre}' a été supprimé.");
            }
            else
            {
                Console.WriteLine($"Aucun livre trouvé avec le titre '{titre}'.");
            }
        }


    }

}
