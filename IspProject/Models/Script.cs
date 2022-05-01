namespace IspProject.Models
{
    public class Script
    {
        public int idScript { get; set; }

        public string nameOfScript { get; set; }

        public string scriptFile { get; set; } // find the better option

        public DateTime createdAt { get; set; }

        public virtual ICollection<Script_AdditionalService> Script_AdditionalServices { get; set; }


    }
}
