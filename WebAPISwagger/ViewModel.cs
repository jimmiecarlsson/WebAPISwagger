namespace WebAPISwagger
{
    public class ViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    // Add a list of objects to test the API


    // Testdata
    public static class ViewModelData
    {
        public static List<ViewModel> Items { get; } = new()
        {
            new ViewModel
            {
                Id = 1,
                Name = "Lamp",
                Description = "This lamp is the best"
            },
            new ViewModel
            {
                Id = 2,
                Name = "Phone",
                Description = "This phone was my grandfather's first phone."
            },
            new ViewModel
            {
                Id = 3,
                Name = "Desk",
                Description = "This desk is very sturdy."
            },
            new ViewModel
            {
                Id = 4,
                Name = "Chair",
                Description = "This chair is very comfortable."
            },
            new ViewModel
            {
                Id = 5,
                Name = "Monitor",
                Description = "This monitor has a great resolution."
            }
        };
    }
}
