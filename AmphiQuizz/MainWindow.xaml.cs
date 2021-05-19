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
       
        }

        private void NoterButton(object sender, RoutedEventArgs e)
        {
        }

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
        
        private void RandomButton(object sender, RoutedEventArgs e)
        {

            lvEtu.Items.Refresh();
            int lenListeEtu = lvEtu.Items.Count; //compte le nombre d'items
            Random rand = new Random(); 
            int randEtu = rand.Next(lenListeEtu); //tire un entier entre 0 et le nombre d'étudiant
            if (newEtuList == null)
            {
                lvEtu.SelectedItem = ApplicationData.listeEtudiants[randEtu];
            }
            else
            {
                lvEtu.SelectedItem = newEtuList[randEtu];
            }
            
        }

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
