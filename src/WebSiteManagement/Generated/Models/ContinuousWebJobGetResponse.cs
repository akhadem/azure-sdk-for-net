// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.WebSitesExtensions.Models;

namespace Microsoft.WindowsAzure.WebSitesExtensions.Models
{
    /// <summary>
    /// The get continuous WebJob Operation Response.
    /// </summary>
    public partial class ContinuousWebJobGetResponse : OperationResponse
    {
        private ContinuousWebJob _continuousWebJob;
        
        /// <summary>
        /// Optional. The continuous WebJob.
        /// </summary>
        public ContinuousWebJob ContinuousWebJob
        {
            get { return this._continuousWebJob; }
            set { this._continuousWebJob = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ContinuousWebJobGetResponse class.
        /// </summary>
        public ContinuousWebJobGetResponse()
        {
        }
    }
}