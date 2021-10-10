using EnvisionStaking.Casper.SDK.Enums;
using EnvisionStaking.Casper.SDK.Model.Sse;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace EnvisionStaking.Casper.SDK.Services
{
    /// <summary>
    ///The Server-Sent Events (SSE) is a server push technology enabling a client to receive automatic updates from a server through an HTTP connection. SSE is fully supported by Casper Network. With this SDK you are able to subscribe to events and utilize the event driven operations.
    /// </summary>
    public class SseService
    {
        private readonly SseTypeEnum _sseType;
        private readonly string _sseUrl;
        private int _retriesCount;

        /// <summary>
        /// This event triggers every couple of seconds/minutes with the API Verion.
        /// </summary>
        public event EventHandler<SseApiVersion> ApiVersionUpdated;
        /// <summary>
        /// This event triggers when a Block is added in Casper Network.
        /// </summary>
        public event EventHandler<SseBlockAdded> BlockAdded;
        /// <summary>
        /// This event triggers when a Deploy is Processed in Casper Network.
        /// </summary>
        public event EventHandler<SseDeployProcessed> DeployProcessed;
        /// <summary>
        /// This event triggers on Fault occurance in Casper Network.
        /// </summary>
        public event EventHandler<string> Fault;
        /// <summary>
        /// This event triggers when a step is processed in Casper Network.
        /// </summary>
        public event EventHandler<string> Step;
        /// <summary>
        /// This event triggers when a Deploy is Accepted in Casper Network.
        /// </summary>
        public event EventHandler<SseDeployAccepted> DeployAccepted;
        /// <summary>
        /// This event triggers on Finality Signature in Casper Network.
        /// </summary>
        public event EventHandler<SseFinalitySignature> FinalitySignature;

        public SseService(string sseUrl, SseTypeEnum sseType)
        {
            _sseType = sseType;
            _sseUrl = sseUrl;
            _retriesCount = 0;
            GetEventsAsync();
        }
        /// <summary>
        /// Loop and Get the Events from SSE server async
        /// </summary>
        /// <returns></returns>
        public async Task GetEventsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(5);
                string url = $"{_sseUrl}/events/{_sseType}";
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Establishing connection");
                        using (var streamReader = new StreamReader(await client.GetStreamAsync(url)))
                        {
                            while (!streamReader.EndOfStream)
                            {
                                var message = await streamReader.ReadLineAsync();
                                ParseEvents(message);
                            }
                        }
                        _retriesCount = 0;
                    }
                    catch (Exception ex)
                    {                       
                        Console.WriteLine($"Error: {ex.Message}");
                        Console.WriteLine("Retrying in 5 seconds");

                        _retriesCount++;
                        if(_retriesCount>5)
                        {
                            throw new TimeoutException("Connection cannot be established after 5 retries.");
                        }

                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }
                }
            }
        }

        /// <summary>
        /// Parse the events received and invoke the events
        /// </summary>
        /// <param name="payload"></param>
        public void ParseEvents(string payload)
        {
            string data = string.Empty;   
            if(payload.StartsWith("Data",true,null))
            {
                data = payload.Replace("Data:", "", true, null);
                dynamic resultDynamicObject = JsonConvert.DeserializeObject(data);
                if(resultDynamicObject.ApiVersion!=null)
                {
                    if (ApiVersionUpdated != null)
                    {
                        ApiVersionUpdated.Invoke(this, JsonConvert.DeserializeObject<SseApiVersion>(data));
                    }
                }
                else if (resultDynamicObject.BlockAdded != null)
                {
                    if (BlockAdded != null)
                    {
                        BlockAdded.Invoke(this, JsonConvert.DeserializeObject<SseBlockAdded>(data));
                    }
                }
                else if (resultDynamicObject.DeployProcessed != null)
                {
                    if (DeployProcessed != null)
                    {
                        DeployProcessed.Invoke(this, JsonConvert.DeserializeObject<SseDeployProcessed>(data));
                    }
                }
                else if (resultDynamicObject.Fault != null)
                {
                    if (Fault != null)
                    {
                        Fault.Invoke(this,data);
                    }
                }
                else if (resultDynamicObject.Step != null)
                {
                    if (Step != null)
                    {
                        Step.Invoke(this, data);
                    }
                }
                else if (resultDynamicObject.DeployAccepted != null)
                {
                    if (DeployAccepted!=null)
                    {
                        DeployAccepted.Invoke(this, JsonConvert.DeserializeObject<SseDeployAccepted>(data));
                    }
                }
                else if (resultDynamicObject.FinalitySignature != null)
                {
                    if (FinalitySignature != null)
                    {
                        FinalitySignature.Invoke(this, JsonConvert.DeserializeObject<SseFinalitySignature>(data));
                    }
                }
            }           
        }
    }
}