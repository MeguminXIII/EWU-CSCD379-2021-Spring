namespace SecretSanta.Api.Dto
{
    public class DtoUser{
        public string? FirstName {get; set;}
        public string? LastName {get; set;}
        public int? Id {get; set;}
        public string? FullName {get => $"{FirstName} {LastName}"; }
    }
}