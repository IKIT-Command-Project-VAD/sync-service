using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncService.Domain.Entities;

namespace SyncService.Infrastructure.Persistence.Configurations;

public class OfflineChangeBatchConfig : IEntityTypeConfiguration<OfflineChangeBatch>
{
    public void Configure(EntityTypeBuilder<OfflineChangeBatch> b)
    {
        b.ToTable("offline_change_batch");
        b.HasKey(x => x.BatchId);
        b.Property(x => x.BatchId).HasColumnName("batch_id").HasColumnType("uuid");
        b.Property(x => x.ListId).HasColumnName("list_id").HasColumnType("uuid");
        b.Property(x => x.UserId).HasColumnName("user_id").HasColumnType("uuid");
        b.Property(x => x.ClientVersion).HasColumnName("client_version");
        b.Property(x => x.ReceivedAt).HasColumnName("received_at").HasColumnType("timestamptz");
    }
}