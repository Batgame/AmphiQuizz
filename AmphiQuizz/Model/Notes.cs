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
        public Prof UnProf { get => unProf; set => unProf = value; }

        private Etudiant unEtu;
        public Etudiant UnEtu { get => unEtu;  set => unEtu = value; }

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

        private string signification;
        public string Signification { get => signification; set => signification = value; }

        private DateTime uneDate;
        public DateTime UneDate { get => uneDate; set => uneDate = value; }


        /// <summary>
        /// Instancie une nouvelle note 
        /// <paramref name="pNote" 
        /// </summary>
        public Notes(int pNote)
        {  
            this.UneNote = pNote;
        }

        public ObservableCollection<Notes> FindAll()
        {
            /*
            ObservableCollection<Notes> listNotes = new ObservableCollection<Notes>();
            listNotes.Add(new Notes { Note = 0, Signification = "L'élève est absent" });
            listNotes.Add(new Notes { Note = 1, Signification = "Donne une mauvaise réponse" });
            listNotes.Add(new Notes { Note = 2, Signification = "Donne une bonne réponse" });
            return listNotes;
            */
            throw new NotImplementedException();
        }

        public void Create(Etudiant e, Prof p, Notes n)
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
            }
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }


        public ObservableCollection<Notes> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
