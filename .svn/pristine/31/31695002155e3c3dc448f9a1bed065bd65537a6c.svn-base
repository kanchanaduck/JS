using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JKSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddDetailController : ControllerBase
    {
        private readonly DBContext context;
        public AddDetailController(DBContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Route("AddWorkcenterModel")]
        public async Task<ActionResult> AddWorkcenterModel([FromBody] T_WORK_CENTER_MODEL data)
        {
            var vaules = await context.T_WORK_CENTER_MODEL.FirstOrDefaultAsync(x => x.wc_code == data.wc_code && x.model_code == data.model_code);

            if (vaules == null)
            {
                data.statusactive = 1;
                data.update_by = data.update_by;
                data.update_date = DateTime.Now;

                context.Add(data);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                var vaules2 = context.T_WORK_CENTER_MODEL.FirstOrDefault(x => x.wc_code == data.wc_code && x.model_code == data.model_code);
                if (vaules2 == null)
                {
                    return BadRequest(data.wc_code + "/" + data.model_code + " ไม่สามารถเพิ่มข้อมูลได้");
                }
                else
                {
                    vaules2.statusactive = 1;
                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
        }

        [HttpPost]
        [Route("AddModelProcess")]
        public async Task<ActionResult> AddModelProcess([FromBody] T_MODEL_PROCESS data)
        {
            var vaules = await context.T_MODEL_PROCESS.FirstOrDefaultAsync(x => x.model_code == data.model_code && x.process_code == data.process_code);

            if (vaules == null)
            {
                data.statusactive = 1;
                data.update_by = data.update_by;
                data.update_date = DateTime.Now;

                context.Add(data);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                var vaules2 = context.T_MODEL_PROCESS.FirstOrDefault(x => x.model_code == data.model_code && x.process_code == data.process_code);
                if (vaules2 == null)
                {
                    return BadRequest(data.model_code + "/" + data.process_code + " ไม่สามารถเพิ่มข้อมูลได้");
                }
                else
                {
                    vaules2.statusactive = 1;
                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
        }

        [HttpPost]
        [Route("AddProcessCell")]
        public async Task<ActionResult> AddProcessCell([FromBody] T_PROCESS_CELL data)
        {
            var vaules = await context.T_PROCESS_CELL.FirstOrDefaultAsync(x => x.process_code == data.process_code && x.cell_code == data.cell_code);

            if (vaules == null)
            {
                data.statusactive = 1;
                data.update_by = data.update_by;
                data.update_date = DateTime.Now;

                context.Add(data);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                var vaules2 = context.T_PROCESS_CELL.FirstOrDefault(x => x.process_code == data.process_code && x.cell_code == data.cell_code);
                if (vaules2 == null)
                {
                    return BadRequest(data.process_code + "/" + data.cell_code + " ไม่สามารถเพิ่มข้อมูลได้");
                }
                else
                {
                    vaules2.statusactive = 1;
                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
        }

        [HttpPost]
        [Route("AddCellShift")]
        public async Task<ActionResult> AddCellShift([FromBody] T_CELL_SHIFT data)
        {
            var vaules = await context.T_CELL_SHIFT.FirstOrDefaultAsync(x => x.cell_code == data.cell_code && x.shift_code == data.shift_code);

            if (vaules == null)
            {
                data.statusactive = 1;
                data.update_by = data.update_by;
                data.update_date = DateTime.Now;

                context.Add(data);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                var vaules2 = context.T_CELL_SHIFT.FirstOrDefault(x => x.cell_code == data.cell_code && x.shift_code == data.shift_code);
                if (vaules2 == null)
                {
                    return BadRequest(data.cell_code + "/" + data.shift_code + " ไม่สามารถเพิ่มข้อมูลได้");
                }
                else
                {
                    vaules2.statusactive = 1;
                    await context.SaveChangesAsync();
                    return Ok();
                }
            }
        }


        [HttpPost]
        [Route("AddManpower")]
        public async Task<ActionResult> AddManpower([FromBody] T_MANPOWER data)
        {
            var vaules = await context.T_MANPOWER.FirstOrDefaultAsync(x => x.wc_code == data.wc_code 
            && x.model_code == data.model_code 
            && x.process_code == data.process_code 
            && x.cell_code == data.cell_code 
            && x.shift_code == data.shift_code);

            if (vaules == null)
            {
                data.update_date = DateTime.Now;
                context.Add(data);
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest(data.wc_code + "/" + data.model_code + "/" + data.process_code + "/" + data.cell_code + "/" + data.shift_code + " ไม่สามารถเพิ่มข้อมูลได้");
            }
        }

    }
}