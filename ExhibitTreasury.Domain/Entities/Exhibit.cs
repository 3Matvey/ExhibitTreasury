namespace ExhibitTreasury.Domain.Entities
{
    public class Exhibit : Entity
    {
        public required string Name { get; set; }
        public required decimal AppraisedValue { get; set; }
        public int YearCreated { get; set; }
        public string Material { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public int HallId { get; set; }
        public Hall Hall { get; set; } = default!;
    }
}
