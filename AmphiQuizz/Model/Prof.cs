using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AmphiQuizz
{
    public class Prof : Personne, ICrud<Prof>
    {
        /// <summary>
        /// Instancie un nouveau prof
        /// </summary>
        public Prof(): base()
        { }

        /// <summary>
        /// Fonction non utilisée issu de l'inteface ICrud
        /// </summary>
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
        /// Recupère tous les profs issu de la table [iut-acy\genodb].prof
        /// </summary>
        /// <returns>
        /// Retourne une ObservableCollection de prof ou un message en cas d'erreur 
        /// </returns>
        public ObservableCollection<Prof> FindAll()
        {
            ObservableCollection<Prof> listeProf = new ObservableCollection<Prof>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select idprof, nomprof, prenomprof from [IUT-ACY\\genodb].PROF;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Prof unProf = new Prof();
                            unProf.IdPersonne = (int)reader.GetInt64(0);
                            unProf.NomPersonne = reader.GetString(1);
                            unProf.PrenomPersonne = reader.GetString(2);
                            listeProf.Add(unProf);
                        } 
                        
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No rows found.", "Important Message");
                    }
                    reader.Close();
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Important Message");
            }
            return listeProf;
        }

        /// <summary>
        /// Fonction non utilisée issu de l'inteface ICrud
        /// </summary>
        public ObservableCollection<Prof> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return obj is Prof prof &&
                   IdPersonne == prof.IdPersonne &&
                   NomPersonne == prof.NomPersonne &&
                   PrenomPersonne == prof.PrenomPersonne;
        }

        public override int GetHashCode()
        {
            int hashCode = 2072094501;
            hashCode = hashCode * -1521134295 + IdPersonne.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NomPersonne);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PrenomPersonne);
            return hashCode;
        }

       
    }
}
