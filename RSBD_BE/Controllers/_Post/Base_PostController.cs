﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSBD_BE.Entities;
using RSBD_BE.Interfaces;
using RSBD_BE.Models;


namespace RSBD_BE.Controllers
{
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class Base_PostController : Controller
    {
        private readonly IBase_PostService _service;


        public Base_PostController(IBase_PostService service)
        {
            _service = service;
        }


        [HttpPost]
        public ActionResult<Post> InsertData([FromBody] CreatePostDTO dto)
        {
            var data = _service.InsertData(dto);
            return Created(data.Id.ToString(), data);
        }

        [HttpPatch]
        public ActionResult<Post> UpdateData([FromBody] UpdatePostDTO dto)
        {
            var data = _service.UpdateData(dto);
            return data;
        }

        [HttpDelete]
        public ActionResult<bool> DeleteData([FromBody] DeletePostDTO dto)
        {
            bool result = _service.DeleteData(dto);

            return result;
        }

        [HttpGet]
        public ActionResult<List<Post>> GetRegionAllData()
        {
            var data = _service.GetAllData();

            return data;
        }

        [HttpGet("{id}")]
        public ActionResult<Post> GetDataById([FromRoute] int id)
        {
            var data = _service.GetDataById(id);

            if (data == null)
                return NotFound();

            return data;
        }

        [HttpGet("status/primary")]
        public ActionResult<bool> IsServerPrimaryUp()
        {
            return _service.IsServerPrimaryUp();
        }

        [HttpGet("status/secondary")]
        public ActionResult<bool> IsServerSecondaryUp()
        {
            return _service.IsServerSecondaryUp();
        }
    }
}
