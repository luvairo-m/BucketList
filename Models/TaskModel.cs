namespace BucketList.Models
{
    internal class TaskModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        internal TaskModel(string title, string description)
        {
            Title = title;
            Description = description;
        }   
    }
}