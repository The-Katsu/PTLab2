namespace PTLab2.Domain.Config;

public class DatabaseConfig
{
    public const string Section = "DatabaseConfig";   
    public string ConnectionString {get;set;} = null!;  
}