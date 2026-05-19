using Microsoft.AspNetCore.Mvc;
using WorkoutTrackerAPI.Models;

namespace WorkoutTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutsController : ControllerBase
    {
        private static List<Workout> _workouts = new List<Workout>();
        private static int _nextId = 1;

        //GET api/workouts 
        [HttpGet]
        public ActionResult<List<Workout>> GetAll()
        {
            return Ok(_workouts);
        }
        //GET api/workouts/{id}
        [HttpGet("{id}")]
        public ActionResult<List<Workout>> GetById(int id)
        {
            var workout = _workouts.FirstOrDefault(w => w.Id == id);
            if (workout == null)
                return NotFound($"Workout with id{id} not found.");
            return Ok(workout);
        }
        //POST api/workouts
        [HttpPost]
        public ActionResult<Workout> Create(Workout workout)
        {
            workout.Id = _nextId++;
            workout.Date = DateTime.Now;
            _workouts.Add(workout);
            return CreatedAtAction(nameof(GetById), new { id = workout.Id }, workout);
        }
        //PUT api/workouts/{id}
        [HttpPut("{id}")]
        public ActionResult Update(int id, Workout updatedWorkout)
        {
            var workout = _workouts.FirstOrDefault(w => w.Id == id);
            if (workout == null)
                return NotFound($"Workout with id{id} not found.");
            workout.Exercise = updatedWorkout.Exercise;
            workout.Sets = updatedWorkout.Sets;
            workout.Reps = updatedWorkout.Reps;
            workout.WeightLbs = updatedWorkout.WeightLbs;

            return NoContent();

        }
        //DELETE api/workouts/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var workout = _workouts.FirstOrDefault(w => w.Id == id);
                if (workout == null)
                    return NotFound($"Workout with id{id} not found.");
            _workouts.Remove(workout);
            return NoContent();
        }
    }
   
}
