namespace Pastoralis.UseModels
{
    public class SlotModel
    {
        public int PastorId { get; set; }
        public int Duration { get; set; }
        public DateTime SlotDate { get; set; }  

        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }
        public bool isAvailable { get; set; }


        

    }
}
