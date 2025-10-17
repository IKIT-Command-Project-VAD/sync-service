using Microsoft.EntityFrameworkCore;
using SyncService.Domain.Entities;
using SyncService.Domain.Enums;
using SyncService.Infrastructure.Persistence.Configurations;

namespace SyncService.Infrastructure.Persistence.Context;

public class SyncDbContext(DbContextOptions<SyncDbContext> options) : DbContext
{
    public DbSet<OfflineChangeBatch> OfflineChangeBatches => Set<OfflineChangeBatch>();
    public DbSet<ChangeOperation> ChangeOperations => Set<ChangeOperation>();
    public DbSet<Checkpoint> Checkpoints => Set<Checkpoint>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<OperationType>(null, "operation_type");

        modelBuilder.ApplyConfiguration(new CheckpointConfig());
        modelBuilder.ApplyConfiguration(new OfflineChangeBatchConfig());
        modelBuilder.ApplyConfiguration(new ChangeOperationConfig());
    }
}