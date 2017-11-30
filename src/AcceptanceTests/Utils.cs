﻿namespace NServiceBus.Azure.Transports.WindowsAzureStorageQueues.AcceptanceTests
{
    using System;

    public static class Utils
    {
        public static string GetEnvConfiguredConnectionString()
        {
            return Environment.GetEnvironmentVariable("AzureStorageQueueTransport_ConnectionString");
        }

        public static string BuildAnotherConnectionString(string connectionString)
        {
            return connectionString + ";BlobEndpoint=https://notusedatall.blob.core.windows.net";
        }
    }
}