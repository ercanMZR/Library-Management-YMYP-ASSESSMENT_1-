using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YMYP_ASSESSMENT_1.Models.Repositories.Entities;

namespace YMYP_ASSESSMENT_1.Models.Repositories.Configurations
{
    public class BookConfiguration:IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();

            builder.Property(x=> x.Title).IsRequired().HasMaxLength(150);

            builder.Property(x => x.Author).IsRequired().HasMaxLength(100);

            builder.Property(x => x.PublicationYear).IsRequired();

            builder.Property(x => x.ISBN).IsRequired().HasMaxLength(13);

            builder.Property(x => x.Genre).IsRequired().HasMaxLength(50);

            builder.Property(x=>x.Publisher).IsRequired().HasMaxLength(100);

            builder.Property(x => x.PageCount).IsRequired();

            builder.Property(x => x.Language).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Summary).IsRequired().HasMaxLength(600);

            builder.Property(x=>x.AvailableCopies).IsRequired();
        }
    }
}
