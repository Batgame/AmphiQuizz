﻿

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmphiQuizz
{
    public class Groupe : ICrud<Groupe>
    {
        public long nGroupe
        {
            get; set;
        }
        public string libelleGroupe
        {
            get; set;
        }
        
        ///<summary>
        ///Instancie un nouveau groupe 
        ///</summary>
        public Groupe()
        {
        }

        ///<summary>
        ///Fonction non utilisée issu de l'inteface ICrud
        ///</summary>
        public void Create(Etudiant e, Prof p, Notes n)
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///Fonction non utilisée issu de l'inteface ICrud
        ///</summary>
        public void Read()
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///Fonction non utilisée issu de l'inteface ICrud
        ///</summary>
        
        public void Update()
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///Fonction non utilisée issu de l'inteface ICrud
        ///</summary>
        public void Delete()
        {
            throw new NotImplementedException();
        }

        ///<summary>
        ///Recupère tous les groupes issu de la table [iut-acy\genodb].groupe
        ///</summary>
        ///<returns>
        ///Retourne une ObservableCollection de groupe ou un message en cas d'erreur 
        ///</returns>
        public ObservableCollection<Groupe> FindAll()
        {
            ObservableCollection<Groupe> listeGroupes = new ObservableCollection<Groupe>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select idgroupe, libellegroupe from [IUT-ACY\\genodb].GROUPE;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Groupe unGroupe = new Groupe();
                            unGroupe.nGroupe = (int)reader.GetInt32(0);
                            unGroupe.libelleGroupe = reader.GetString(1);
                            listeGroupes.Add(unGroupe);
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
            return listeGroupes;
        }

        ///<summary>
        ///Fonction non utilisée issu de l'inteface ICrud
        ///<summary>
        public ObservableCollection<Groupe> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
