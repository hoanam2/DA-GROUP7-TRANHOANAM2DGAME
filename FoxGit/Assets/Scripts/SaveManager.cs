//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;
//using UnityEngine.Rendering;
//using UnityEditorInternal;

//public class SaveManager
//{
//    public static string _dirname = "SaveData";
//    public static string _filename = "SaveFile.txt";

//    public static void Save(SaveData saveData)
//    {
//        if(!DirectoryExits())
//        {
//            Directory.CreateDirectory(Application.persistentDataPath + "/" + _dirname);
//        }
//        BinaryFormatter binaryFormatter = new BinaryFormatter();
//        FileStream savefile = File.Create(GetFilePathName());
//        binaryFormatter.Serialize(savefile, saveData);
//        savefile.Close();
//    }
//    public static SaveData Load()
//    {
//        SaveData saveData;

//        if(!SaveDataExits())
//        {
//            saveData = null;
//            Debug.Log("Failed to load");
//        }
//        else
//        {
//            try
//            {
//                BinaryFormatter binaryFormatter = new BinaryFormatter();
//                FileStream loadfile = File.Open(GetFilePathName(),FileMode.Open);
//                saveData = (SaveData)binaryFormatter.Deserialize(loadfile);
//                loadfile.Close();
//            }
//            catch (SerializationException)
//            {
//                saveData = null;
//                Debug.Log("Failed to load ");
//            }
//        }
//        return saveData;
//    }
//    public static bool SaveDataExits()
//    {
//        return File.Exists(GetFilePathName());
//    }
//    public static bool DirectoryExits()
//    {
//        return Directory.Exists(Application.persistentDataPath + "/" + _dirname);
//    }
//    public static string GetFilePathName()
//    {
//        return Application.persistentDataPath + "/" + _dirname  + "/" + _filename;
//    }
//}
