using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JKSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DBContext context;
        public AccountController(DBContext context)
        {
            this.context = context;
        }

        [HttpGet("Getdata")]
        public async Task<IActionResult> Get()
        {
            var result = await context.T_LOGIN.AsNoTracking().OrderBy(x => x.fname).ToListAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get data userid and password.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Account/Getuserid
        ///     {
        ///        "userid": "string",
        ///        "password": "string"
        ///     }
        ///
        /// </remarks>
        [HttpPost("Getuserid")]
        public async Task<IActionResult> Getuserid(TB_Login data)
        {
            var result = await context.T_LOGIN.Where(e => e.userid == data.userid && e.password == data.password && e.statusactive == 1).FirstOrDefaultAsync();
            if (result == null)
            {
                return BadRequest("*** Invalid username or password Please try again");
            }
            else
            {
                return Ok(result);
            }
        }

        /// <summary>
        /// Add data.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Account/AddData
        ///     {
        ///        "userid": "string",
        ///        "fname": "string",
        ///        "lname": "string",
        ///        "password": "string",
        ///        "userright": "string",
        ///        "statusactive": 0
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Route("AddData")]
        public async Task<IActionResult> AddData([FromBody] TB_Login data)
        {
            var vaules = await context.T_LOGIN.FirstOrDefaultAsync(x => x.userid == data.userid);
            if (vaules == null)
            {
                data.createddate = DateTime.Now;
                context.Add(data);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest(data.userid + " มีข้อมูลอยู่ในระบบแล้ว");
            }
        }

        /// <summary>
        /// Update Data.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Account/UpdateData/{id}
        ///     {
        ///        "userid": "string",
        ///        "fname": "string",
        ///        "lname": "string",
        ///        "password": "string",
        ///        "userright": "string",
        ///        "statusactive": 0
        ///     }
        ///
        /// </remarks>
        [HttpPut]
        [Route("UpdateData/{id}")]
        public async Task<IActionResult> UpdateData(int id, TB_Login data)
        {
            var v = await context.T_LOGIN.Where(x => x.id == data.id).FirstOrDefaultAsync();
            if (v == null)
            {
                var vaules = context.T_LOGIN.FirstOrDefault(x => x.id == id);
                vaules.fname = data.fname;
                vaules.lname = data.lname;
                vaules.userid = data.userid;
                vaules.password = data.password;
                vaules.userright = data.userright;
                vaules.statusactive = data.statusactive;

                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest(data.userid + " ไม่สามารถแก้ไขข้อมูลได้");
            }
        }

        [HttpDelete]
        [Route("DeleteData/{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            context.T_LOGIN.Remove(context.T_LOGIN.FirstOrDefault(e => e.id == id));
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}