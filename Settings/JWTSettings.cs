namespace MusicFestivalManagement.Settings;
public class JWTSettings
{
    public const string JWT = "JWTSettings";
    public string? ValidAudience { get; set; }
    public string? ValidIssuer { get; set; }
    public string? Secret { get; set; }
}