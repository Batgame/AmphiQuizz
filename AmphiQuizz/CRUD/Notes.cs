using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmphiQuizz
{
    public class Notes : ICrud<Notes>
    {
        private Prof unProf;

        /// <remarks>
        /// Propriété contenant un professeur
        /// </remarks>
        public Prof UnProf { get => unProf; set => unProf = value; }

        /// <remarks>
        /// Propriété contenant un étudiant
        /// </remarks>
        private Etudiant unEtu;
        public Etudiant UnEtu { get => unEtu;  set => unEtu = value; }

        /// <remarks>
        /// Propriété contenant une note
        /// </remarks>
        private int uneNote;
        public int UneNote 
        { 
            get => uneNote;
            set
            {
                uneNote = value;
                if(this.uneNote == 0)
                {
                    this.Signification = "Elève absent";
                }
                if (this.uneNote == 1)
                {
                    this.Signification = "Mauvaise réponse";
                }
                if (this.uneNote == 2)
                {
                    this.Signification = "Bonne réponse";
                }
            }
        }

        /// <remarks>
        /// Propriété contenant la signification d'une note
        /// </remarks>
        private string signification;
        public string Signification { get => signification; set => signification = value; }

        /// <remarks>
        /// Propriété contenant une date
        /// </remarks>

        private DateTime uneDate;
        public DateTime UneDate { get => uneDate; set => uneDate = value; }


        /// <summary>
        /// Instancie une nouvelle note
        /// </summary>
        /// <param name="pNote"> Représente la valeur de la note </param>
        public Notes(int pNote)
        {  
            this.UneNote = pNote;
        }

        /// <summary>
        /// Fonction non utilisée issu de l'inteface ICrud
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Notes> FindAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insère une note dans la base de donnée
        /// </summary>
        /// <param name="e"> Représente l'objet de l'étudiant noté</param>
        /// <param name="p"> Représente l'objet du professeur qui donne la note</param>
        /// <param name="n"> Représente la note donnée en elle même</param>
        public bool Create(Etudiant e, Prof p, Notes n)
        {
            DataAccess access = new DataAccess();
            try
            {
                if(access.openConnection())
                {
                    access.setData("insert into [iut-acy\\genodb].note values("+ e.IdEtu + "," + p.IdPersonne  + ",'" + DateTime.Now.ToString() + "'," + n.UneNote + ")");
                    access.closeConnection();
                }
            }
            catch(Exception exe)
            {
                System.Windows.MessageBox.Show(exe.Message, "Message Important");
                return false;
            }
            return true;
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
        /// Fonction non utilisée issu de l'inteface ICrud
        /// </summary>

        public ObservableCollection<Notes> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
