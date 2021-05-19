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
        public static ObservableCollection<Etudiant> listeEtudiants
        {
            get;
            set;
        }

        public static ObservableCollection<Prof> listeProfs
        {
            get;
            set;
         }
        public static ObservableCollection<Groupe> listeGroupes
        {
            get;
            set;
        }


        public static List<Notes> listeNotes
        {
            get;
            set;
        }


        public static void loadApplicationData()
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



        }
    }
}

