using SyncService.Domain.Enums;

namespace SyncService.Domain.Entities;

public sealed class ChangeOperation
{
    public Guid OperationId { get; set; }
    public Guid BatchId { get; set; }
    public OfflineChangeBatch OfflineChangeBatch { get; set; } = null!;
    public OperationType OperationType { get; set; }
    public Guid? ItemId { get; set; }
    public string? FieldName { get; set; }
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
    public long? ClientVersion { get; set; }
}