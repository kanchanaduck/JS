using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace JKSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditMasterController : ControllerBase
    {
        private readonly DBContext context;
        public EditMasterController(DBContext context)
        {
            this.context = context;
        }

        [HttpPut]
        [Route("UpdateCellName/{id}")]
        public async Task<IActionResult> UpdateCellName(string id, TB_DATA_CELL data)
        {
            var vaules =  await context.M_CELL.FirstOrDefaultAsync(x => x.cell_code == data.cell_code 
            && x.cell_detail == data.cell_detail);
            if(vaules == null)
            {
                var vaules_add = context.M_CELL.FirstOrDefault(x => x.cell_code == id);
                vaules_add.cell_detail = data.cell_detail;
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
        [Route("UpdateProductModel/{id}")]
        public async Task<IActionResult> UpdateProductModel(string id, TB_DATA_MODEL data)
        {
            var vaules =  await context.M_MODEL.FirstOrDefaultAsync(x => x.model_code == data.model_code 
            && x.model_detail == data.model_detail 
            && x.model_child == data.model_child);

            if(vaules == null)
            {
                // Console.WriteLine(data.model_child.ToString());
                var vaules_add = context.M_MODEL.FirstOrDefault(x => x.model_code == id);
                vaules_add.model_detail = data.model_detail;
                vaules_add.model_child = data.model_child;
                vaules_add.update_by = data.update_by;
                vaules_add.update_date = DateTime.Now;
                await context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                Console.WriteLine("else");
                return Ok();
            }
            
        }

        [HttpPut]
        [Route("UpdateProcessName/{id}")]
        public async Task<IActionResult> UpdateProcessName(string id, TB_DATA_PROCESS data)
        {
            var vaules =  await context.M_PROCESS.FirstOrDefaultAsync(x => x.process_code == data.process_code 
            && x.process_detail == data.process_detail);

            if(vaules == null)
            {
                var vaules_add = context.M_PROCESS.FirstOrDefault(x => x.process_code == id);
                vaules_add.process_detail = data.process_detail;
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
        [Route("UpdateBlockShift/{id}")]
        public async Task<IActionResult> UpdateBlockShift(string id, TB_DATA_SHIFT data)
        {
            var vaules =  await context.M_BLOCK_SHIFT.FirstOrDefaultAsync(x => x.shift_code == data.shift_code
            && x.shift_detail == data.shift_detail);

            if(vaules == null)
            {
                var vaules_add = context.M_BLOCK_SHIFT.FirstOrDefault(x => x.shift_code == id);
                vaules_add.shift_detail = data.shift_detail;
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
        [Route("UpdateWorkCenter/{id}")]
        public async Task<IActionResult> UpdateWorkCenter(string id, TB_DATA_WC data)
        {
            var vaules =  await context.M_WORK_CENTER.FirstOrDefaultAsync(x => x.wc_code == data.wc_code
            && x.wc_detail == data.wc_detail);

            if(vaules == null)
            {
                var vaules_add = context.M_WORK_CENTER.FirstOrDefault(x => x.wc_code == id);
                vaules_add.wc_detail = data.wc_detail;
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
        [Route("UpdateBlockGroup/{id}")]
        public async Task<IActionResult> UpdateBlockGroup(string id, TB_DATA_BLOCK_GROUP data)
        {
            var vaules =  await context.M_BLOCK_GROUP.FirstOrDefaultAsync(x => x.block_group_code == data.block_group_code
            && x.block_group_detail == data.block_group_detail);

            if(vaules == null)
            {
                var vaules_add = context.M_BLOCK_GROUP.FirstOrDefault(x => x.block_group_code == id);
                vaules_add.block_group_detail = data.block_group_detail;
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
        [Route("UpdateGbCellCode/{id}")]
        public async Task<IActionResult> UpdateGbCellCode(string id, TB_DATA_GB_CELL data)
        {
            var vaules =  await context.M_GB_CELL_CODE.FirstOrDefaultAsync(x => x.gb_cell_code == data.gb_cell_code 
            && x.gb_cell_detail == data.gb_cell_detail);
            if(vaules == null)
            {
                var vaules_add = context.M_GB_CELL_CODE.FirstOrDefault(x => x.gb_cell_code == id);
                vaules_add.gb_cell_detail = data.gb_cell_detail;
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
        [Route("UpdateTss/{id}")]
        public async Task<IActionResult> UpdateTss(string id, TB_DATA_TSS data)
        {
            var vaules =  await context.M_TSS.FirstOrDefaultAsync(x => x.tss_code == data.tss_code
            && x.tss_detail == data.tss_detail && x.cal_qty == data.cal_qty 
            && x.cal_extrawork == data.cal_extrawork && x.cal_jobspecial == data.cal_jobspecial);
            // Console.WriteLine(data.cal_extrawork);
            // Console.WriteLine(data.cal_jobspecial);

            if(vaules == null)
            {
                var vaules_add = context.M_TSS.FirstOrDefault(x => x.tss_code == id);
                vaules_add.tss_detail = data.tss_detail;
                vaules_add.cal_qty = data.cal_qty;
                vaules_add.cal_extrawork = data.cal_extrawork;
                vaules_add.cal_jobspecial = data.cal_jobspecial;
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
    }
}