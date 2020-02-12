using NUnit.Framework;
using System;
using System.Collections.Generic;
using UGO_ANO.CLASSES;
using System.IO;

namespace NUnit_UGO_ANO
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test Unitaire sur la serialisation/deserialisation du fichier param.json
        /// </summary>
        [Test]
        public void Test_JSONParam()
        {

            File.Delete("param.json");

            #region  
            Param l_newParam = new Param();
            l_newParam.Database = "Server=EXT-PO1939WB3;Database=UGO;User Id=0rverger;Password=Mdp@54669996;";
            l_newParam.DateBegin = DateTime.Now.Date;
            l_newParam.DateEnd = DateTime.Now.AddDays(10).Date;


            List<Field> list = new List<Field>();
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "LASTNAME_VC", Type = "TBOLO" });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "FIRSTNAME_VC", Type = "TBOLO" });
            list.Add(new Field() { Table = "T_NATURAL_PERSON", Column = "BirthDate_DT", Type = "TDATE", Option = 1 });
            list.Add(new Field() { Table = "T_POSTAL_ADDRESS", Column = "CODE_POSTAL", Type = "TINT" });
            l_newParam.DataToAno = list;

            CommonTools.SerialParam(l_newParam);
            FileAssert.Exists("param.json");
            
            

            Param l_getParam = CommonTools.DeserialParam("param.json");
            #endregion

            Assert.IsNotNull(l_getParam);
        }
    }
}