namespace GestionBibliotheque.Models
{
    public class FiltreParTitre : IFiltreLivre
    {
        private readonly string motCle;
        public FiltreParTitre(string motCle) => this.motCle = motCle;
        public bool EstValide(Livre livre) =>
            livre.Titre?.IndexOf(motCle, StringComparison.OrdinalIgnoreCase) >= 0;
    }
}
