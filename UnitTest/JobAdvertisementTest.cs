using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Entity;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class JobAdvertisementTest
    {
        [TestMethod]
        public void Get_All_JobAdvertisements()
        {
            List<JobAdvertisement> offres = BusinessManager.Instance().GetAllJobAdvertisements();
            Assert.IsTrue(offres.Count > 0);
        }

        [TestMethod]
        public void Get_JobAdvertisement_By_Id()
        {
            JobAdvertisement jobAdvertisement = BusinessManager.Instance().GetJobAdvertisementById(1);
            Assert.IsNotNull(jobAdvertisement);
        }
    }
}
