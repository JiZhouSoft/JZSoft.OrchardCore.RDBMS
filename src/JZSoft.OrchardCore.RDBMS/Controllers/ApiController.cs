using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrchardCore.Queries;

namespace OrchardCore.RelationDb.Controllers
{
    [Route("api/queries")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Api"), IgnoreAntiforgeryToken, AllowAnonymous]
    public class ApiController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public ApiController(
            IAuthorizationService authorizationService 
            )
        {
            _authorizationService = authorizationService;
        }
 
    }
}
