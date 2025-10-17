using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncService.Domain.Entities;

namespace SyncService.Infrastructure.Persistence.Configurations;

public class CheckpointConfig : IEntityTypeConfiguration<Checkpoint>
{
    public void Configure(EntityTypeBuilder<Checkpoint> b)
    {
        b.ToTable("checkpoints");
        b.HasKey(x => x.CheckpointId);
        b.Property(x => x.CheckpointId).HasColumnName("checkpoint_id").HasColumnType("uuid");
        b.Property(x => x.ListId).HasColumnName("list_id").HasColumnType("uuid");
        b.Property(x => x.Version).HasColumnName("version");
        b.Property(x => x.SnapshotJson).HasColumnName("snapshot_json");
        b.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamptz");
    }
}