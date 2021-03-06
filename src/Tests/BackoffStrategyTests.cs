﻿namespace NServiceBus.AzureStorageQueues.Tests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using Transport.AzureStorageQueues;

    public class BackoffStrategyTests
    {
        static readonly TimeSpan peekInterval = TimeSpan.FromMilliseconds(50);
        static readonly TimeSpan maxWaitTime = TimeSpan.FromSeconds(30);

        [Test]
        public async Task WhenBatchesAreEmpty_ShouldIncreaseWaitTime()
        {
            var strategy = new BackoffStrategy(peekInterval, maxWaitTime);

            const int emptyBatchCount = 5;
            for (var i = 0; i < emptyBatchCount; i++)
            {
                await strategy.OnBatch(0, CancellationToken.None);
            }

            var lowerBoundary = (int)(peekInterval.TotalMilliseconds * (emptyBatchCount - 1));
            var delay = Task.Delay(lowerBoundary);
            Assert.AreSame(delay, await Task.WhenAny(strategy.OnBatch(0, CancellationToken.None), delay));
        }

        [Test]
        public async Task WhenBatchContainsAnyMessage_ShouldResetTime()
        {
            var strategy = new BackoffStrategy(peekInterval, maxWaitTime);

            const int emptyBatchCount = 5;
            for (var i = 0; i < emptyBatchCount; i++)
            {
                await strategy.OnBatch(0, CancellationToken.None);
            }

            var task = strategy.OnBatch(1, CancellationToken.None);

            Assert.True(task.IsCompleted);
        }
    }
}