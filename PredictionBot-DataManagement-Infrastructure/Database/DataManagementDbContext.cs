using Microsoft.EntityFrameworkCore;
using PredictionBot_DataManagement_Domain.Models;

namespace Database;

public class DataManagementDbContext : DbContext
{
    public DataManagementDbContext(DbContextOptions<DataManagementDbContext> options) : base(options)
    {
    }

    public DbSet<CalculatedParametersHistoricalData> CalculatedParametersHistoricalData { get; set; }

    public DbSet<CalculatedParametersHistoricalDataMapping> CalculatedParametersHistoricalDataMapping { get; set; }

    public DbSet<Currency> Currency { get; set; }

    public DbSet<Exchange> Exchange { get; set; }

    public DbSet<HistoricalData> HistoricalData { get; set; }

    public DbSet<Interval> Interval { get; set; }

    public DbSet<Parameter> Parameter { get; set; }

    public DbSet<Symbol> Symbol { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalculatedParametersHistoricalDataMapping>(entity =>
        {
            entity.HasKey(e => e.MappingId).HasName("PRIMARY");

            entity.ToTable("calculatedparametershistoricaldatamapping");

            entity.HasIndex(e => e.CalculatedParameterId, "calculated_parameter_id");

            entity.HasIndex(e => e.DataId, "data_id");

            entity.Property(e => e.MappingId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("mapping_id");
            entity.Property(e => e.CalculatedParameterId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("calculated_parameter_id");
            entity.Property(e => e.DataId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("data_id");

            entity.HasOne(d => d.CalculatedParameter).WithMany(p => p.CalculatedParametersHistoricalDataMappings)
                .HasForeignKey(d => d.CalculatedParameterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("calculated_parameter_id");

            entity.HasOne(d => d.Data).WithMany(p => p.CalculatedParametersHistoricalDataMappings)
                .HasForeignKey(d => d.DataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("data_id");
        });

        modelBuilder.Entity<CalculatedParametersHistoricalData>(entity =>
        {
            entity.HasKey(e => e.CalculatedParameterId).HasName("PRIMARY");

            entity.ToTable("calculatedparametershistoricaldata");

            entity.HasIndex(e => e.ParameterId, "parameter_id");

            entity.Property(e => e.CalculatedParameterId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("calculated_parameter_id");
            entity.Property(e => e.CalculatedValue).HasColumnName("calculated_value");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.ParameterId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("parameter_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Parameter).WithMany(p => p.CalculatedParametersHistoricalData)
                .HasForeignKey(d => d.ParameterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("parameter_id");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.CurrencyId).HasName("PRIMARY");

            entity.ToTable("currency");

            entity.Property(e => e.CurrencyId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("currency_id");
            entity.Property(e => e.CurrencyName)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("currency_name");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("currency_symbol");
        });

        modelBuilder.Entity<Exchange>(entity =>
        {
            entity.HasKey(e => e.ExchangeId).HasName("PRIMARY");

            entity.ToTable("exchange");

            entity.Property(e => e.ExchangeId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("exchange_id");
            entity.Property(e => e.ExchangeName)
                .HasMaxLength(250)
                .HasColumnName("exchange_name");
            entity.Property(e => e.Timezone)
                .HasMaxLength(250)
                .HasColumnName("timezone");
        });

        modelBuilder.Entity<HistoricalData>(entity =>
        {
            entity.HasKey(e => e.DataId).HasName("PRIMARY");

            entity.ToTable("historicaldata");

            entity.HasIndex(e => e.IntervalId, "interval_id");

            entity.HasIndex(e => e.SymbolId, "symbol_id");

            entity.Property(e => e.DataId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("data_id");
            entity.Property(e => e.ClosePrice).HasColumnName("close_price");
            entity.Property(e => e.Datetime)
                .HasColumnType("datetime")
                .HasColumnName("datetime");
            entity.Property(e => e.HighPrice).HasColumnName("high_price");
            entity.Property(e => e.IntervalId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("interval_id");
            entity.Property(e => e.LowPrice).HasColumnName("low_price");
            entity.Property(e => e.OpenPrice).HasColumnName("open_price");
            entity.Property(e => e.SymbolId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("symbol_id");
            entity.Property(e => e.Volume).HasColumnName("volume");

            entity.HasOne(d => d.Interval).WithMany(p => p.HistoricalData)
                .HasForeignKey(d => d.IntervalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("interval_id");

            entity.HasOne(d => d.Symbol).WithMany(p => p.Historicaldata)
                .HasForeignKey(d => d.SymbolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("symbol_id");
        });

        modelBuilder.Entity<Interval>(entity =>
        {
            entity.HasKey(e => e.IntervalId).HasName("PRIMARY");

            entity.ToTable("interval");

            entity.Property(e => e.IntervalId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("interval_id");
            entity.Property(e => e.IntervalName)
                .HasMaxLength(250)
                .HasColumnName("interval_name");
        });

        modelBuilder.Entity<Parameter>(entity =>
        {
            entity.HasKey(e => e.ParameterId).HasName("PRIMARY");

            entity.ToTable("parameters");

            entity.Property(e => e.ParameterId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("parameter_id");
            entity.Property(e => e.ParameterName)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("parameter_name");
        });

        modelBuilder.Entity<Symbol>(entity =>
        {
            entity.HasKey(e => e.SymbolId).HasName("PRIMARY");

            entity.ToTable("symbol");

            entity.HasIndex(e => e.CurrencyId, "currency_id");

            entity.HasIndex(e => e.ExchangeId, "exchange_id");

            entity.Property(e => e.SymbolId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("symbol_id");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("currency_id");
            entity.Property(e => e.ExchangeId)
                .HasMaxLength(250)
                .HasDefaultValueSql("''")
                .HasColumnName("exchange_id");
            entity.Property(e => e.SymbolName)
                .HasMaxLength(250)
                .HasColumnName("symbol_name");

            entity.HasOne(d => d.Currency).WithMany(p => p.Symbols)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("currency_id");

            entity.HasOne(d => d.Exchange).WithMany(p => p.Symbols)
                .HasForeignKey(d => d.ExchangeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("exchange_id");
        });
    }
}