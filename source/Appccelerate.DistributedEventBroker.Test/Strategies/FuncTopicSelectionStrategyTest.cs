//-------------------------------------------------------------------------------
// <copyright file="FuncTopicSelectionStrategyTest.cs" company="Appccelerate">
//   Copyright (c) 2008-2012
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Appccelerate.DistributedEventBroker.Strategies
{
    using System;

    using Appccelerate.EventBroker;

    using EventBroker.Internals;
    using Moq;
    using Xunit;

    public class FuncTopicSelectionStrategyTest
    {
        [Fact]
        public void SelectTopic_WhenFuncReturnsTrue_MustReturnTrue()
        {
            var testee = CreateTestee(topic => true);

            var result = testee.SelectTopic(new Mock<IEventTopicInfo>().Object);

            Assert.True(result);
        }

        [Fact]
        public void SelectTopic_WhenFuncReturnsFalse_MustReturnFalse()
        {
            var testee = CreateTestee(topic => false);

            var result = testee.SelectTopic(new Mock<IEventTopicInfo>().Object);

            Assert.False(result);
        }

        private static ITopicSelectionStrategy CreateTestee(Func<IEventTopicInfo, bool> strategy)
        {
            return new FuncTopicSelectionStrategy(strategy);
        }
    }
}