//-------------------------------------------------------------------------------
// <copyright file="DataContractEventArgsSerializerTest.cs" company="Appccelerate">
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

namespace Appccelerate.DistributedEventBroker.Serializer
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;

    using Xunit;

    public class DataContractEventArgsSerializerTest
    {
        private readonly CustomEventArgs eventArgsToSerialize;

        private readonly string inputAndOutput;

        private readonly DataContractEventArgsSerializer testee;

        public DataContractEventArgsSerializerTest()
        {
            this.eventArgsToSerialize = new CustomEventArgs(true);

            using (MemoryStream ms = new MemoryStream())
            {
                var serializer = new DataContractSerializer(typeof(CustomEventArgs));
                serializer.WriteObject(ms, this.eventArgsToSerialize);
                this.inputAndOutput = Convert.ToBase64String(ms.ToArray());
            }

            this.testee = new DataContractEventArgsSerializer();
        }

        [Fact]
        public void Serialize_MustSerializeEventArgsToString()
        {
            var result = this.testee.Serialize(this.eventArgsToSerialize);

            Assert.Equal(this.inputAndOutput, result);
        }

        [Fact]
        public void Deserialize_MustDeserializeEventArgsFromString()
        {
            var result = this.testee.Deserialize(typeof(CustomEventArgs), this.inputAndOutput);

            Assert.IsType<CustomEventArgs>(result);
            Assert.True(((CustomEventArgs)result).Cancel);
        }

        [DataContract]
        private class CustomEventArgs : EventArgs
        {
            public CustomEventArgs(bool cancel)
            {
                this.Cancel = cancel;
            }

            [DataMember]
            public bool Cancel
            {
                get;
                private set;
            }
        }
    }
}