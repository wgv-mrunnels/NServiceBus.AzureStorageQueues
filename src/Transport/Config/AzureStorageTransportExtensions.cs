namespace NServiceBus
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using NServiceBus.Azure.Transports.WindowsAzureStorageQueues;
    using NServiceBus.Configuration.AdvanceExtensibility;
    using NServiceBus.Serialization;

    public static class AzureStorageTransportExtensions
    {
        /// <summary>
        ///     Sets the amount of time, in milliseconds, to add to the time to wait before checking for a new message
        /// </summary>
        /// <param name="config"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TransportExtensions<AzureStorageQueueTransport> PeekInterval(this TransportExtensions<AzureStorageQueueTransport> config, int value)
        {
            config.GetSettings().Set(ReceiverPeekInterval, value);
            return config;
        }

        /// <summary>
        ///     Sets the maximum amount of time, in milliseconds, that the queue will wait before checking for a new message
        /// </summary>
        /// <param name="config"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TransportExtensions<AzureStorageQueueTransport> MaximumWaitTimeWhenIdle(this TransportExtensions<AzureStorageQueueTransport> config, int value)
        {
            config.GetSettings().Set(ReceiverMaximumWaitTimeWhenIdle, value);
            return config;
        }

        /// <summary>
        ///     Controls how long messages should be invisible to other callers when receiving messages from the queue
        /// </summary>
        /// <param name="config"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TransportExtensions<AzureStorageQueueTransport> MessageInvisibleTime(this TransportExtensions<AzureStorageQueueTransport> config, int value)
        {
            config.GetSettings().Set(ReceiverMessageInvisibleTime, value);
            return config;
        }

        /// <summary>
        ///     Controls how long messages should be invisible to other callers when receiving messages from the queue
        /// </summary>
        /// <param name="config"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TransportExtensions<AzureStorageQueueTransport> MessageInvisibleTime(this TransportExtensions<AzureStorageQueueTransport> config, TimeSpan value)
        {
            return config.MessageInvisibleTime((int) value.TotalMilliseconds);
        }

        /// <summary>
        ///     Controls how many messages should be read from the queue at once
        /// </summary>
        /// <param name="config"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TransportExtensions<AzureStorageQueueTransport> BatchSize(this TransportExtensions<AzureStorageQueueTransport> config, int value)
        {
            config.GetSettings().Set(ReceiverBatchSize, value);
            return config;
        }

        /// <summary>
        ///     Sets a custom serialization for <see cref="MessageWrapper" /> if your configurations uses serialization different
        ///     from <see cref="XmlSerializer" /> or <see cref="JsonSerializer" />.
        /// </summary>
        /// <returns></returns>
        public static TransportExtensions<AzureStorageQueueTransport> SerializeMessageWrapperWith(this TransportExtensions<AzureStorageQueueTransport> config, Action<MessageWrapper, Stream> serialize, Func<Stream, MessageWrapper> deserialize)
        {
            return SerializeMessageWrapperWith(config, new MessageWrapperSerializer(serialize, deserialize));
        }

        /// <summary>
        ///     Sets a custom serialization for <see cref="MessageWrapper" /> if your configurations uses serialization different
        ///     from <see cref="XmlSerializer" /> or <see cref="JsonSerializer" />.
        /// </summary>
        /// <returns></returns>
        public static TransportExtensions<AzureStorageQueueTransport> SerializeMessageWrapperWith(this TransportExtensions<AzureStorageQueueTransport> config, Func<SerializationDefinition, MessageWrapperSerializer> serializerFactory)
        {
            config.GetSettings().Set(MessageWrapperSerializerFactory, serializerFactory);
            return config;
        }

        /// <summary>
        ///     Makes the transport create sending queues as well. This is a non-default behavior as sending queues are created by
        ///     receivers.
        /// </summary>
        public static TransportExtensions<AzureStorageQueueTransport> CreateSendingQueues(this TransportExtensions<AzureStorageQueueTransport> config)
        {
            config.GetSettings().Set(TransportCreateSendingQueues, true);
            return config;
        }

        public static TransportExtensions<AzureStorageQueueTransport> UseSha1ForShortening(this TransportExtensions<AzureStorageQueueTransport> config)
        {
            config.GetSettings().Set(Sha1Shortener, true);
            return config;
        }


        private static TransportExtensions<AzureStorageQueueTransport> SerializeMessageWrapperWith(TransportExtensions<AzureStorageQueueTransport> config, MessageWrapperSerializer serializer)
        {
            config.GetSettings().Set(MessageWrapperSerializer, serializer);
            return config;
        }

        // ReSharper disable ConvertToConstant.Global
        internal static readonly string ReceiverPeekInterval = "";
        internal static readonly string ReceiverMaximumWaitTimeWhenIdle = "";
        internal static readonly string ReceiverMessageInvisibleTime = "";
        internal static readonly string ReceiverBatchSize = "";
        internal static readonly string MessageWrapperSerializer = "";
        internal static readonly string MessageWrapperSerializerFactory = "";
        internal static readonly string TransportCreateSendingQueues = "";
        internal static readonly string Sha1Shortener = "";

        static AzureStorageTransportExtensions()
        {
            // setup keys with their own names
            var keys = typeof(AzureStorageTransportExtensions)
                .GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(fi => fi.FieldType == typeof(string));

            foreach (var key in keys)
            {
                key.SetValue(null, "Transport.AzureStorageQueue." + key.Name);
            }
        }

        // ReSharper restore ConvertToConstant.Global
    }
}