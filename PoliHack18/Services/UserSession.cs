namespace PoliHack18.Services;

public class UserSession
{
    public static Guid CurrentUserId { get; private set; }

    public static void Login(Guid userId)
    {
        CurrentUserId = userId;
    }

    public static void Logout()
    {
        CurrentUserId = Guid.Empty;
    }
        
    public static bool IsLoggedIn => CurrentUserId != Guid.Empty;
}