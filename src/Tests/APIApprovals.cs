﻿namespace NServiceBus.Azure.WindowsAzureServiceBus.Tests.API
{
    using NUnit.Framework;
    using Particular.Approvals;
    using PublicApiGenerator;

    [TestFixture]
    public class APIApprovals
    {
        [Test]
        public void ApproveAzureStorageQueueTransport()
        {
            var publicApi = ApiGenerator.GeneratePublicApi(typeof(AzureStorageQueueTransport).Assembly, excludeAttributes: new[] { "System.Runtime.Versioning.TargetFrameworkAttribute" });
            Approver.Verify(publicApi);
        }
    }
}
