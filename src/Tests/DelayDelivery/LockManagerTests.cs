﻿namespace NServiceBus.Azure.Transports.WindowsAzureStorageQueues.AcceptanceTests.DelayDelivery
{
    using System;
    using System.Threading.Tasks;
    using WindowsAzureStorageQueues.DelayDelivery;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using NUnit.Framework;

    public class LockManagerTests
    {
        CloudBlobClient _blobs;

        [OneTimeSetUp]
        public void SetUp()
        {
            var client = CloudStorageAccount.Parse(Utils.GetEnvConfiguredConnectionString());
            _blobs = client.CreateCloudBlobClient();
        }

        [Test]
        public async Task WhenLeaseTaken_ThenItCanBeRenewedManyTimes()
        {
            var manager = GetLockManager("a156ef954f9594f51b24392d0df5e7771");

            const int manyTimes = 10;
            for (var i = 0; i < manyTimes; i++)
            {
                Assert.IsTrue(await manager.TryLockOrRenew().ConfigureAwait(false));
            }
        }

        [Test]
        public async Task WhenLeaseTaken_ThenNoOtherLeaseCanBeTaken()
        {
            const string id = "a99173943b8c74a00bff8fd1d850665fb";
            var manager1 = GetLockManager(id);
            var manager2 = GetLockManager(id);

            await manager1.TryLockOrRenew().ConfigureAwait(false);
            Assert.IsFalse(await manager2.TryLockOrRenew().ConfigureAwait(false));
        }

        [Test]
        public async Task WhenLeaseReleased_ThenAnotherCanBeTaken()
        {
            const string id = "a9a8ca20acb1f43b19415eba8997be991";
            var manager1 = GetLockManager(id);
            var manager2 = GetLockManager(id);

            await manager1.TryLockOrRenew().ConfigureAwait(false);
            await manager1.TryRelease().ConfigureAwait(false);
            Assert.IsTrue(await manager2.TryLockOrRenew().ConfigureAwait(false));
        }

        LockManager GetLockManager(string containerName)
        {
            var container = _blobs.GetContainerReference(containerName);
            var manager = new LockManager(container, TimeSpan.FromSeconds(20));
            return manager;
        }
    }
}