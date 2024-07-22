using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonMonoBehaviour<DataManager>
{
    public bool isLoaded;

    public Data dataSaved;
    private const string DATA_SEVED = "DataSaved";
    private Data dataBackup;

    private void Start()
    {
        LoadData();
    }

    private void OnApplicationPause(bool pause)
    {
        SaveData();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    public void LoadData()
    {
        isLoaded = true;
        if (dataSaved.isNew)
        {
            dataSaved = new Data();
            dataSaved.isNew = false;
        }
        else
        {
            if (PlayerPrefs.HasKey(DATA_SEVED))
            {
                dataSaved = JsonUtility.FromJson<Data>(PlayerPrefs.GetString(DATA_SEVED));
            }
        }

    }

    public void SaveData()
    {
        if (!isLoaded) return;
        PlayerPrefs.SetString(DATA_SEVED, JsonUtility.ToJson(dataSaved));
    }

    [System.Serializable]
    public class Data{

        public bool isNew;

        public int indexLevelColorPencil;

        public Data()
        {
            isNew = false;
            indexLevelColorPencil = 0;
        }
    }
}
