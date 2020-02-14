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
        [Test]
        public void Test_Database()
        {

            string l_connectionStringOK = "Server=localhost;Database=UGO;User Id=adm;Password=adm;";
            string l_connectionStringKO = "Server=localhost;Database=UGO;User Id=adm;Password=;";

            Database l_database = new Database();
            Assert.IsFalse(l_database.InitDatabase(l_connectionStringKO));
            Assert.IsTrue(l_database.InitDatabase(l_connectionStringOK));
        }


        [Test]
        public void Test_CheckTableColumnType()
        {
            Database l_database = new Database();
            l_database.InitDatabase("Server=localhost;Database=UGO;User Id=adm;Password=adm;");

            #region FICHIER OK
            List <Field> list = new List<Field>();
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "LASTNAME_VC", Type = UGO_ANO.CLASSES.Type.TBOLO });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "FIRSTNAME_VC", Type = UGO_ANO.CLASSES.Type.TBOLO });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "BirthDate_DT", Type = UGO_ANO.CLASSES.Type.TDATE, Option = 1 });
            list.Add(new Field() { Table = "T_POSTAL_ADDRESS", Column = "CODE_POSTAL", Type = UGO_ANO.CLASSES.Type.TINT });

            Assert.AreEqual(0, l_database.CheckTableColumnType(list));
            #endregion

            #region FICHIER TBOLO erreur
            list = new List<Field>();
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "LASTNAME_VC", Type = UGO_ANO.CLASSES.Type.TBOLO });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "FIRSTNAME_VC", Type = UGO_ANO.CLASSES.Type.TBOLO });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "BirthDate_DT", Type = UGO_ANO.CLASSES.Type.TBOLO, Option = 1 });
            list.Add(new Field() { Table = "T_POSTAL_ADDRESS", Column = "CODE_POSTAL", Type = UGO_ANO.CLASSES.Type.TINT });

            Assert.AreEqual(2, l_database.CheckTableColumnType(list));
            #endregion

            #region FICHIER TINT Erreur
            list = new List<Field>();
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "LASTNAME_VC", Type = UGO_ANO.CLASSES.Type.TBOLO });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "FIRSTNAME_VC", Type = UGO_ANO.CLASSES.Type.TBOLO });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "BirthDate_DT", Type = UGO_ANO.CLASSES.Type.TINT, Option = 1 });
            list.Add(new Field() { Table = "T_POSTAL_ADDRESS", Column = "CODE_POSTAL", Type = UGO_ANO.CLASSES.Type.TINT });

            Assert.AreEqual(2, l_database.CheckTableColumnType(list));
            #endregion

            #region FICHIER TDATE Erreur
            list = new List<Field>();
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "LASTNAME_VC", Type = UGO_ANO.CLASSES.Type.TDATE });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "FIRSTNAME_VC", Type = UGO_ANO.CLASSES.Type.TBOLO });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "BirthDate_DT", Type = UGO_ANO.CLASSES.Type.TDATE, Option = 1 });
            list.Add(new Field() { Table = "T_POSTAL_ADDRESS", Column = "CODE_POSTAL", Type = UGO_ANO.CLASSES.Type.TINT });

            Assert.AreEqual(2, l_database.CheckTableColumnType(list));
            #endregion

            #region FICHIER TABLE not exist
            list = new List<Field>();
            list.Add(new Field() { Table = "T_NATURAL_PSON", Column = "LASTNAME_VC", Type = UGO_ANO.CLASSES.Type.TBOLO });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "FIRSTNAME_VC", Type = UGO_ANO.CLASSES.Type.TBOLO });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "BirthDate_DT", Type = UGO_ANO.CLASSES.Type.TDATE, Option = 1 });
            list.Add(new Field() { Table = "T_POSTAL_ADDRESS", Column = "CODE_POSTAL", Type = UGO_ANO.CLASSES.Type.TINT });

            Assert.AreEqual(1, l_database.CheckTableColumnType(list));
            #endregion

            #region FICHIER COLUMN not exist
            list = new List<Field>();
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "LASTNAME_VC", Type = UGO_ANO.CLASSES.Type.TBOLO });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "FIRSTNAME_VC", Type = UGO_ANO.CLASSES.Type.TBOLO });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "BirthDa_DT", Type = UGO_ANO.CLASSES.Type.TDATE, Option = 1 });
            list.Add(new Field() { Table = "T_POSTAL_ADDRESS", Column = "CODE_POSTAL", Type = UGO_ANO.CLASSES.Type.TINT });

            Assert.AreEqual(1, l_database.CheckTableColumnType(list));
            #endregion

        }

    }
}