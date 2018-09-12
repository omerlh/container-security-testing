using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenPositionsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<Dictionary<string, string>> Get()
        {
            return new Dictionary<string, string> { 
                { "Fullstack Developer", "http://jobs.soluto.com/apply/7oYgJDTwEI/Fullstack-Developer" },
                { "Product Manager", "http://jobs.soluto.com/apply/izeE6HhNuv/Senior-Product-Manager"},
                { "Designer", "http://jobs.soluto.com/apply/iPsb5tLZBm/Product-Designer"}
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        public ActionResult LogOn(string userName, string password, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (isValid(userName, password))
                {
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
        
            return BadRequest();
        }

        private bool isValid(string userName, string password) 
        {
            return true;
        }
    }
}
