namespace SyncService.Domain.Entities;

public sealed class OfflineChangeBatch
{
    public Guid BatchId  { get; set; }
    public Guid ListId  { get; set; }
    public Guid UserId  { get; set; }
    public long ClientVersion { get; set; }
    public List<ChangeOperation> Operations { get; set; } = new();
    public DateTimeOffset ReceivedAt { get; set; }
}
