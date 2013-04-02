namespace ProjectTemplate.Infrastructure.DataBaseContext.Interfaces
{
    public interface IDataBaseFactory
    {
        ProjectTemplateDbContext GetContext();
    }
}