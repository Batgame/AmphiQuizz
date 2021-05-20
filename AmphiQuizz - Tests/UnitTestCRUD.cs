using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmphiQuizz;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace AmphiQuizz___Tests
{
    [TestClass]
    public class UnitTestEtudiant
    {
  
        [TestMethod]
        public void TestFindAllEtu()
        {
            ApplicationData.loadApplicationData();
            Etudiant e = new Etudiant();
            Assert.AreEqual(107, e.FindAll().Count);
        }

    }

    [TestClass]
    public class UnitTestNotes
    {
        [TestMethod]
        public void TestCreate()
        {
            ApplicationData.loadApplicationData();
            Notes n = new Notes(2);
            Etudiant e = new Etudiant();
            Prof p = new Prof();
            p.IdPersonne = 2;
            e.IdEtu = 146;
            n.UnEtu = e;

            Assert.AreEqual(true, n.Create(e, p, n));
        }

    }

    [TestClass]
    public class UnitTestGroupes
    {
        [TestMethod]
        public void TestFindAllGroupe()
        {
            ApplicationData.loadApplicationData();
            Groupe g = new Groupe();
            Assert.AreEqual(4, g.FindAll().Count);
        }
    }

    [TestClass]
    public class UnitTestProf
    {
        [TestMethod]
        public void TestFindAllProf()
        {
            ApplicationData.loadApplicationData();
            Prof p = new Prof();
            Assert.AreEqual(4, p.FindAll().Count);
        }
    }
}
