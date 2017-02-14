﻿[assembly: System.Runtime.CompilerServices.InternalsVisibleToAttribute(@"NServiceBus.AzureStorageQueues.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100DDE965E6172E019AC82C2639FFE494DD2E7DD16347C34762A05732B492E110F2E4E2E1B5EF2D85C848CCFB671EE20A47C8D1376276708DC30A90FF1121B647BA3B7259A6BC383B2034938EF0E275B58B920375AC605076178123693C6C4F1331661A62EBA28C249386855637780E3FF5F23A6D854700EAA6803EF48907513B92")]
[assembly: System.Runtime.InteropServices.ComVisibleAttribute(false)]
[assembly: System.Runtime.Versioning.TargetFrameworkAttribute(".NETFramework,Version=v4.5.2", FrameworkDisplayName=".NET Framework 4.5.2")]

namespace NServiceBus
{
    
    public class AccountRoutingSettings
    {
        public void AddAccount(string alias, string connectionString) { }
    }
    public class AzureStorageQueueTransport : NServiceBus.Transport.TransportDefinition, NServiceBus.Routing.IMessageDrivenSubscriptionTransport
    {
        public AzureStorageQueueTransport() { }
        public override string ExampleConnectionStringForErrorMessage { get; }
        public override bool RequiresConnectionString { get; }
        public override NServiceBus.Transport.TransportInfrastructure Initialize(NServiceBus.Settings.SettingsHolder settings, string connectionString) { }
    }
    public class static AzureStorageTransportAddressingExtensions
    {
        public static NServiceBus.AccountRoutingSettings AccountRouting(this NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> transportExtensions) { }
        public static NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> DefaultAccountAlias(this NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> transportExtensions, string alias) { }
        public static NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> UseAccountAliasesInsteadOfConnectionStrings(this NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> config) { }
    }
    public class static AzureStorageTransportExtensions
    {
        public static NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> BatchSize(this NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> config, int value) { }
        public static NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> DegreeOfReceiveParallelism(this NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> config, int degreeOfReceiveParallelism) { }
        public static NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> MaximumWaitTimeWhenIdle(this NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> config, System.TimeSpan value) { }
        public static NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> MessageInvisibleTime(this NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> config, System.TimeSpan value) { }
        public static NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> PeekInterval(this NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> config, System.TimeSpan value) { }
        public static NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> SerializeMessageWrapperWith<TSerializationDefinition>(this NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> config)
            where TSerializationDefinition : NServiceBus.Serialization.SerializationDefinition, new () { }
        public static NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> UnwrapMessagesWith(this NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> config, System.Func<Microsoft.WindowsAzure.Storage.Queue.CloudQueueMessage, NServiceBus.Azure.Transports.WindowsAzureStorageQueues.MessageWrapper> unwrapper) { }
        public static NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> UseSha1ForShortening(this NServiceBus.TransportExtensions<NServiceBus.AzureStorageQueueTransport> config) { }
    }
    [System.ObsoleteAttribute("This class was replaced by extension methods on endpointConfiguration.UseTranspor" +
        "t<AzureStorageQueue>(). Will be removed in version 8.0.0.", true)]
    public class static ConfigureAzureMessageQueue { }
}
namespace NServiceBus.Azure.Transports.WindowsAzureStorageQueues
{
    
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class AzureMessageQueueCreator
    {
        public AzureMessageQueueCreator() { }
    }
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class AzureMessageQueueReceiver
    {
        public AzureMessageQueueReceiver() { }
    }
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class AzureMessageQueueSender
    {
        public AzureMessageQueueSender() { }
    }
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class AzureMessageQueueUtils
    {
        public AzureMessageQueueUtils() { }
    }
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class AzureQueueNamingConvention
    {
        public AzureQueueNamingConvention() { }
    }
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class ConnectionStringParser
    {
        public ConnectionStringParser() { }
    }
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class CreateQueueClients
    {
        public CreateQueueClients() { }
    }
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class DeterminesBestConnectionStringForStorageQueues
    {
        public DeterminesBestConnectionStringForStorageQueues() { }
    }
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class DeterministicGuidBuilder
    {
        public DeterministicGuidBuilder() { }
    }
    [System.ObsoleteAttribute("This exception was used only within the library and was not thrown outside. As su" +
        "ch it was marked as internal. Will be removed in version 8.0.0.", true)]
    public class EnvelopeDeserializationFailed
    {
        public EnvelopeDeserializationFailed() { }
    }
    [System.ObsoleteAttribute("This interface served only internal implementations and as such was removed from " +
        "the public API. For more information, refer to the documentation. Will be remove" +
        "d in version 8.0.0.", true)]
    public class ICreateQueueClients
    {
        public ICreateQueueClients() { }
    }
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class IsHostedIn
    {
        public IsHostedIn() { }
    }
    public class MessageWrapper : NServiceBus.IMessage
    {
        public MessageWrapper() { }
        public byte[] Body { get; set; }
        public string CorrelationId { get; set; }
        public System.Collections.Generic.Dictionary<string, string> Headers { get; set; }
        public string Id { get; set; }
        public string IdForCorrelation { get; set; }
        public NServiceBus.MessageIntentEnum MessageIntent { get; set; }
        public bool Recoverable { get; set; }
        public string ReplyToAddress { get; set; }
        public System.TimeSpan TimeToBeReceived { get; set; }
    }
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class PollingDequeueStrategy
    {
        public PollingDequeueStrategy() { }
    }
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class QueueAutoCreation
    {
        public QueueAutoCreation() { }
    }
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class ReceiveResourceManager
    {
        public ReceiveResourceManager() { }
    }
    [System.ObsoleteAttribute("This exception provided no value to the users, Exception is thrown in that place " +
        "with a message that role environment variable was not found. Will be removed in " +
        "version 8.0.0.", true)]
    public class RoleEnvironmentUnavailableException
    {
        public RoleEnvironmentUnavailableException() { }
    }
    [System.ObsoleteAttribute("This exception was used only within the library and was not thrown outside. As su" +
        "ch it was marked as internal. Will be removed in version 8.0.0.", true)]
    public class SafeRoleEnvironment
    {
        public SafeRoleEnvironment() { }
    }
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class SendResourceManager
    {
        public SendResourceManager() { }
    }
}
namespace NServiceBus.Config
{
    
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class AzureQueueConfig
    {
        public AzureQueueConfig() { }
    }
}
namespace NServiceBus.Features
{
    
    [System.ObsoleteAttribute("This class served only internal purposes without providing any extensibility poin" +
        "t and as such was removed from the public API. For more information, refer to th" +
        "e documentation. Will be removed in version 8.0.0.", true)]
    public class AzureStorageQueueTransport
    {
        public AzureStorageQueueTransport() { }
    }
}