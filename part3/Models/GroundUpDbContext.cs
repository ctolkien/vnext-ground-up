using Microsoft.Data.Entity;

public class GroundUpDbContext : DbContext
{
    DbSet<TodoItem> Todos {get; set;}

    protected override void OnConfiguring(DbContextOptions builder)
    {
        builder.UseSqlServer(@"Server=(localdb)\v11.0;Database=TodoItems;Trusted_Connection=True;");
    }
}

public class TodoItem
{
    public int Id {get; set;}
    public string Description {get; set;}
}
