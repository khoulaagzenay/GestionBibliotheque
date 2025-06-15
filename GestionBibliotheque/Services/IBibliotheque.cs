using System.Collections.Generic;
using GestionBibliotheque.Models;
namespace GestionBibliotheque.Services
{
    public interface IBibliotheque
    {
        void AjouterLivre(Livre livre);
        void SupprimerLivre(string titre);

        IEnumerable<Livre> ListerTous();
        IEnumerable<Livre> Filtrer(IFiltreLivre filtre);
    }
}
