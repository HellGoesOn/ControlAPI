using ControlAPI.Models;
using ControlAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControlAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private IBaseRepository<Schedule> Schedules { get; set; }

        public MainController(IBaseRepository<Schedule> schedule)
        {
            Schedules = schedule;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Schedules.GetAll());
        }

        [HttpPost]
        public JsonResult Post()
        {
            return new JsonResult("Work was successfully done");
        }

        [HttpPut]
        public JsonResult Put(Schedule doc)
        {
            bool success = true;
            var schedule = Schedules.Get(doc.Id);
            try
            {
                if (schedule != null)
                {
                    schedule = Schedules.Update(doc);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult($"Update successful {schedule.Id}") : new JsonResult("Update was not successful");
        }

        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            bool success = true;
            var schedule = Schedules.Get(id);

            try
            {
                if (schedule != null)
                {
                    Schedules.Delete(schedule.Id);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult("Delete successful") : new JsonResult("Delete was not successful");
        }
    }
}
