using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace SaveSpace
{
    public enum SaveFoldersEnum
    {
        Default,
        ShoppingGame,
    };

    public static class SaveSystem
    {

        private const string SAVE_EXTENSION = "txt";
        private static string SAVE_FOLDER {get => Application.persistentDataPath + "/Saves/" + Folder + "/"; }
            
        private static bool isInit = false;
        public static bool FileIsExist;
        public static SaveFoldersEnum Folder = SaveFoldersEnum.Default;

        public static void Init(SaveFoldersEnum whichFolder)
        {
            if (!isInit)
            {
                Folder = whichFolder;
                isInit = true;
                // Test if Save Folder exists
                if (!Directory.Exists(SAVE_FOLDER))
                {
                    // Create Save Folder
                    Directory.CreateDirectory(SAVE_FOLDER);
                }
            }
        }

        public static bool IsThereAnySaves(SaveFoldersEnum whichFolder)
        {
            Folder = whichFolder;
            if (Directory.Exists(SAVE_FOLDER))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
                FileInfo[] saveFiles = directoryInfo.GetFiles("*." + SAVE_EXTENSION);
                if (saveFiles.Length <= 0)
                    return false;
                else
                    return true;
            }
            else
                return false;

        }


        private static void Save(SaveFoldersEnum whichFolder, string fileName, string saveString, bool overwrite = false)
        {         
            Init(whichFolder);
            string saveFileName = fileName;
            string saveDirName = SAVE_FOLDER + saveFileName + "." + SAVE_EXTENSION;
            DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);

            if (!overwrite)
            {
                Debug.Log("Make other save");
                int saveNumber = 1; //Make sure savedata is unique, so we don't accidentally overwrite our save
                while (File.Exists(SAVE_FOLDER + saveFileName + "." + SAVE_EXTENSION))
                {
                    saveNumber++;
                    saveFileName = fileName + "_" + saveNumber;
                    saveDirName = SAVE_FOLDER + saveFileName + "." + SAVE_EXTENSION;
                }
            }
            else
            {
                Debug.Log("Overwrite save");
                saveDirName = FindOldestFile(Folder, saveFileName);
            }

            File.WriteAllText(saveDirName, saveString);
        }

        public static string FindOldestFile(SaveFoldersEnum whichFolder, string fileName)
        {
            Init(whichFolder);
            DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
            FileInfo[] saveFiles = directoryInfo.GetFiles("*." + SAVE_EXTENSION);
            FileInfo oldestFile = null;
            foreach (FileInfo file in saveFiles)
            {
                if (oldestFile == null)
                    oldestFile = file;
                else
                {
                    if (file.LastWriteTime < oldestFile.LastWriteTime)
                        oldestFile = file;
                }
            }
            if (oldestFile != null)
                return oldestFile.FullName;
            else
            {
                Debug.Log("No saves found");
                return null;
            }
        }


        public static string LoadMostRecentFile(SaveFoldersEnum whichFolder)
        {
            Init(whichFolder);
            DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
            FileInfo[] saveFiles = directoryInfo.GetFiles("*." + SAVE_EXTENSION);
            FileInfo mostRecentFile = null;
            foreach (FileInfo fileInfo in saveFiles)
            {
                if (mostRecentFile == null)
                    mostRecentFile = fileInfo;
                else
                {
                    if (fileInfo.LastWriteTime > mostRecentFile.LastWriteTime)
                        mostRecentFile = fileInfo;
                }
            }
            
            if (mostRecentFile != null)
            {
                Debug.Log(mostRecentFile);
                string saveString = File.ReadAllText(mostRecentFile.FullName);
                return saveString;
            }
            else
                return null;
        }

        public static void SaveObject(object saveObject, SaveFoldersEnum whichFolder)
        {
            Debug.Log(saveObject);
            SaveObject(whichFolder, "save", saveObject, false);
        }

        public static void SaveObject(SaveFoldersEnum whichFolder, string fileName, object saveObject, bool overwrite)
        {
            Init(whichFolder);
            string json = JsonUtility.ToJson(saveObject);
            Debug.Log("save");
            Save(whichFolder, fileName, json, overwrite);
        }

        public static TSaveObject LoadMostRecentObject<TSaveObject>(SaveFoldersEnum whichFolder)
        {
            string saveString = LoadMostRecentFile(whichFolder);
            if (saveString != null)
            {
                TSaveObject saveObject = JsonUtility.FromJson<TSaveObject>(saveString);
                return saveObject;
            }
            else
                return default;
        }

        public static TSaveObject LoadObject<TSaveObject>(SaveFoldersEnum whichFolder, string fileName)
        {
            Init(whichFolder);
            TSaveObject saveObject = JsonUtility.FromJson<TSaveObject>(fileName);
            return saveObject;
        }

    }
}