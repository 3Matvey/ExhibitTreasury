
namespace ExhibitTreasury.Domain.Entities
{
    public class Hall : Entity
    {
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<Exhibit> Exhibits { get; set; } = [];

        public void AddExhibit(Exhibit exhibit)
        {
            ArgumentNullException.ThrowIfNull(exhibit);

            exhibit.HallId = this.Id;
            Exhibits.Add(exhibit);
        }
    }
}
