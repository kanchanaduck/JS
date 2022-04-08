using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace JKSAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterController : ControllerBase
    {
        private readonly DBContext context;
        public MasterController(DBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("CellName")]
        public async Task<ActionResult> CellName()
        {
            var result = await (from e in context.M_CELL where e.statusactive == 1
                                select new
                                {
                                    cell_code = e.cell_code,
                                    cell_detail = e.cell_detail
                                }).OrderBy(x => x.cell_detail).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("ProductModel")]
        public async Task<ActionResult> ProductModel()
        {
            var result = await (from e in context.M_MODEL where e.statusactive == 1
                                select new
                                {
                                    model_code = e.model_code,
                                    model_detail = e.model_detail,
                                    model_child = e.model_child
                                }).OrderBy(x => x.model_detail).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("ProcessName")]
        public async Task<ActionResult> ProcessName()
        {
            var result = await (from e in context.M_PROCESS where e.statusactive == 1
                                select new
                                {
                                    process_code = e.process_code,
                                    process_detail = e.process_detail
                                }).OrderBy(x => x.process_detail).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("BlockShift")]
        public async Task<ActionResult> BlockShift()
        {
            var result = await (from e in context.M_BLOCK_SHIFT where e.statusactive == 1
                                select new
                                {
                                    shift_code = e.shift_code,
                                    shift_detail = e.shift_detail
                                }).OrderBy(x => x.shift_detail).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("WorkCenter")]
        public async Task<ActionResult> WorkCenter()
        {
            var result = await (from e in context.M_WORK_CENTER where e.statusactive == 1
                                select new
                                {
                                    wc_code = e.wc_code,
                                    wc_detail = e.wc_detail
                                }).OrderBy(x => x.wc_detail).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("BlockGroup")]
        public async Task<ActionResult> BLOCK_GROUP()
        {
            var result = await (from e in context.M_BLOCK_GROUP where e.statusactive == 1
                                select new
                                {
                                    block_group_code = e.block_group_code,
                                    block_group_detail = e.block_group_detail
                                }).OrderBy(x => x.block_group_code).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GbCellCode")]
        public async Task<ActionResult> GB_CELL_CODE()
        {
            var result = await (from e in context.M_GB_CELL_CODE where e.statusactive == 1
                                select new
                                {
                                    gb_cell_code = e.gb_cell_code,
                                    gb_cell_detail = e.gb_cell_detail
                                }).OrderBy(x => x.gb_cell_code).ToListAsync();
            return Ok(result);
        }
        
        [HttpGet]
        [Route("Tss")]
        public async Task<ActionResult> TSS()
        {
            var result = await (from e in context.M_TSS where e.statusactive == 1
                                select new
                                {
                                    tss_code = e.tss_code,
                                    tss_detail = e.tss_detail,
                                    cal_qty = e.cal_qty,
                                    cal_extrawork = e.cal_extrawork,
                                    cal_jobspecial = e.cal_jobspecial
                                }).OrderBy(x => x.tss_code).ToListAsync();
            return Ok(result);
        }

    }
}