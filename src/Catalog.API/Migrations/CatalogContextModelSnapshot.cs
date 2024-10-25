﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pgvector;
using eShop.Catalog.API.Infrastructure;

#nullable disable

namespace Catalog.API.Migrations
{
    [DbContext(typeof(CatalogContext))]
    partial class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "vector");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Catalog.API.Model.CatalogFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .HasColumnType("text");

                    b.Property<string>("TitleDE")
                        .HasColumnType("text");

                    b.Property<string>("TitleEN")
                        .HasColumnType("text");

                    b.Property<string>("ValueDE")
                        .HasColumnType("text");

                    b.Property<string>("ValueEN")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CatalogFeatures");
                });

            modelBuilder.Entity("Catalog.API.Model.CatalogItemVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CatalogItemId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("ProudctIdString")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "pid");

                    b.Property<string>("VarianImageEnhanced")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<decimal>("VariantHeigt")
                        .HasColumnType("numeric")
                        .HasAnnotation("Relational:JsonPropertyName", "variantHeight");

                    b.Property<string>("VariantId")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "vid");

                    b.Property<string>("VariantImageOrigin")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasAnnotation("Relational:JsonPropertyName", "variantImage");

                    b.Property<string>("VariantKeyDE")
                        .HasColumnType("text");

                    b.Property<string>("VariantKeyEN")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "variantKey");

                    b.Property<decimal>("VariantLength")
                        .HasColumnType("numeric")
                        .HasAnnotation("Relational:JsonPropertyName", "variantLength");

                    b.Property<decimal>("VariantPrice")
                        .HasColumnType("numeric")
                        .HasAnnotation("Relational:JsonPropertyName", "variantSellPrice");

                    b.Property<string>("VariantSKU")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "variantSku");

                    b.Property<decimal>("VariantSellPrice")
                        .HasColumnType("numeric")
                        .HasAnnotation("Relational:JsonPropertyName", "variantSugSellPrice");

                    b.Property<string>("VariantStandart")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "variantStandard");

                    b.Property<decimal>("VariantWith")
                        .HasColumnType("numeric")
                        .HasAnnotation("Relational:JsonPropertyName", "variantWidth");

                    b.Property<decimal>("VariatVolume")
                        .HasColumnType("numeric")
                        .HasAnnotation("Relational:JsonPropertyName", "variantVolume");

                    b.HasKey("Id");

                    b.HasIndex("CatalogItemId");

                    b.ToTable("CatalogItemVariants");
                });

            modelBuilder.Entity("Catalog.API.Model.CatalogKit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NameDE")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CatalogKits");
                });

            modelBuilder.Entity("Catalog.API.Model.EnchancedImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CatalogItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Src")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CatalogItemId");

                    b.ToTable("EnhancedImages");
                });

            modelBuilder.Entity("Catalog.API.Model.OriginalImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CatalogItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Src")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CatalogItemId");

                    b.ToTable("OriginalImages");

                    b.HasAnnotation("Relational:JsonPropertyName", "productImageSet");
                });

            modelBuilder.Entity("CatalogFeatureCatalogItem", b =>
                {
                    b.Property<int>("CatalogFeaturesId")
                        .HasColumnType("integer");

                    b.Property<int>("CatalogItemsId")
                        .HasColumnType("integer");

                    b.HasKey("CatalogFeaturesId", "CatalogItemsId");

                    b.HasIndex("CatalogItemsId");

                    b.ToTable("CatalogFeatureCatalogItem");
                });

            modelBuilder.Entity("CatalogItemCatalogKit", b =>
                {
                    b.Property<int>("CatalogItemsId")
                        .HasColumnType("integer");

                    b.Property<int>("CatalogKitsId")
                        .HasColumnType("integer");

                    b.HasKey("CatalogItemsId", "CatalogKitsId");

                    b.HasIndex("CatalogKitsId");

                    b.ToTable("CatalogItemCatalogKit");
                });

            modelBuilder.Entity("eShop.Catalog.API.Model.CatalogItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailableStock")
                        .HasColumnType("integer");

                    b.Property<int>("CatalogBrandId")
                        .HasColumnType("integer");

                    b.Property<int>("CatalogTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("CategoryId")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "categoryId");

                    b.Property<string>("CategoryNameDE")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("CategoryNameEN")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasAnnotation("Relational:JsonPropertyName", "categoryName");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)")
                        .HasAnnotation("Relational:JsonPropertyName", "description");

                    b.Property<string>("DescriptionDE")
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<string>("DescriptionEN")
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<Vector>("Embedding")
                        .HasColumnType("vector(384)");

                    b.Property<int>("ListedNum")
                        .HasColumnType("integer")
                        .HasAnnotation("Relational:JsonPropertyName", "ListedNum");

                    b.Property<int>("MaxStockThreshold")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("NameDE")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("NameEN")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<bool>("OnReorder")
                        .HasColumnType("boolean");

                    b.Property<string>("OriginName")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)")
                        .HasAnnotation("Relational:JsonPropertyName", "productNameEn");

                    b.Property<string>("OriginPrice")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "sellPrice");

                    b.Property<string>("PackingNameDE")
                        .HasColumnType("text");

                    b.Property<string>("PackingNameEN")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "packingNameEn");

                    b.Property<string>("PackingNameSetDE")
                        .HasColumnType("text");

                    b.Property<string>("PackingNameSetEN")
                        .HasColumnType("text");

                    b.Property<string>("PackingWeight")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "packingWeight");

                    b.Property<string>("PictureFileName")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProducctType")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "productType");

                    b.Property<string>("ProductKenDE")
                        .HasColumnType("text");

                    b.Property<string>("ProductKeyEN")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "productKeyEn");

                    b.Property<string>("ProductSKU")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "productSku");

                    b.Property<string>("ProductWeight")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "productWeight");

                    b.Property<int>("RestockThreshold")
                        .HasColumnType("integer");

                    b.Property<string>("SuggestSellPrice")
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "suggestSellPrice");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("CatalogItems", (string)null);
                });

            modelBuilder.Entity("eShop.IntegrationEventLogEF.IntegrationEventLogEntry", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<int>("TimesSent")
                        .HasColumnType("integer");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uuid");

                    b.HasKey("EventId");

                    b.ToTable("IntegrationEventLog", (string)null);
                });

            modelBuilder.Entity("Catalog.API.Model.CatalogItemVariant", b =>
                {
                    b.HasOne("eShop.Catalog.API.Model.CatalogItem", "CatalogItem")
                        .WithMany("CatalogItemVariants")
                        .HasForeignKey("CatalogItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogItem");
                });

            modelBuilder.Entity("Catalog.API.Model.EnchancedImages", b =>
                {
                    b.HasOne("eShop.Catalog.API.Model.CatalogItem", "CatalogItem")
                        .WithMany("EnhancedImages")
                        .HasForeignKey("CatalogItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogItem");
                });

            modelBuilder.Entity("Catalog.API.Model.OriginalImages", b =>
                {
                    b.HasOne("eShop.Catalog.API.Model.CatalogItem", "CatalogItem")
                        .WithMany("OriginalImages")
                        .HasForeignKey("CatalogItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogItem");
                });

            modelBuilder.Entity("CatalogFeatureCatalogItem", b =>
                {
                    b.HasOne("Catalog.API.Model.CatalogFeature", null)
                        .WithMany()
                        .HasForeignKey("CatalogFeaturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eShop.Catalog.API.Model.CatalogItem", null)
                        .WithMany()
                        .HasForeignKey("CatalogItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CatalogItemCatalogKit", b =>
                {
                    b.HasOne("eShop.Catalog.API.Model.CatalogItem", null)
                        .WithMany()
                        .HasForeignKey("CatalogItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.API.Model.CatalogKit", null)
                        .WithMany()
                        .HasForeignKey("CatalogKitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eShop.Catalog.API.Model.CatalogItem", b =>
                {
                    b.Navigation("CatalogItemVariants");

                    b.Navigation("EnhancedImages");

                    b.Navigation("OriginalImages");
                });
#pragma warning restore 612, 618
        }
    }
}
