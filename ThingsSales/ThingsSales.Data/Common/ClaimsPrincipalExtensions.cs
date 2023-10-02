﻿using System.Security.Claims;
using ThingsSales.Data.Common.Exceptions;

namespace ThingsSales.Data.Common
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetCurrentUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }
            var result = Guid.TryParse(
                principal.Claims
                    .FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier
                )?.Value, out var userId);
            if (!result)
            {
                throw new UserAccessDeniedExceptions(principal.ToString());
            }
            return userId;
        }
    }
}
