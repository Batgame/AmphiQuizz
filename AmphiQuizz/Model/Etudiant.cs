using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPAmphi.Model
{
    public class Etudiant : Personne
    {
        private int idEtu;
        public int IdEtu { get => idEtu; set => idEtu = value; }

        private string photoEtu;
        public string PhotoEtu { get => photoEtu; set => photoEtu = value; }

        public Etudiant(int pIdPersonne, string pNomPersonne, string pPrenomPersonne, int pIdEtu, string pPhotoEtu) : base(pIdPersonne, pNomPersonne, pPrenomPersonne)
        {
            this.idEtu = pIdEtu;
            this.photoEtu = pPhotoEtu;
        }

        public override string ToString()
        {
            return base.ToString() + "\nId Etu : " + IdEtu + "\nPhoto : " + PhotoEtu;
        }
    }
}
