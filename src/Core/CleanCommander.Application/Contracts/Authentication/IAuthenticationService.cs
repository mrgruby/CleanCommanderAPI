using CleanCommander.Application.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Contracts.Authentication
{
    public interface IAuthenticationService
    {
        public AuthenticationResponse Authenticate(AuthenticationRequest request);
    }
}
