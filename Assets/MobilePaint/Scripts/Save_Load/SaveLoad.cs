using System.Collections;
using System.Collections.Generic;
using unitycoder_MobilePaint;
using UnityEngine;
using System.IO;

public class SaveLoad : MobilePaint
{
    [Header("Save/Load")]
    [SerializeField]
    bool autoLoadSavedDataOnStart;

    public string savePath;

    private void Start()
    {
        LoadProgress(savePath);
    }

    public void LoadProgress(string path)
    {
        if (!File.Exists(path))
            return;
        drawingTexture.LoadRawTextureData(File.ReadAllBytes(path));
        drawingTexture.Apply(false);
    }

    public void SaveProgress(string path)
    {
        //NOTE: MIGHT NEED TO CREATE A NEW DIRECTORY
        File.WriteAllBytes(path, pixels);
    }
}
