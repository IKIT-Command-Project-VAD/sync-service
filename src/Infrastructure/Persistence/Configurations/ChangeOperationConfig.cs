using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncService.Domain.Entities;

namespace SyncService.Infrastructure.Persistence.Configurations;

public class ChangeOperationConfig : IEntityTypeConfiguration<ChangeOperation>
{
    public void Configure(EntityTypeBuilder<ChangeOperation> b)
    {
        b.ToTable("change_operations");
        b.HasKey(x => x.OperationId);
        b.Property(x => x.OperationId).HasColumnName("operation_id").HasColumnType("uuid");
        b.Property(x => x.BatchId).HasColumnName("batch_id").HasColumnType("uuid");
        b.Property(x => x.OperationType).HasColumnName("operation_type").HasColumnType("operation_type");
        b.Property(x => x.ItemId).HasColumnName("item_id").HasColumnType("uuid");
        b.Property(x => x.OldValue).HasColumnName("old_value");
        b.Property(x => x.NewValue).HasColumnName("new_value");
        b.Property(x => x.ClientVersion).HasColumnName("client_version");

        b.HasOne(x => x.OfflineChangeBatch).WithMany().HasForeignKey(x => x.BatchId);
    }
}