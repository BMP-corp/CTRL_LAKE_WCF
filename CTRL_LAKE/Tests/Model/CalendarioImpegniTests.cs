﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFWebService.Tests
{
    [TestClass()]
    public class CalendarioImpegniTests
    {
        CalendarioImpegni c1;
        Impegno i1, i2, i3;

        [TestInitialize]
        public void Initialize()
        {
            c1 = new CalendarioImpegni("1001");
            i1 = new Impegno(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0), "1001");  // 15/06 9-11
            i2 = new Impegno(new DateTime(2018, 06, 15, 12, 0, 0), new DateTime(2018, 06, 15, 13, 0, 0), "1001"); // 15/06 12-13
            i3 = new Impegno(new DateTime(2018, 06, 16, 9, 0, 0), new DateTime(2018, 06, 16, 11, 0, 0), "1001");  // 16/06 9-11
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void AggiungiTest()
        {
            c1.Aggiungi(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            Assert.AreEqual(1, c1.Impegni.Count);
            c1.Aggiungi(new DateTime(2018, 06, 15, 12, 0, 0), new DateTime(2018, 06, 15, 13, 0, 0));
            Assert.AreEqual(2, c1.Impegni.Count);
            c1.Aggiungi(new DateTime(2018, 06, 16, 9, 0, 0), new DateTime(2018, 06, 16, 11, 0, 0));
            Assert.AreEqual(3, c1.Impegni.Count);
            c1.Aggiungi(new DateTime(2018, 06, 15, 12, 0, 0), new DateTime(2018, 06, 15, 14, 0, 0)); //attesa eccezione
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void RimuoviTest()
        {
            c1.Aggiungi(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            c1.Aggiungi(new DateTime(2018, 06, 15, 12, 0, 0), new DateTime(2018, 06, 15, 13, 0, 0));
            c1.Rimuovi(new DateTime(2018, 06, 15, 9, 0, 0), new DateTime(2018, 06, 15, 11, 0, 0));
            Assert.AreEqual(1, c1.Impegni.Count);
            c1.Rimuovi(new DateTime(2018, 06, 18, 9, 0, 0), new DateTime(2018, 06, 18, 11, 0, 0)); // attesa eccezione
        }
    }
}