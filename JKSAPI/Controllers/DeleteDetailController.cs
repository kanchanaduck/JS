using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace JKSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteDetailController : ControllerBase
    {
        private readonly DBContext context;
        public DeleteDetailController(DBContext context)
        {
            this.context = context;
        }

        [HttpDelete]
        [Route("DeleteWorkcenterModel/{id}")]
        public async Task<IActionResult> DeleteWorkcenterModel(int id)
        {
            try
            {
                var vaules = context.T_WORK_CENTER_MODEL.FirstOrDefault(x => x.id == id);
                vaules.statusactive = 0;
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteModelProcess/{id}")]
        public async Task<IActionResult> DeleteModelProcess(int id)
        {
            try
            {
                var vaules = context.T_MODEL_PROCESS.FirstOrDefault(x => x.id == id);
                vaules.statusactive = 0;
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteProcessCell/{id}")]
        public async Task<IActionResult> DeleteProcessCell(int id)
        {
            try
            {
                var vaules = context.T_PROCESS_CELL.FirstOrDefault(x => x.id == id);
                vaules.statusactive = 0;
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteCellShift/{id}")]
        public async Task<IActionResult> DeleteCellShift(int id)
        {
            try
            {
                var vaules = context.T_CELL_SHIFT.FirstOrDefault(x => x.id == id);
                vaules.statusactive = 0;
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteManpower/{id}")]
        public async Task<IActionResult> DeleteManpower(int id)
        {
            context.T_MANPOWER.Remove(context.T_MANPOWER.FirstOrDefault(e => e.id == id));
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}