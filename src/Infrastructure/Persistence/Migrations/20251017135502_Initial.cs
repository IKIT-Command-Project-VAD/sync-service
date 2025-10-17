using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SyncService.src.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:operation_type", "create,update,delete");

            migrationBuilder.CreateTable(
                name: "checkpoints",
                columns: table => new
                {
                    checkpoint_id = table.Column<Guid>(type: "uuid", nullable: false),
                    list_id = table.Column<Guid>(type: "uuid", nullable: false),
                    version = table.Column<long>(type: "bigint", nullable: false),
                    snapshot_json = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkpoints", x => x.checkpoint_id);
                });

            migrationBuilder.CreateTable(
                name: "offline_change_batch",
                columns: table => new
                {
                    batch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    list_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    client_version = table.Column<long>(type: "bigint", nullable: false),
                    received_at = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offline_change_batch", x => x.batch_id);
                });

            migrationBuilder.CreateTable(
                name: "change_operations",
                columns: table => new
                {
                    operation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    batch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    operation_type = table.Column<int>(type: "operation_type", nullable: false),
                    item_id = table.Column<Guid>(type: "uuid", nullable: true),
                    FieldName = table.Column<string>(type: "text", nullable: true),
                    old_value = table.Column<string>(type: "text", nullable: true),
                    new_value = table.Column<string>(type: "text", nullable: true),
                    client_version = table.Column<long>(type: "bigint", nullable: true),
                    OfflineChangeBatchBatchId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_change_operations", x => x.operation_id);
                    table.ForeignKey(
                        name: "FK_change_operations_offline_change_batch_OfflineChangeBatchBa~",
                        column: x => x.OfflineChangeBatchBatchId,
                        principalTable: "offline_change_batch",
                        principalColumn: "batch_id");
                    table.ForeignKey(
                        name: "FK_change_operations_offline_change_batch_batch_id",
                        column: x => x.batch_id,
                        principalTable: "offline_change_batch",
                        principalColumn: "batch_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_change_operations_batch_id",
                table: "change_operations",
                column: "batch_id");

            migrationBuilder.CreateIndex(
                name: "IX_change_operations_OfflineChangeBatchBatchId",
                table: "change_operations",
                column: "OfflineChangeBatchBatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "change_operations");

            migrationBuilder.DropTable(
                name: "checkpoints");

            migrationBuilder.DropTable(
                name: "offline_change_batch");
        }
    }
}
