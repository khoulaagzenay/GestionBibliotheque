using GestionBibliotheque.Models;
using GestionBibliotheque.Services;
using GestionBibliotheque.UI;

class Program
{
    static void Main()
    {
        IBibliotheque bibliotheque = new Bibliotheque();
        var ui = new BibliothequeConsoleUI(bibliotheque);
        bibliotheque.AjouterLivre(new Livre { Titre = "The Midnight Library", Auteur = "Matt Haig", Annee = 2020 });
        bibliotheque.AjouterLivre(new Livre { Titre = "AI 2041: Ten Visions for Our Future", Auteur = "Kai-Fu Lee", Annee = 2021 });
        bibliotheque.AjouterLivre(new Livre { Titre = "A Promised Land", Auteur = "Barack Obama", Annee = 2020 });
        bibliotheque.AjouterLivre(new Livre { Titre = "The Midnight Library", Auteur = "Matt Haig", Annee = 2020 });
        bibliotheque.AjouterLivre(new Livre { Titre = "Le Mage du Kremlin", Auteur = "Giuliano da Empoli", Annee = 2022 });
        bibliotheque.AjouterLivre(new Livre { Titre = "The Creative Act: A Way of Being", Auteur = "Rick Rubin", Annee = 2023 });
        ui.Demarrer();
    }
}
