using System;

namespace GestionBibliotheque.Models
{
    public class Livre
    {
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public int Annee { get; set; }
        public override string ToString() => $"{Titre} - {Auteur} ({Annee})";
    }
}
