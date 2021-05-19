using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmphiQuizz
{
    public abstract class Personne
    {
        private int idPersonne;
        public int IdPersonne { get => idPersonne; set => idPersonne = value; }

        private string nomPersonne;
        public string NomPersonne { get => nomPersonne; set => nomPersonne = value; }

        private string prenomPersonne;
        public string PrenomPersonne { get => prenomPersonne; set => prenomPersonne = value; }

        /// <summary>
        /// Instancie une nouvelle personne
        /// </summary>
        public Personne()        
        {
        }

        /// <summary>
        /// Retourne une chaine de caractère qui représente l'objet actuel 
        /// </summary>
        public override string ToString()
        {
            return "ID Personne : " + IdPersonne + "\nNom : " + NomPersonne + "\nPrénom : " + PrenomPersonne;
        }
    }
}
