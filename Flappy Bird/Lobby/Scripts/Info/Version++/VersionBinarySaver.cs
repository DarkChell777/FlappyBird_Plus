using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class VersionBinarySaver : MonoBehaviour
{
    private string filePath;

    [Serializable]
    public class VersionData
    {
        public string DeviceId;
    }

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

    public void SaveData()
    {
        VersionData data = new VersionData
        {
            DeviceId = GetDeviceID()
        };

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream;

        if (File.Exists(filePath)) stream = new FileStream(filePath, FileMode.Open, FileAccess.Write);
        else stream = new FileStream(filePath, FileMode.Create);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public bool LoadData()
    {
        filePath = Path.Combine(Application.persistentDataPath, "Version.dat");
        
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);

            VersionData data = formatter.Deserialize(stream) as VersionData;
            stream.Close();

            Debug.Log(data.DeviceId);
            Debug.Log(GetDeviceID());

            if (data.DeviceId == GetDeviceID()) return true;

            return false;
        }
        else
        {
            Debug.Log("Файл не найден: " + filePath);
            return false;
        }
    }
}


