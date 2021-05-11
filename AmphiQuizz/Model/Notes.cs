using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAmphi.Model
{
    public class Notes
    {
        private int note;
        public int Note { get => note; set => note = value; }

        private string signification;
        public string Signification { get => signification; set => signification = value; }

        public static List<Notes> FindAll()
        {
            List<Notes> listNotes = new List<Notes>();
            listNotes.Add(new Notes { Note = 0, Signification = "L'élève est absent" });
            listNotes.Add(new Notes { Note = 1, Signification = "Donne une mauvaise réponse" });
            listNotes.Add(new Notes { Note = 2, Signification = "Donne une bonne réponse" });
            return listNotes;
        }
    }
}
