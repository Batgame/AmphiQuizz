using AmphiQuizz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AmphiQuizz___Tests
{
    [TestClass]
    public class DataAccesTest
    {
        [TestMethod]
        public void openConnectionTest()
        {
            DataAccess acces = new DataAccess();

            Assert.IsTrue(acces.openConnection());
            acces.closeConnection();
        }

        [TestMethod]
        public void closeConnectionTest()
        {
            DataAccess access = new DataAccess();
            access.openConnection();

            Assert.IsTrue(access.closeConnection());
        }

        [TestMethod]
        public void getDataSet()
        {
            DataAccess acces = new DataAccess();
            acces.openConnection();
            SqlDataReader reader;

            reader = acces.getData("select * from [iut-acy\\genodb].note");
            Assert.IsTrue(reader.Read());
            acces.closeConnection();
        }

        [TestMethod]
        public void setDataTest()
        {
            DataAccess acces = new DataAccess();
            Assert.AreEqual(true, acces.setData("insert into [iut-acy\\genodb].note values (202, 3, '" + DateTime.Now +"', 2)"));
        }
    }

    [TestClass]
    public class ApplicationDataTest
    {
        [TestMethod]
        public void loadApplicationDataTest()
        {
            Assert.AreEqual(true, ApplicationData.loadApplicationData());
        }
    }
}
