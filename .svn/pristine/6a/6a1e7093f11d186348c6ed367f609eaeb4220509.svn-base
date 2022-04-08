using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace JKSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteMasterController : ControllerBase
    {
        private readonly DBContext context;
        public DeleteMasterController(DBContext context)
        {
            this.context = context;
        }

        [HttpDelete]
        [Route("DeleteCellName/{id}")]
        public async Task<IActionResult> DeleteCellName(string id)
        {
            try
            {
                var vaules = context.M_CELL.FirstOrDefault(x => x.cell_code == id);
                vaules.statusactive = 0;
                vaules.update_date = DateTime.Now;

                var v_detail = context.T_CELL_SHIFT.FirstOrDefault(x => x.cell_code == id);
                if (v_detail != null)
                {
                    v_detail.statusactive = 0;
                    v_detail.update_date = DateTime.Now;
                }

                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteProductModel/{id}")]
        public async Task<IActionResult> DeleteProductModel(string id)
        {
            try
            {
                var vaules = context.M_MODEL.FirstOrDefault(x => x.model_code == id);
                vaules.statusactive = 0;
                vaules.update_date = DateTime.Now;

                var v_detail = context.T_MODEL_PROCESS.FirstOrDefault(x => x.model_code == id);
                if (v_detail != null)
                {
                    v_detail.statusactive = 0;
                    v_detail.update_date = DateTime.Now;
                }

                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteProcessName/{id}")]
        public async Task<IActionResult> DeleteProcessName(string id)
        {
            try
            {
                var vaules = context.M_PROCESS.FirstOrDefault(x => x.process_code == id);
                vaules.statusactive = 0;
                vaules.update_date = DateTime.Now;

                var v_detail = context.T_PROCESS_CELL.FirstOrDefault(x => x.process_code == id);
                if (v_detail != null)
                {
                    v_detail.statusactive = 0;
                    v_detail.update_date = DateTime.Now;
                }

                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteBlockShift/{id}")]
        public async Task<IActionResult> DeleteBlockShift(string id)
        {
            try
            {
                var vaules = context.M_BLOCK_SHIFT.FirstOrDefault(x => x.shift_code == id);
                vaules.statusactive = 0;
                vaules.update_date = DateTime.Now;
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteWorkCenter/{id}")]
        public async Task<IActionResult> DeleteWorkCenter(string id)
        {
            try
            {
                var vaules = context.M_WORK_CENTER.FirstOrDefault(x => x.wc_code == id);
                vaules.statusactive = 0;
                vaules.update_date = DateTime.Now;

                var v_detail = context.T_WORK_CENTER_MODEL.FirstOrDefault(x => x.wc_code == id);
                if (v_detail != null)
                {
                    v_detail.statusactive = 0;
                    v_detail.update_date = DateTime.Now;
                }

                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteBlockGroup/{id}")]
        public async Task<IActionResult> DeleteBlockGroup(string id)
        {
            try
            {
                var vaules = context.M_BLOCK_GROUP.FirstOrDefault(x => x.block_group_code == id);
                vaules.statusactive = 0;
                vaules.update_date = DateTime.Now;
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteGbCellCode/{id}")]
        public async Task<IActionResult> DeleteGbCellCode(string id)
        {
            try
            {
                var vaules = context.M_GB_CELL_CODE.FirstOrDefault(x => x.gb_cell_code == id);
                vaules.statusactive = 0;
                vaules.update_date = DateTime.Now;
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("DeleteTss/{id}")]
        public async Task<IActionResult> DeleteTss(string id)
        {
            try
            {
                var vaules = context.M_TSS.FirstOrDefault(x => x.tss_code == id);
                vaules.statusactive = 0;
                vaules.update_date = DateTime.Now;
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

    }
}