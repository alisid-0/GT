using UnityEngine;
using System;
using System.IO;

public class SaveFileDataWriter
{
    public string saveDataDirectoryPath = "";
    public string saveFileName = "";

    // BEFORE WE CREATE A NEW SAVE FILE WE MUST CHECK TO SEE IF ONE OF THIS CHARACTER SLOT ALREADY EXISTS (MAX TEN)
    public bool CheckToSeeIfFileExists()
    {
        if (File.Exists(Path.Combine(saveDataDirectoryPath, saveFileName)))
        {
            return true;
        }
        else return false;
    }

    // USED TO DELETE CHARACTER SAVE FILES
    public void DeleteSaveFile()
    {
        File.Delete(Path.Combine(saveDataDirectoryPath, saveFileName));
    }

    public void CreateNewCharacterSaveFile(CharacterSaveData characterData)
    {
        // MAKE A PATH TO SAVE THE FILE (A LOCATION ON THE MACHINE)

        string savePath = Path.Combine(saveDataDirectoryPath, saveFileName);

        try
        {
            // CREATE DIRECTORY THE FILE WILL BE WRITTEN TO, IF IT DOES NOT ALREADY EXIST
            Directory.CreateDirectory(Path.GetDirectoryName(savePath));
            Debug.Log("CREATING SAVE FILE, AT SAVE PATH: " + savePath);

            // SERIALIZE THE C# GAME DATA OBJECT INTO JSON
            string dataToStore = JsonUtility.ToJson(characterData, true);

            // WRITE THE FILE TO OUR SYSTEM
            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                using (StreamWriter fileWriter = new StreamWriter(stream))
                {
                    fileWriter.Write(dataToStore);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("ERROR WHILST TRYING TO SAVE CHARACTER DATA: " + savePath + "\n" + ex);
        }
    }

    // USED TO LOAD SAVE FILE UPON LOADING A PREVIOUS GAME
    public CharacterSaveData LoadSaveFile()
    {
        CharacterSaveData characterData = null;

        string loadPath = Path.Combine(saveDataDirectoryPath, saveFileName);
        if (File.Exists(loadPath))
        {

            try
            {
                string dataToLoad = "";

                using (FileStream stream = new FileStream(loadPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                // DESERIALIZE THE DATA FROM JSON BACK TO UNITY
                characterData = JsonUtility.FromJson<CharacterSaveData>(dataToLoad);
            }
            catch (Exception ex)
            {
                Debug.LogError("ERROR LOADING");
            }
        }

        return characterData;
    }
}
