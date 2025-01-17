﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;

namespace CromwellOnAzureDeployer
{
    public static class AzureFluentExtensions
    {
        public static CloudError ToCloudError(this CloudException cloudException)
        {
            return (JsonConvert.DeserializeObject<CloudErrorWrapper>(cloudException.Response.Content)).Error;
        }

        public static CloudErrorType ToCloudErrorType(this CloudException cloudException)
        {
            Enum.TryParse(cloudException.ToCloudError().Code, out CloudErrorType cloudErrorType);
            return cloudErrorType;
        }
    }
    public class CloudErrorWrapper
    {
        public CloudError Error { get; set; }
    }
    public enum CloudErrorType
    {
        NotSet, ExpiredAuthenticationToken
    }
}
