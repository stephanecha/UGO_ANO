using NUnit.Framework;
using System;
using System.Collections.Generic;
using UGO_ANO.CLASS;
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
            l_newParam.DATABASE = "CONNECTIONSTRING";
            l_newParam.DATE_BEGIN = DateTime.Now.Date;
            l_newParam.DATE_END = DateTime.Now.AddDays(10).Date;


            List<Field> list = new List<Field>();
            list.Add(new Field() { TABLE = "T_NATURAL_PERSON", COLUMN = "LASTNAME_VC", TYPE = "TBOLO" });
            list.Add(new Field() { TABLE = "T_NATURAL_PERSON", COLUMN = "FIRSTNAME_VC", TYPE = "TBOLO" });
            list.Add(new Field() { TABLE = "T_NATURAL_PERSON", COLUMN = "BirthDate_DT", TYPE = "TDATE", OPTION = 1 });
            list.Add(new Field() { TABLE = "T_POSTAL_ADDRESS", COLUMN = "CODE_POSTAL", TYPE = "TINT" });
            l_newParam.DataToAno = list;

            CommonTools.SerialParam(l_newParam);
            FileAssert.Exists("param.json");
            
            

            Param l_getParam = CommonTools.DeserialParam("param.json");
            #endregion

            Assert.IsNotNull(l_getParam);
        }
    }
}