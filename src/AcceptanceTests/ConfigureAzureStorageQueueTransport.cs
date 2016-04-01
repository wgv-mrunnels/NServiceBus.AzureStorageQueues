﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using NServiceBus;
using NServiceBus.AcceptanceTesting.Support;
using NServiceBus.AcceptanceTests.ScenarioDescriptors;
using NServiceBus.Azure.Transports.WindowsAzureStorageQueues;

public class ConfigureScenariosForAzureStorageQueueTransport : IConfigureSupportedScenariosForTestExecution
{
    public IEnumerable<Type> UnsupportedScenarioDescriptorTypes { get; } = new[]
    {
        typeof(AllTransportsWithCentralizedPubSubSupport),
        typeof(AllDtcTransports),
        typeof(AllTransportsWithoutNativeDeferralAndWithAtomicSendAndReceive)
    };
}

public class ConfigureEndpointAzureStorageQueueTransport : IConfigureEndpointTestExecution
{
    public Task Configure(string endpointName, EndpointConfiguration configuration, RunSettings settings)
    {
        var connectionString = settings.Get<string>("Transport.ConnectionString");
        configuration.UseSerialization<XmlSerializer>();
        configuration.UseTransport<AzureStorageQueueTransport>()
            .ConnectionString(connectionString)
            .MessageInvisibleTime(TimeSpan.FromSeconds(5))
            .SerializeMessageWrapperWith(definition => MessageWrapperSerializer.Xml.Value);

        CleanQueuesUsedByTest(connectionString);

        return Task.FromResult(0);
    }

    public Task Cleanup()
    {
        return Task.FromResult(0);
    }

    private static void CleanQueuesUsedByTest(string connectionString)
    {
        var storage = CloudStorageAccount.Parse(connectionString);
        var client = storage.CreateCloudQueueClient();
        var queues = GetTestRelatedQueues(client).ToArray();

        var countdown = new CountdownEvent(queues.Length);

        foreach (var queue in queues)
        {
            queue.ClearAsync().ContinueWith(t => countdown.Signal());
        }

        if (countdown.Wait(TimeSpan.FromMinutes(1)) == false)
        {
            throw new TimeoutException("Waiting for cleaning queues took too much.");
        }
    }

    private static IEnumerable<CloudQueue> GetTestRelatedQueues(CloudQueueClient queues)
    {
        // for now, return all
        return queues.ListQueues();
    }
}