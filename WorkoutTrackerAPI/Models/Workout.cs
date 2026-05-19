namespace WorkoutTrackerAPI.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Exercise { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double WeightLbs { get; set; }
        public DateTime Date { get; set; }
    }
}