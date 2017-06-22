﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.AcceptanceTesting.Support;
using NServiceBus.AcceptanceTests.Routing.MessageDrivenSubscriptions;
using NServiceBus.AcceptanceTests.ScenarioDescriptors;
using NUnit.Framework;
using Conventions = NServiceBus.AcceptanceTesting.Customization.Conventions;

public class ConfigureEndpointAzureStorageQueueTransport : IConfigureEndpointTestExecution
{
    internal static string ConnectionString => EnvironmentHelper.GetEnvironmentVariable($"{nameof(AzureStorageQueueTransport)}.ConnectionString") ?? "UseDevelopmentStorage=true";

    public Task Configure(string endpointName, EndpointConfiguration configuration, RunSettings settings, PublisherMetadata publisherMetadata)
    {
        var connectionString = ConnectionString;

        var transportConfig = configuration
            .UseTransport<AzureStorageQueueTransport>()
            .ConnectionString(connectionString)
            .MessageInvisibleTime(TimeSpan.FromSeconds(30));

        EnableNativeDelayedDelivery(endpointName, transportConfig);

        var routingConfig = transportConfig.Routing();

        foreach (var publisher in publisherMetadata.Publishers)
        {
            foreach (var eventType in publisher.Events)
            {
                routingConfig.RegisterPublisher(eventType, publisher.PublisherName);
            }
        }

        if (endpointName.StartsWith(Conventions.EndpointNamingConvention(typeof(When_unsubscribing_from_event.Publisher))))
        {
            Assert.Ignore("Ignored until issue #173 is resolved.");
        }

        if (endpointName.StartsWith("RegisteringAdditionalDeserializers.CustomSerializationSender"))
        {
            Assert.Ignore("Ignored since this scenario is not supported by ASQ.");
        }

        configuration.UseSerialization<XmlSerializer>();

        configuration.Pipeline.Register("test-independence-skip", typeof(TestIndependence.SkipBehavior), "Skips messages from other runs");
        transportConfig.SerializeMessageWrapperWith<TestIndependence.TestIdAppendingSerializationDefinition<JsonSerializer>>();

        return Task.FromResult(0);
    }

    static void EnableNativeDelayedDelivery(string endpointName, TransportExtensions<AzureStorageQueueTransport> transportConfig)
    {
        byte[] hashedName;
        using (var sha1 = new SHA1Managed())
        {
            sha1.Initialize();
            hashedName = sha1.ComputeHash(Encoding.UTF8.GetBytes(endpointName));
        }

        var hashName = BitConverter.ToString(hashedName).Replace("-", string.Empty);
        var timeoutTableName = "timeouts" + hashName;

        var delayedDelivery = transportConfig.DelayedDelivery(timeoutTableName);

        delayedDelivery.DisableTimeoutManager();
    }

    public Task Cleanup()
    {
        return Task.FromResult(0);
    }
}