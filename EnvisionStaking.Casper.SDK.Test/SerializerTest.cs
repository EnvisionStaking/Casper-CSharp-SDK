﻿using EnvisionStaking.Casper.SDK.Enums;
using EnvisionStaking.Casper.SDK.Model.Sse;
using EnvisionStaking.Casper.SDK.Serialization;
using EnvisionStaking.Casper.SDK.Services;
using EnvisionStaking.Casper.SDK.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnvisionStaking.Casper.SDK.Test
{
    [TestClass]
    public class SerializerTest
    {
        [TestMethod]
        public void Getu512Serializer()
        {
            float amount = 5000000000000;
            string correctResultAmount = "06005039278c04";

            byte[] result= TypesSerializer.Getu512Serializer(5000000000000);

            string hex = ByteUtil.ByteArrayToHex(result);

            Assert.AreEqual(correctResultAmount, hex);
        }

    }
}
