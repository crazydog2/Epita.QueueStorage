namespace Epita.QueueStorage.Model
{
    public class User : UserInformation
    {
        /// <summary>
        /// Non-Editable
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Non-Editable
        /// </summary>
        public string Email { get; set; }
    }
}