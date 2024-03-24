
[System.Serializable] public class PlayerData
{
    public int Point = 0;
}
public class GameDataManager
{
    private static PlayerData _playerData = new PlayerData();
    static GameDataManager()
    {
        LoadPlayerData();
    }

    public static int GetPoint()
    {
        return _playerData.Point;
    }

    public static void AddPoint(int amount)
    {
        _playerData.Point += amount;
        SavePlayerData();
    }

    public static bool canSpendPoint(int amount)
    {
        return (_playerData.Point >= amount);
    }

    public static void spendPoint(int amount)
    {
        _playerData.Point += amount;
    }

    static void LoadPlayerData()
    {
        _playerData = BinarySerializer.Load<PlayerData>("player-data.txt");
        UnityEngine.Debug.Log("<color=green>[PlayerData] Loaded.</color>");
    }

    static void SavePlayerData()
    {
        BinarySerializer.Save(_playerData,"player-data.txt");
        UnityEngine.Debug.Log("<color=red>[PlayerData] Saved.</color>");
    }
}
