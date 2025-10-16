namespace SyncService.Domain.Entities;

public sealed class Checkpoint
{
    public Guid CheckpointId { get; set; }
    public Guid ListId { get; set; }
    public long Version  { get; set; }
    public string SnapshotJson { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }
}