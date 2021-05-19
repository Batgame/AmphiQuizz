using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AmphiQuizz
{
    public class Etudiant : Personne, ICrud<Etudiant>
    {
        private int idEtu;
        public int IdEtu { get => idEtu; set => idEtu = value; }

        private string libelleGroupe;
        public string LibelleGroupe { get => libelleGroupe; set  => libelleGroupe = value; }

        private int idGroupe;
        public int IdGroupe { get => idGroupe; set => idGroupe = value; }

        private string pathPhoto;
        public string PathPhoto 
        { 
            get => "\\\\srv-data2.iut-acy.local\\Public\\DUT\\INFO\\INFO1\\S2\\UE21\\M2104-TROMBI\\" + pathPhoto + ".jpg"; 
            set => pathPhoto = value; 
        }

        private BitmapFrame profileImage;
        public BitmapFrame ProfileImage
        {
            get => profileImage;
            set => profileImage = value;
            
        }

        private ObservableCollection<Notes> listeNote;
        public ObservableCollection<Notes> ListeNote { get => listeNote; set => listeNote = value; }

        /// <summary>
        /// Constructeur de la classe étudiant
        /// </summary>
        public Etudiant() : base()
        {
        }

        /// <summary>
        /// Retourne une chaîne de caractère décrivant l'objet actuel
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + "\nId Etu : " + IdEtu + "\nPhoto : " + pathPhoto;
        }

        /// <summary>
        /// Fonction non utilisée issu de l'inteface ICrud
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p"></param>
        /// <param name="n"></param>

        public void Create(Etudiant e, Prof p, Notes n)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fonction non utilisée issu de l'inteface ICrud
        /// </summary>

        public void Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fonction non utilisée issu de l'inteface ICrud
        /// </summary>

        public void Update()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fonction non utilisée issu de l'inteface ICrud
        /// </summary>

        public void Delete()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recupère tous les étudiants issus de la table [iut-acy\genodb].etudiant et leurs notes respectives
        /// </summary>
        /// <returns> retourne une ObservableCollection d'étudiants </returns>
        public ObservableCollection<Etudiant> FindAll()
        {
            ObservableCollection<Etudiant> listeEtudiant = new ObservableCollection<Etudiant>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            SqlDataReader reader2;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select e.idEtu, e.idgroupe, g.libellegroupe, e.nometu, e.prenometu, e.photoetu, n.note, n.datenote from [IUT-ACY\\genodb].ETUDIANT e join [IUT-ACY\\genodb].GROUPE g on g.idgroupe = e.idgroupe left join [IUT-ACY\\genodb].Note n on e.idetu = n.idetu order by e.nometu;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Etudiant unEtudiant = new Etudiant();
                            unEtudiant.IdEtu = (int)reader.GetInt64(0);
                            unEtudiant.NomPersonne = reader.GetString(3);
                            unEtudiant.PrenomPersonne = reader.GetString(4);
                            unEtudiant.IdGroupe = (int)reader.GetInt32(1);
                            unEtudiant.LibelleGroupe = reader.GetString(2);
                            unEtudiant.PathPhoto = reader.GetString(5);
                            unEtudiant.ListeNote = new ObservableCollection<Notes>();
                            try
                            {
                                unEtudiant.ProfileImage = BitmapFrame.Create(new Uri(string.IsNullOrEmpty(unEtudiant.PathPhoto) ? "user.png" : unEtudiant.PathPhoto));

                            }
                            catch (Exception ee)
                            {
                                unEtudiant.ProfileImage = BitmapFrame.Create(new Uri("../../user.png", UriKind.Relative));
                            }
                            
                            reader2 = access.getData("select idetu, idprof, datenote, note from [iut-acy\\genodb].note where idetu = " + unEtudiant.IdEtu + ";");
                            if(reader2.HasRows)
                            {
                                while (reader2.Read())
                                {
                                    Notes uneNote = new Notes((int)reader2.GetInt32(3));
                                    uneNote.UnEtu = unEtudiant;
                                    uneNote.UneDate = reader2.GetDateTime(2);
                                    foreach (Prof p in ApplicationData.listeProfs)
                                    {
                                        if (p.IdPersonne == (int)reader2.GetInt64(1))
                                        {
                                            uneNote.UnProf = p;
                                        }
                                    }
                                    unEtudiant.ListeNote.Add(uneNote);
                                }
                            }

                            reader2.Close();
                            
                            listeEtudiant.Add(unEtudiant);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No rows found.", "Important Message",System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    }
                    reader.Close();
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Important Message", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            return listeEtudiant;
        }

        /// <summary>
        /// Fonction non utilisée issu de l'inteface ICrud
        /// </summary>
        /// <param name="criteres"></param>
        /// <returns></returns>

        public ObservableCollection<Etudiant> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
