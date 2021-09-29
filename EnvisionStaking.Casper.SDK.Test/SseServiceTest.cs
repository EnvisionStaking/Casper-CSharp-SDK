using EnvisionStaking.Casper.SDK.Enums;
using EnvisionStaking.Casper.SDK.Model.Sse;
using EnvisionStaking.Casper.SDK.Services;
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
    public class SseServiceTest
    {
        string sseUrl = "http://195.201.142.76:9999";

        [TestMethod]
        public void ApiVersionUpdatedEvent()
        {
            SseApiVersion result = null;
            bool isEventTriggered = false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            CasperClient casperClient = new CasperClient(sseUrl);
            casperClient.SseService = new SseService(sseUrl, SseTypeEnum.main);
            casperClient.SseService.ApiVersionUpdated += SseService_ApiVersionUpdated;

            while (!isEventTriggered && stopwatch.ElapsedMilliseconds < 5000)
            {
                Thread.Sleep(1000);
            }

            if (isEventTriggered)
            {
                Assert.IsNotNull(result.ApiVersion);
            }
            else
            {
                Assert.Inconclusive("Event passed the threshold wait time");
            }

            void SseService_ApiVersionUpdated(object sender, SseApiVersion e)
            {
                result = e;
                isEventTriggered = true;
            }
        }

        [TestMethod]
        public void BlockAddedEvent()
        {
            SseBlockAdded result = null;
            bool isEventTriggered = false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            CasperClient casperClient = new CasperClient(sseUrl);
            casperClient.SseService = new SseService(sseUrl, SseTypeEnum.main);
            casperClient.SseService.BlockAdded += SseService_BlockAdded;

            while (!isEventTriggered && stopwatch.ElapsedMilliseconds < 61000)
            {
                Thread.Sleep(1000);
            }

            if (isEventTriggered)
            {
                Assert.IsNotNull(result.BlockAdded.block);
            }
            else
            {
                Assert.Inconclusive("Event passed the threshold wait time");
            }

            void SseService_BlockAdded(object sender, SseBlockAdded e)
            {
                result = e;
                isEventTriggered = true;
            }
        }

        [TestMethod]
        public void FinalitySignatureEvent()
        {
            SseFinalitySignature result = null;
            bool isEventTriggered = false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            CasperClient casperClient = new CasperClient(sseUrl);
            casperClient.SseService = new SseService(sseUrl, SseTypeEnum.sigs);
            casperClient.SseService.FinalitySignature += SseService_FinalitySignature;

            while (!isEventTriggered && stopwatch.ElapsedMilliseconds < 60000)
            {
                Thread.Sleep(1000);
            }

            if (isEventTriggered)
            {
                Assert.IsNotNull(result.FinalitySignature);
            }
            else
            {
                Assert.Inconclusive("Event passed the threshold wait time");
            }

            void SseService_FinalitySignature(object sender, SseFinalitySignature e)
            {
                result = e;
                isEventTriggered = true;
            }
        }

        [TestMethod]
        public void DeployProcessedEvent()
        {
            SseDeployProcessed result = null;
            bool isEventTriggered = false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            CasperClient casperClient = new CasperClient(sseUrl);
            casperClient.SseService = new SseService(sseUrl, SseTypeEnum.main);
            casperClient.SseService.DeployProcessed += SseService_DeployProcessed;

            while (!isEventTriggered && stopwatch.ElapsedMilliseconds < 60000)
            {
                Thread.Sleep(1000);
            }

            if (isEventTriggered)
            {
                Assert.IsNotNull(result.DeployProcessed);
            }
            else
            {
                Assert.Inconclusive("Event passed the threshold wait time");
            }

            void SseService_DeployProcessed(object sender, SseDeployProcessed e)
            {
                result = e;
                isEventTriggered = true;
            }
        }

        [TestMethod]
        public void DeployAcceptedEvent()
        {
            SseDeployAccepted result = null;
            bool isEventTriggered = false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            CasperClient casperClient = new CasperClient(sseUrl);
            casperClient.SseService = new SseService(sseUrl, SseTypeEnum.deploys);
            casperClient.SseService.DeployAccepted += SseService_DeployAccepted;

            while (!isEventTriggered && stopwatch.ElapsedMilliseconds < 60000)
            {
                Thread.Sleep(1000);
            }

            if (isEventTriggered)
            {
                Assert.IsNotNull(result.DeployAccepted);
            }
            else
            {
                Assert.Inconclusive("Event passed the threshold wait time");
            }

            void SseService_DeployAccepted(object sender, SseDeployAccepted e)
            {
                result = e;
                isEventTriggered = true;
            }
        }

        [TestMethod]
        public void FaultEvent()
        {
            string result = null;
            bool isEventTriggered = false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            CasperClient casperClient = new CasperClient(sseUrl);
            casperClient.SseService = new SseService(sseUrl, SseTypeEnum.main);
            casperClient.SseService.Fault += SseService_Fault;

            while (!isEventTriggered && stopwatch.ElapsedMilliseconds < 20000)
            {
                Thread.Sleep(1000);
            }

            if (isEventTriggered)
            {
                Assert.IsNotNull(result);
            }
            else
            {
                Assert.Inconclusive("Event passed the threshold wait time");
            }
           

            void SseService_Fault(object sender, string e)
            {
                result = e;
                isEventTriggered = true;
            }
        }

        [TestMethod]
        public void StepEvent()
        {
            string result = null;
            bool isEventTriggered = false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            CasperClient casperClient = new CasperClient(sseUrl);
            casperClient.SseService = new SseService(sseUrl, SseTypeEnum.main);
            casperClient.SseService.Step += SseService_Step;

            while (!isEventTriggered && stopwatch.ElapsedMilliseconds < 20000)
            {
                Thread.Sleep(1000);
            }

            if (isEventTriggered)
            {
                Assert.IsNotNull(result);
            }
            else
            {
                Assert.Inconclusive("Event passed the threshold wait time");
            }

            void SseService_Step(object sender, string e)
            {
                result = e;
                isEventTriggered = true;
            }
        }
    }
}
