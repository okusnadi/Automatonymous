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
    public interface Activity :
        StateMachineNode
    {
    }


    public interface Activity<TInstance> :
        Activity
        where TInstance : StateMachineInstance
    {
        void Execute(TInstance instance);
    }


    public interface EventActivity<TInstance> :
        Activity<TInstance>
        where TInstance : StateMachineInstance
    {
        Event Event { get; }
    }


    public interface StateEventActivity<TInstance> :
        EventActivity<TInstance>
        where TInstance : StateMachineInstance
    {
        State State { get; }
    }
}