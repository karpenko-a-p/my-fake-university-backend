﻿using Karpenko.University.Backend.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karpenko.University.Backend.Persistence.Database.EntitiesConfigurations;

/// <summary>
/// Конфигурация модели стоимости товара в БД
/// </summary>
internal sealed class PriceEntityConfiguration : IEntityTypeConfiguration<PriceEntity> {
  /// <inheritdoc />
  public void Configure(EntityTypeBuilder<PriceEntity> builder) {
    builder.ToTable(Tables.ProductsPrices);

    builder.HasKey(model => model.Id);

    builder.Property(model => model.Id)
      .HasColumnName("id")
      .IsRequired();
    
    builder.Property(model => model.ProductId)
      .HasColumnName("product_id")
      .IsRequired();

    builder.Property(model => model.Price)
      .HasColumnType("numeric(10,2)")
      .HasColumnName("price")
      .IsRequired();

    builder.Property(model => model.SalePrice)
      .HasColumnType("numeric(10,2)")
      .HasColumnName("sale_price")
      .IsRequired();

    builder.Property(model => model.DiscountPercent)
      .HasColumnName("discount_percent")
      .IsRequired();

    builder.Property(model => model.SalesUntil)
      .HasColumnType("timestamp without time zone")
      .HasColumnName("sales_until")
      .IsRequired();
  }
}
