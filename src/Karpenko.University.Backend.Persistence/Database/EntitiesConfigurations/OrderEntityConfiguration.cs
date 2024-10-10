using Karpenko.University.Backend.Domain.Order;
using Karpenko.University.Backend.Persistence.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Karpenko.University.Backend.Domain.Order.OrderModel;

namespace Karpenko.University.Backend.Persistence.Database.EntitiesConfigurations;

/// <summary>
/// Конфигурация для сущности заказа в БД
/// </summary>
internal sealed class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity> {
  /// <inheritdoc />
  public void Configure(EntityTypeBuilder<OrderEntity> builder) {
    builder.ToTable(Tables.Orders);

    builder.HasKey(model => model.Id);
    
    builder.Property(model => model.Id)
      .IsRequired()
      .HasColumnName("id")
      .ValueGeneratedOnAdd();

    builder.Property(model => model.Description)
      .HasColumnName("description")
      .HasMaxLength(DescriptionMaxLength)
      .IsRequired(false);

    builder.Property(model => model.PayerId)
      .IsRequired()
      .HasColumnName("payer_id");

    builder.Property(model => model.PayerName)
      .HasColumnName("payer_name")
      .HasMaxLength(OrderPayer.NameMaxLength)
      .IsRequired();
    
    builder.Property(model => model.PayerEmail)
      .HasColumnName("payer_email")
      .HasMaxLength(OrderPayer.EmailMaxLength)
      .IsRequired();

    builder.Property(model => model.ProductId)
      .IsRequired()
      .HasColumnName("product_id");
    
    builder.Property(model => model.ProductName)
      .HasColumnName("product_name")
      .HasMaxLength(OrderProduct.NameMaxLength)
      .IsRequired();
    
    builder.Property(model => model.Price)
      .HasColumnName("price")
      .HasColumnType("numeric(10,2)")
      .IsRequired();
    
    builder.Property(model => model.PaymentTime)
      .IsRequired()
      .HasColumnName("payment_time")
      .HasDefaultValueSql("timezone('utc', now())")
      .HasColumnType("timestamp without time zone");
  }
}
