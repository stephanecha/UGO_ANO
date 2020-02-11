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
            CParam l_newParam = new CParam();
            l_newParam.DATABASE = "CONNECTIONSTRING";
            l_newParam.DATE_BEGIN = DateTime.Now.Date;
            l_newParam.DATE_END = DateTime.Now.AddDays(10).Date;


            List<CField> list = new List<CField>();
            list.Add(new CField() { TABLE = "T_NATURAL_PERSON", FIELD = "LASTNAME_VC", TYPE = "TBOLO" });
            list.Add(new CField() { TABLE = "T_NATURAL_PERSON", FIELD = "FIRSTNAME_VC", TYPE = "TBOLO" });
            list.Add(new CField() { TABLE = "T_NATURAL_PERSON", FIELD = "BirthDate_DT", TYPE = "TDATE", OPTION = 1 });
            list.Add(new CField() { TABLE = "T_POSTAL_ADDRESS", FIELD = "CODE_POSTAL", TYPE = "TINT" });
            l_newParam.UGO = list;

            FileAssert.Exists("param.json");
            
            CCommonTools.SerialParam(l_newParam);

            CParam l_getParam = CCommonTools.DeserialParam("param.json");
            #endregion

            Assert.IsNotNull(l_getParam);
        }
    }
}