namespace ShopeeKorean.Shared.DataTransferObjects.User
{
    public record UserDto
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber {  get; set; }
        public string? ImageLink { get; set; } = "N/A";

    }
}
