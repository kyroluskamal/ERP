﻿using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ERP.Areas.Owners.CustomTokenProviders.EmailConfirmation
{
    public class CustomEmailConfirmationTokenProvider<TUser>
    : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public CustomEmailConfirmationTokenProvider(IDataProtectionProvider dataProtectionProvider,
                                        IOptions<CustomEmailConfirmationTokenProviderOptions> options,
                                        ILogger<CustomEmailConfirmationTokenProvider<TUser>> logger)
            : base(dataProtectionProvider, options, logger)
        { }
    }
}
