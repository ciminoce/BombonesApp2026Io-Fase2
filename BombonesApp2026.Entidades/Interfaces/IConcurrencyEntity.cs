namespace BombonesApp2026.Entidades.Interfaces
{
    public interface IConcurrencyEntity
    {
        public byte[] RowVersion { get; set; }
    }
}
