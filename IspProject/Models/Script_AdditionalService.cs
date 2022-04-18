namespace IspProject.Models
{
    public class Script_AdditionalService
    {

        public int idScript { get; set; }

        public int idAdditionalService { get; set; }

        public Script script { get; set; }

        public AdditionalService additionalService;
    }
}