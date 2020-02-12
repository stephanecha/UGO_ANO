using NUnit.Framework;
using System;
using System.Collections.Generic;
using UGO_ANO.CLASSES;
using System.IO;
using System.Data.SqlClient;

namespace NUnit_UGO_ANO
{
    public class TestDataBase
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test Unitaire sur la serialisation/deserialisation du fichier param.json
        /// </summary>
        //[Test]
        //public void Test_Database()
        //{

        //    string l_connectionStringOK = "Server=EXT-PO1939WB3\\SQLEXPRESS;Database=UGO;User Id=adm;Password=adm;";
        //    string l_connectionStringKO = "Server=EXT-PO1939WB3\\SQLEXPRESS;Database=UGO;User Id=adm;Password=;";

        //    Database l_database = new Database();
        //    Assert.IsFalse(l_database.InitDatabase(l_connectionStringKO));
        //    Assert.IsTrue(l_database.InitDatabase(l_connectionStringOK));
        //}
    }
}