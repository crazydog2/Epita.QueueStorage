namespace Epita.QueueStorage.Model
{
    public class Photo
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public string UserId { get; set; }
    }
}