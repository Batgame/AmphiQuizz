using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AmphiQuizz
{
    public class ApplicationData
    {
        /// <remarks>
        /// Propriété contenant la liste des étudiants 
        /// </remarks>
        public static ObservableCollection<Etudiant> listeEtudiants
        {
            get;
            set;
        }

        /// <remarks>
        /// Propriété contenant la liste des profs 
        /// </remarks>
        public static ObservableCollection<Prof> listeProfs
        {
            get;
            set;
        }

        /// <remarks>
        /// Propriété contenant la liste des groupes
        /// </remarks>
        public static ObservableCollection<Groupe> listeGroupes
        {
            get;
            set;
        }

        /// <remarks>
        /// Propriété contenant la liste des notes
        /// </remarks>

        public static List<Notes> listeNotes
        {
            get;
            set;
        }


        /// <summary>
        /// Charge toutes les données : élèves, profs, notes
        /// </summary>
        public static bool loadApplicationData()
        {
            bool ret = false;
            try
            {
                //chargement des tables
                Etudiant unEtudiant = new Etudiant();

                Prof unProf = new Prof();
                Groupe unGroupe = new Groupe();
                listeNotes = new List<Notes>();
                listeProfs = unProf.FindAll();
                listeGroupes = unGroupe.FindAll();
                listeEtudiants = unEtudiant.FindAll();
                listeNotes.Add(new Notes(0));
                listeNotes.Add(new Notes(1));
                listeNotes.Add(new Notes(2));
                //listeNotes = unEstNote.FindAll();

                //mapping des relations en mode déconnecté
                //TODO PLUS TARD !!!
                //relation bi-directionnelle entre eleve et groupe
                //relation eleve -> note
                //relation note -> professeur
                ret = true;
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show("Toutes les données n'ont peut-être pas été récupéré.", "Important Message", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);

            }

            return ret;

        }
    }
}

