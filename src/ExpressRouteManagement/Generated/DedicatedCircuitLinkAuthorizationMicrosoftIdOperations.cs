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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.ExpressRoute;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;

namespace Microsoft.WindowsAzure.Management.ExpressRoute
{
    internal partial class DedicatedCircuitLinkAuthorizationMicrosoftIdOperations : IServiceOperations<ExpressRouteManagementClient>, IDedicatedCircuitLinkAuthorizationMicrosoftIdOperations
    {
        /// <summary>
        /// Initializes a new instance of the
        /// DedicatedCircuitLinkAuthorizationMicrosoftIdOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal DedicatedCircuitLinkAuthorizationMicrosoftIdOperations(ExpressRouteManagementClient client)
        {
            this._client = client;
        }
        
        private ExpressRouteManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.WindowsAzure.Management.ExpressRoute.ExpressRouteManagementClient.
        /// </summary>
        public ExpressRouteManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Adds Microsoft Ids to the specified authorization
        /// </summary>
        /// <param name='serviceKey'>
        /// Required. The service key representing the circuit.
        /// </param>
        /// <param name='authId'>
        /// Required. The GUID representing the authorization
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters supplied to add new Microsoft Ids
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async Task<AzureOperationResponse> NewAsync(string serviceKey, string authId, DedicatedCircuitLinkAuthorizationMicrosoftIdNewParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (serviceKey == null)
            {
                throw new ArgumentNullException("serviceKey");
            }
            if (authId == null)
            {
                throw new ArgumentNullException("authId");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceKey", serviceKey);
                tracingParameters.Add("authId", authId);
                tracingParameters.Add("parameters", parameters);
                TracingAdapter.Enter(invocationId, this, "NewAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "/" + (this.Client.Credentials.SubscriptionId == null ? "" : Uri.EscapeDataString(this.Client.Credentials.SubscriptionId)) + "/services/networking/dedicatedcircuits/" + Uri.EscapeDataString(serviceKey) + "/authorizations/" + Uri.EscapeDataString(authId) + "/microsoftids?api-version=1.0";
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Post;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2011-10-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Serialize Request
                string requestContent = null;
                XDocument requestDoc = new XDocument();
                
                XElement dedicatedCircuitLinkAuthorizationMicrosoftIdsElement = new XElement(XName.Get("DedicatedCircuitLinkAuthorizationMicrosoftIds", "http://schemas.microsoft.com/windowsazure"));
                requestDoc.Add(dedicatedCircuitLinkAuthorizationMicrosoftIdsElement);
                
                if (parameters.MicrosoftIds != null)
                {
                    XElement microsoftIdsElement = new XElement(XName.Get("MicrosoftIds", "http://schemas.microsoft.com/windowsazure"));
                    microsoftIdsElement.Value = parameters.MicrosoftIds;
                    dedicatedCircuitLinkAuthorizationMicrosoftIdsElement.Add(microsoftIdsElement);
                }
                
                requestContent = requestDoc.ToString();
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/xml");
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, requestContent, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    AzureOperationResponse result = null;
                    // Deserialize Response
                    result = new AzureOperationResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Removes Microsoft Ids from the specified authorization
        /// </summary>
        /// <param name='serviceKey'>
        /// Required. The service key representing the circuit.
        /// </param>
        /// <param name='authId'>
        /// Required. The GUID representing the authorization
        /// </param>
        /// <param name='parameters'>
        /// Required. Parameters supplied to remove existing Microsoft Ids
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async Task<AzureOperationResponse> RemoveAsync(string serviceKey, string authId, DedicatedCircuitLinkAuthorizationMicrosoftIdRemoveParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (serviceKey == null)
            {
                throw new ArgumentNullException("serviceKey");
            }
            if (authId == null)
            {
                throw new ArgumentNullException("authId");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceKey", serviceKey);
                tracingParameters.Add("authId", authId);
                tracingParameters.Add("parameters", parameters);
                TracingAdapter.Enter(invocationId, this, "RemoveAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "/" + (this.Client.Credentials.SubscriptionId == null ? "" : Uri.EscapeDataString(this.Client.Credentials.SubscriptionId)) + "/services/networking/dedicatedcircuits/" + Uri.EscapeDataString(serviceKey) + "/authorizations/" + Uri.EscapeDataString(authId) + "/microsoftids?api-version=1.0";
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Delete;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2011-10-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Serialize Request
                string requestContent = null;
                XDocument requestDoc = new XDocument();
                
                XElement dedicatedCircuitLinkAuthorizationMicrosoftIdsElement = new XElement(XName.Get("DedicatedCircuitLinkAuthorizationMicrosoftIds", "http://schemas.microsoft.com/windowsazure"));
                requestDoc.Add(dedicatedCircuitLinkAuthorizationMicrosoftIdsElement);
                
                if (parameters.MicrosoftIds != null)
                {
                    XElement microsoftIdsElement = new XElement(XName.Get("MicrosoftIds", "http://schemas.microsoft.com/windowsazure"));
                    microsoftIdsElement.Value = parameters.MicrosoftIds;
                    dedicatedCircuitLinkAuthorizationMicrosoftIdsElement.Add(microsoftIdsElement);
                }
                
                requestContent = requestDoc.ToString();
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/xml");
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, requestContent, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    AzureOperationResponse result = null;
                    // Deserialize Response
                    result = new AzureOperationResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}