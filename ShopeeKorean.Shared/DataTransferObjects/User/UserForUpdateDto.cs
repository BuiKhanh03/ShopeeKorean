namespace ShopeeKorean.Shared.DataTransferObjects.User
{
    public record UserForUpdateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
