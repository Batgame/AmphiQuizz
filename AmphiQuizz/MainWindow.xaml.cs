using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AmphiQuizz
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Groupe> checkedGroupes { get; set; }

        public ObservableCollection<Etudiant> lesEtudiants { get; set; }
        public ObservableCollection<Etudiant> newEtuList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ApplicationData.loadApplicationData();
            checkedGroupes = ApplicationData.listeGroupes;
            lvEtu.ItemsSource = ApplicationData.listeEtudiants;
            lvProfesseur.ItemsSource = ApplicationData.listeProfs;
            lvGroupe.ItemsSource = checkedGroupes;
            lvNote.ItemsSource = ApplicationData.listeNotes;
            lvGroupe.SelectAll();
       
        }

        /// <summary> 
        /// Procédure qui met à jour la liste des étudiants en fonction des groupes selectionnés dans la liste des groupes 
        /// </summary>
        /// <param name="e"> fournit des données pour le selection changed </param>
        /// <param name="sender"> Représente l'objet qui a déclenché l'évènement </param>

        private void updateGroupe(object sender, SelectionChangedEventArgs e)
        {
            checkedGroupes = new ObservableCollection<Groupe>();

            foreach (Groupe g in lvGroupe.SelectedItems)
            {
                checkedGroupes.Add(g);
            }
            /*
            if(checkedGroupes.Count() == 0)
            {
                foreach(Groupe gg in ApplicationData.listeGroupes)
                {
                    checkedGroupes.Add(gg);
                }
            }
            */
            newEtuList = new ObservableCollection<Etudiant>();
            
            foreach(Groupe ggg in checkedGroupes)
            {
                foreach(Etudiant ee in ApplicationData.listeEtudiants)
                {
                    if(ee.IdGroupe == ggg.nGroupe)
                    {
                        newEtuList.Add(ee);
                    }    
                }
            }

            lvEtu.ItemsSource = newEtuList;

           
        }

        /// <summary> 
        /// Procédure qui gère tire un élève au hasard.  
        /// </summary>
        /// <remarks> Recompte le nombre d'étudiants dans la liste avant chaque tirage </remarks>
        /// <param name="e"> fournit des données pour le selection changed </param>
        /// <param name="sender"> Représente l'objet qui a déclenché l'évènement </param>

        private void RandomButton(object sender, RoutedEventArgs e)
        {

            lvEtu.Items.Refresh();
            int lenListeEtu = lvEtu.Items.Count; //compte le nombre d'items
            Random rand = new Random(); 
            int randEtu = rand.Next(lenListeEtu); //tire un entier entre 0 et le nombre d'étudiant
            if (newEtuList.Count == 0)
            {
                MessageBox.Show("Selectionner au moins un groupe pour tirer au sort.","Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                lvEtu.SelectedItem = newEtuList[randEtu];
            }
            
        }

        /// <summary> 
        /// Procédure qui selectionne un étudiant et affiche ses notes qui vont avec 
        /// </summary>
        /// <param name="e"> fournit des données pour le selection changed </param>
        /// <param name="sender"> Représente l'objet qui a déclenché l'évènement </param>

        private void selectedEtu(object sender, SelectionChangedEventArgs e)
        {
            Etudiant ee = (Etudiant)lvEtu.SelectedItem;
            if(ee != null)
            {
                lvHistorique.ItemsSource = ee.ListeNote;
            }
           
            lvProfesseur.SelectedIndex = -1;
            lvNote.SelectedIndex = -1;
           

        }

        /// <summary> 
        /// Procédure qui récupère l'étudiant selectionné et lui attribue une note dans la base de données
        /// </summary>
        /// <remarks> Envoie des messages box en cas d'erreur et une message box si tout c'est bien passé </remarks>
        /// <param name="e"> fournit des données pour le selection changed </param>
        /// <param name="sender"> Représente l'objet qui a déclenché l'évènement </param>
        private void noterClick(object sender, RoutedEventArgs e)
        {
            if(lvEtu.SelectedItem == null)
            {
                MessageBox.Show("Selectionner un étudiant.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(lvProfesseur.SelectedItem == null)
                {
                    MessageBox.Show("Selectionner un professeur.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if(lvNote.SelectedItem == null)
                    {
                        MessageBox.Show("Selectionner une note.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        Etudiant etuANoter = (Etudiant)lvEtu.SelectedItem;
                        Prof profNoteur = (Prof)lvProfesseur.SelectedItem;
                        Notes laNote = (Notes)lvNote.SelectedItem;
                        Notes noteTemp = new Notes(laNote.UneNote);
                        noteTemp.UnEtu = etuANoter;
                        noteTemp.UnProf = profNoteur;
                        noteTemp.UneDate = DateTime.Now;

                        laNote.Create(etuANoter, profNoteur, laNote);
                        etuANoter.ListeNote.Add(noteTemp);

                        MessageBox.Show("Note ajoutée !", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        



                    }
                }
            }
           
        }

        /// <summary> 
        /// Procédure qui affiche les informations sur une note (montre le prof qui a été selectionné et la note qui à été mise)
        /// </summary>
        /// <param name="e"> fournit des données pour le selection changed </param>
        /// <param name="sender"> Représente l'objet qui a déclenché l'évènement </param>
        private void clickNote(object sender, SelectionChangedEventArgs e)
        {
            Notes noteEnCours = (Notes)lvHistorique.SelectedItem;

            if(noteEnCours != null)
            {
                lvProfesseur.SelectedItem = noteEnCours.UnProf;
                lvNote.SelectedItem = ApplicationData.listeNotes.Find(x => x.UneNote == noteEnCours.UneNote);
            }
        }
    }
}
