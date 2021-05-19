using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmphiQuizz
{
    public interface ICrud<T>
    {
        void Create(Etudiant e, Prof p, Notes n);
        void Read();
        void Update();
        void Delete();
        ObservableCollection<T> FindAll();
        ObservableCollection<T> FindBySelection(string criteres);
    }
}
