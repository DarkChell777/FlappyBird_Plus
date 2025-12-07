using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class BinarySaver : MonoBehaviour
{
    private string filePath;
    private DateTime giftOpenedTime;

    private string GetDeviceID()
    {
        string id = SystemInfo.deviceUniqueIdentifier;
        return ReverseString(id);
    }

    private string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    [Serializable]
    public class PlayerData
    {
        public string DeviceID;
        public int Balance;
        public DateTime lastOpenedGift;
        public int beastScore;
        public Dictionary<PlayerSkinType, bool> acquiredPlayerSkins;
        public Dictionary<BackgroundSkinType, bool> acquiredBackgroundSkins;
    }

    public void SaveData(int coins, int score, Dictionary<PlayerSkinType, bool> PSkins, Dictionary<BackgroundSkinType, bool> BSkins)
    {
        PlayerData data = new PlayerData
        {
            DeviceID = GetDeviceID(),
            Balance = coins,
            lastOpenedGift = giftOpenedTime,
            beastScore = score,
            acquiredPlayerSkins = PSkins,
            acquiredBackgroundSkins = BSkins
        };

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream;

        if (File.Exists(filePath)) stream = new FileStream(filePath, FileMode.Open, FileAccess.Write);
        else stream = new FileStream(filePath, FileMode.Create);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public PlayerData LoadData()
    {
        filePath = Path.Combine(Application.persistentDataPath, "GameData.dat");
        Debug.Log(filePath);

        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            if (data.DeviceID == GetDeviceID()) 
            {
                giftOpenedTime = data.lastOpenedGift;
                return data;
            }

            return null;
        }
        else
        {
            Debug.Log("Файл не найден: " + filePath);
            return null;
        }
    }

    public void DeleteData()
    {
        filePath = Path.Combine(Application.persistentDataPath, "GameData.dat");

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public void SetGiftOpenedTime(DateTime dateTime)
    {
        giftOpenedTime = dateTime;
    }

    public DateTime PutGiftOpenedTime()
    {
        return giftOpenedTime;
    }
}


