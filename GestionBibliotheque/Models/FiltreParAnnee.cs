
namespace GestionBibliotheque.Models
{
    public class FiltreParAnnee : IFiltreLivre
    {
        private readonly int annee;
        public FiltreParAnnee(int annee) => this.annee = annee;
        public bool EstValide(Livre livre) => livre.Annee == annee;
    }
}
