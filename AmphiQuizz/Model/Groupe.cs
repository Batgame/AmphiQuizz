using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAmphi.Model
{
    public class Groupe
    {
        private int idGroupe;
        public int IdGroupe { get => idGroupe; set => idGroupe = value; }

        private string libelleGroupe;
        public string LibelleGroupe { get => libelleGroupe; set => libelleGroupe = value; }

        public Groupe(int pIdGroupe, string pLibelleGroupe)
        {
            this.IdGroupe = pIdGroupe;
            this.LibelleGroupe = pLibelleGroupe;
        }

        public override string ToString()
        {
            return LibelleGroupe;
        }

        public override bool Equals(object obj)
        {
            return obj is Groupe groupe &&
                   IdGroupe == groupe.IdGroupe &&
                   LibelleGroupe == groupe.LibelleGroupe;
        }

        public override int GetHashCode()
        {
            int hashCode = 827657482;
            hashCode = hashCode * -1521134295 + IdGroupe.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LibelleGroupe);
            return hashCode;
        }
    }
}
