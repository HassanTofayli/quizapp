using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace quizapp.Models;

public class StudentClassroom
{
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public int ClassRoomId { get; set; }
    public ClassRoom ClassRoom { get; set; } = null!;
}

public class CarTagConfig : IEntityTypeConfiguration<StudentClassroom>
{
    public void Configure(EntityTypeBuilder<StudentClassroom> builder)
    {
        builder.HasKey(x => new { x.StudentId, x.ClassRoomId }); // Creates a composite primary key
    }
}