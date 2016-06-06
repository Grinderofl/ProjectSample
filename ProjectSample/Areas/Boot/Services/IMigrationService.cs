namespace ProjectSample.Areas.Boot.Services
{
    public interface IMigrationService
    {
        void CreateMigration(string id);
        void PerformMigration();
    }
}