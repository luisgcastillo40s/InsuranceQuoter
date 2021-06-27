﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace IdentityProvider
{
    using System.Collections.Generic;
    using IdentityServer4.Models;

    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource("country", new[] { "country" })
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource(
                    "insurancequoterpresentationapi",
                    "Insurance Quoter API",
                    new[] { "country" })
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "insurancequoter",
                    ClientName = "Insurance Quoter",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris = { "https://localhost:5001/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:5001/authentication/logout-callback" },
                    AllowedScopes = { "openid", "profile", "email", "insurancequoterpresentationapi" },
                    AllowedCorsOrigins = { "https://localhost:5001" }
                }
            };
    }
}