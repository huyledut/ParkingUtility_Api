using System.Net;
using System.Security.Claims;
using DUTPS.API.Dtos.Profile;
using DUTPS.API.Services;
using DUTPS.Commons.Enums;
using DUTPS.Commons.Schemas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DUTPS.API.Controllers
{
  public class ProfileController : BaseController
  {
    private readonly IAuthenticationService _authenticationService;

    public ProfileController(IAuthenticationService authenticationService)
    {
      _authenticationService = authenticationService;
    }

    /// <summary>
    /// Get profile of user
    /// <para>Created at: 2022-11-15</para>
    /// <para>Created by: Quang TN</para>
    /// </summary>
    /// <returns>Data of user profile</returns>
    /// <remarks>
    /// Mean of response.Code
    /// 
    ///     200 - Success
    ///     201 - Error validate input data
    ///     500 - Server error
    ///
    /// </remarks>
    /// <response code="200">
    /// Success
    /// 
    ///     {
    ///         "Code": 200,
    ///         "MsgNo": "",
    ///         "ListError": null,
    ///         "Data": {
    ///             "Token": "Token",
    ///             "Username": "Username",
    ///         }
    ///     }
    ///     
    /// Validate Error
    /// 
    ///     {
    ///         "Code": 201
    ///         "MsgNo": "",
    ///         "ListError": {
    ///         },
    ///         "Data": null
    ///     }
    /// Exception
    /// 
    ///     {
    ///         "Code": 500,
    ///         "MsgNo": "E500",
    ///         "ListError": null,
    ///         "Data": {
    ///             "Error": "Message"
    ///         }
    ///     }
    ///     
    /// </response>
    /// <response code="200">Result after check data login</response>
    /// <response code="500">Have exception</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(ProfileDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetInfo()
    {
      var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
      try
      {
        ProfileDto profile = await _authenticationService.GetProfile(username);
        if (profile == null)
        {
          return NotFound();
        }
        return Ok(profile);
      }
      catch (Exception e)
      {
        return StatusCode(500, new { Error = e.Message });
      }
    }
  }
}