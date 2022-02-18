using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Constants;
using StudentManagement.Modules.Gifts.Requests;
using StudentManagement.Modules.Gifts.Services;
using StudentManagement.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Modules.Gifts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly GiftService _giftService;

        public GiftController(GiftService giftService)
        {
            _giftService = giftService;
        }
        [HttpGet]
        public IActionResult GetGiftItem(string giftCode)
        {
            GetGiftRequest giftType = _giftService.GetGift(giftCode);
            if (giftType is null) return BadRequest(new GenericResponse(null, ResponseConstant.NOT_FOUND));
            return Ok(new GenericResponse(giftType, ResponseConstant.SUCCESS_RESPONSE));
        }
    }
}
