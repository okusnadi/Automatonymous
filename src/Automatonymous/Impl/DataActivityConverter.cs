// Copyright 2011 Chris Patterson, Dru Sellers
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Automatonymous.Impl
{
    using System;


    public class DataActivityConverter<TInstance, TData> :
        Activity<TInstance>
        where TInstance : StateMachineInstance
        where TData : class
    {
        readonly Activity<TInstance, TData> _activity;

        public DataActivityConverter(Activity<TInstance, TData> activity)
        {
            _activity = activity;
        }

        public void Execute(TInstance instance, object value)
        {
            if (value == null)
                throw new ArgumentNullException("value", "The data argument cannot be null");

            var data = value as TData;
            if (data == null)
            {
                string message = "Expected: " + typeof(TData).Name + ", Received: " + value.GetType().Name;
                throw new ArgumentException(message, "value");
            }

            _activity.Execute(instance, data);
        }

        public void Inspect(StateMachineInspector inspector)
        {
            inspector.Inspect(this, x => { });
        }
    }
}