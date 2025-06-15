
namespace GestionBibliotheque.Models
{
    public class FiltreParAuteur : IFiltreLivre
    {
        private readonly string auteur;
        public FiltreParAuteur(string auteur) => this.auteur = auteur;
        public bool EstValide(Livre livre) =>
            livre.Auteur?.Equals(auteur, StringComparison.OrdinalIgnoreCase) == true;
    }
}
