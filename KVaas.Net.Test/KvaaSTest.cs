using System;
using Xunit;

namespace KVaas.Net.Test
{
    public class KvaaSTest
    {
        [Fact]
        public async void Test1()
        {
            string key = "testkey";
            string value = "testvalue";

            //get token
            var token = await KVaaSClient.NewKey(key);
            Assert.False(string.IsNullOrEmpty(token));

            // set value
            var setValueResult = await KVaaSClient.PutValue(token, key, value);
           
            // get value
            var getValueResult = await KVaaSClient.GetValue(token, key);
            Assert.False(string.IsNullOrEmpty(getValueResult));
            Assert.Equal(value, getValueResult);
        }
    }
}
