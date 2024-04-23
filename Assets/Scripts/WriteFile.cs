using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WriteFile : MonoBehaviour
{
    [SerializeField] int fileIndex;
    [SerializeField] TMP_InputField levelName;
    [SerializeField] TextMeshProUGUI pleaseEnterName;
    [SerializeField] ReadFile readFile;

    private void Start()
    {
        readFile = FindObjectOfType<ReadFile>();
        pleaseEnterName.text = string.Empty;
    }

    public void Save()
    {
        StartCoroutine(SaveError());
        string levelData = readFile.LevelData();
        File.WriteAllText($"{Application.streamingAssetsPath}/New Levels /{levelName.text}.txt", levelData);
    }

    public IEnumerator SaveError()
    {
        if (levelName.text == string.Empty)
        {
            Debug.LogWarning("Error");
            pleaseEnterName.text = "*Please Enter a level name";
            yield return new WaitForSeconds(2);
            pleaseEnterName.text = string.Empty;
        }
    }

    public void StartSaveError()
    {
        StartCoroutine(SaveError());
    }
}
