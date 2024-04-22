using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class WriteFile : MonoBehaviour
{ 
    [SerializeField] int fileIndex ;
    [SerializeField] ReadFile readFile;

    private void Start()
    {
        readFile = FindObjectOfType<ReadFile>();
    }

    public void Save()
    {
        string levelData = readFile.LevelData();
        File.WriteAllText($"{Application.streamingAssetsPath}/New Levels /New Level {readFile.fileIndex}.txt", levelData);
    }
}
