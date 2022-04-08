using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace JKSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditDetailController : ControllerBase
    {
        private readonly DBContext context;
        public EditDetailController(DBContext context)
        {
            this.context = context;
        }

        [HttpPut]
        [Route("UpdateWorkcenterModel/{id}")]
        public async Task<IActionResult> UpdateWorkcenterModel(int id, T_WORK_CENTER_MODEL data)
        {
            var vaules =  await context.T_WORK_CENTER_MODEL.FirstOrDefaultAsync
            (x => x.wc_code == data.wc_code && x.model_code == data.model_code);

            if(vaules == null)
            {
                var vaules_add = context.T_WORK_CENTER_MODEL.FirstOrDefault(x => x.id == id);
                vaules_add.wc_code = data.wc_code;
                vaules_add.model_code = data.model_code;
                vaules_add.update_by = data.update_by;
                vaules_add.update_date = DateTime.Now;
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return Ok();
            }
            
        }

        [HttpPut]
        [Route("UpdateModelProcess/{id}")]
        public async Task<IActionResult> UpdateModelProcess(int id, T_MODEL_PROCESS data)
        {
            var vaules =  await context.T_MODEL_PROCESS.FirstOrDefaultAsync
            (x => x.model_code == data.model_code && x.process_code == data.process_code);

            if(vaules == null)
            {
                var vaules_add = context.T_MODEL_PROCESS.FirstOrDefault(x => x.id == id);
                vaules_add.model_code = data.model_code;
                vaules_add.process_code = data.process_code;
                vaules_add.update_by = data.update_by;
                vaules_add.update_date = DateTime.Now;
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return Ok();
            }
            
        }

        [HttpPut]
        [Route("UpdateProcessCell/{id}")]
        public async Task<IActionResult> UpdateProcessCell(int id, T_PROCESS_CELL data)
        {
            var vaules =  await context.T_PROCESS_CELL.FirstOrDefaultAsync
            (x => x.process_code == data.process_code && x.cell_code == data.cell_code);

            if(vaules == null)
            {
                var vaules_add = context.T_PROCESS_CELL.FirstOrDefault(x => x.id == id);
                vaules_add.process_code = data.process_code;
                vaules_add.cell_code = data.cell_code;
                vaules_add.update_by = data.update_by;
                vaules_add.update_date = DateTime.Now;
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return Ok();
            }
            
        }

        [HttpPut]
        [Route("UpdateCellShift/{id}")]
        public async Task<IActionResult> UpdateCellShift(int id, T_CELL_SHIFT data)
        {
            var vaules =  await context.T_CELL_SHIFT.FirstOrDefaultAsync
            (x => x.cell_code == data.cell_code && x.shift_code == data.shift_code);

            if(vaules == null)
            {
                var vaules_add = context.T_CELL_SHIFT.FirstOrDefault(x => x.id == id);
                vaules_add.cell_code = data.cell_code;
                vaules_add.shift_code = data.shift_code;
                vaules_add.update_by = data.update_by;
                vaules_add.update_date = DateTime.Now;
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return Ok();
            }
            
        }
        
        [HttpPut]
        [Route("UpdateManpower/{id}")]
        public async Task<IActionResult> UpdateManpower(int id, T_MANPOWER data)
        {
            var vaules =  await context.T_MANPOWER.FirstOrDefaultAsync
            (x => x.wc_code == data.wc_code 
            && x.model_code == data.model_code 
            && x.process_code == data.process_code 
            && x.cell_code == data.cell_code 
            && x.shift_code == data.shift_code 
            && x.id != id);

            if(vaules == null)
            {
                var vaules_add = context.T_MANPOWER.FirstOrDefault
                (x => x.id == id);
                
                vaules_add.wc_code = data.wc_code;
                vaules_add.model_code = data.model_code;
                vaules_add.process_code = data.process_code;
                vaules_add.cell_code = data.cell_code;
                vaules_add.category = data.category;
                vaules_add.shift_code = data.shift_code;
                vaules_add.manpower = data.manpower;
                vaules_add.op_meister = data.op_meister;
                vaules_add.sp_meister = data.sp_meister;
vaules_add.block_group_code= data.block_group_code;
vaules_add.gb_cell_code= data.gb_cell_code;

                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest("ไม่สามารถแก้ไขข้อมูลได้");
            }
            
        }

    }
}