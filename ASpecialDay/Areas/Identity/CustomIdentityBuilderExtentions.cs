using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASpecialDay.Areas.Identity
{
    public static class CustomIdentityBuilderExtentions
    {
        public static IdentityBuilder AddInviteTokenProvider(this IdentityBuilder builder)
        {
            var userType = builder.UserType;
            var inviteTokenProvider = typeof(InviteTokenProvider<>).MakeGenericType(userType);
            return builder.AddTokenProvider("InviteCodeTokenProvider", inviteTokenProvider);
        }
    }
}
