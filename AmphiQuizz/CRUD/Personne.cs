using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmphiQuizz
{
    public abstract class Personne
    {
        /// <remarks>
        /// Propriété contenant l'identifiant d'une personne
        /// </remarks>

        private int idPersonne;
        public int IdPersonne { get => idPersonne; set => idPersonne = value; }

        /// <remarks>
        /// Propriété contenant le nom d'une personne
        /// </remarks>

        private string nomPersonne;
        public string NomPersonne { get => nomPersonne; set => nomPersonne = value; }

        /// <remarks>
        /// Propriété contenant le prénom d'une personne
        /// </remarks>

        private string prenomPersonne;
        public string PrenomPersonne { get => prenomPersonne; set => prenomPersonne = value; }

        /// <remarks>
        /// Instancie une nouvelle personne
        /// </remarks>
        public Personne()        
        {
        }

        /// <remarks>
        /// Retourne une chaine de caractère qui représente l'objet actuel 
        /// </remarks>
        public override string ToString()
        {
            return "ID Personne : " + IdPersonne + "\nNom : " + NomPersonne + "\nPrénom : " + PrenomPersonne;
        }
    }
}
