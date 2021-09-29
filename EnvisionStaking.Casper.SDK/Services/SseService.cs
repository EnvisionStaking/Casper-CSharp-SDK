using EnvisionStaking.Casper.SDK.Enums;
using EnvisionStaking.Casper.SDK.Model.Sse;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace EnvisionStaking.Casper.SDK.Services
{
    public class SseService
    {
        private readonly SseType _sseType;
        private readonly string _sseUrl;
        private int _retriesCount;

        public event EventHandler<SseApiVersion> ApiVersionUpdated;
        public event EventHandler<SseBlockAdded> BlockAdded;
        public event EventHandler<SseDeployProcessed> DeployProcessed;
        public event EventHandler<string> Fault;
        public event EventHandler<string> Step;
        public event EventHandler<SseDeployAccepted> DeployAccepted;
        public event EventHandler<SseFinalitySignature> FinalitySignature;

        public SseService(string sseUrl, SseType sseType)
        {
            _sseType = sseType;
            _sseUrl = sseUrl;
            _retriesCount = 0;
            GetEventsAsync();
        }

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