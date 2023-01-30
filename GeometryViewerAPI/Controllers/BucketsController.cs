using GeometryViewerAPI.DB;
using GeometryViewerAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeometryViewerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BucketsController : ControllerBase
    {
        DataContext _dbcontext;

        public BucketsController(DataContext dataContext)
        {
            _dbcontext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<int>>> GetAllBuckets()
        {
            return Ok(await _dbcontext.Buckets.Select(b => b.Id).ToListAsync());
        }

        [HttpGet("GetLastBucket")]
        public async Task<ActionResult<Bucket>> GetLastBucket()
        {
            Bucket? bucket = await _dbcontext.Buckets.OrderByDescending(b => b.Name).FirstOrDefaultAsync();
            if (bucket is null)
            {
                return BadRequest("No buckets");
            }
            else
            {
                return Ok(bucket);
            }
        }

        [HttpGet("GetLastBucketId")]
        public async Task<ActionResult<int>> GetLastBucketId()
        {
            int? id = await _dbcontext.Buckets.OrderByDescending(b => b.Name).Select(b => (int?)b.Id).FirstOrDefaultAsync();
            return Ok(id);
            //if (bucket is null)
            //{
            //    return BadRequest("Bucket with this id not found");
            //}
            //else
            //{
            //    return Ok(bucket);
            //}
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAllBuckets()
        {
            await _dbcontext.Buckets.ExecuteDeleteAsync();
            return Ok(await _dbcontext.SaveChangesAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddBucket(Bucket bucket)
        {
            _dbcontext.Buckets.Add(bucket);
            return Ok(await _dbcontext.SaveChangesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bucket>> GetBucket(int id)
        {
            Bucket? bucket = await _dbcontext.Buckets.FindAsync(id);
            if (bucket is null)
            {
                return BadRequest("Bucket with this id not found");
            }
            else
            {
                return Ok(bucket);
            }
        }

        [HttpGet("test")]
        public async Task<ActionResult<string>> Test()
        {
            return await Task.Run(() => { return Ok("Hello"); });
        }
    }
}
