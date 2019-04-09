using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileReader : MonoBehaviour
{
    public string path;
    FileSystemWatcher file;

    private void Start()
    {
        //Reader = new StreamReader(path);

        FileSystemWatcher file = new FileSystemWatcher();
        file.Path = path;
        file.Filter = "*.txt";
        file.NotifyFilter = NotifyFilters.LastWrite;
        file.Changed += ReadFile;
        file.EnableRaisingEvents = true;
        //print(file.Path);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
            ReadFile();
            */
            /*
        if (Reader.ReadLine() != null)
            print(Reader.ReadLine());*/
        
    }

    private void ReadFile(object source, FileSystemEventArgs e)
    {
        using ( StreamReader reader = new StreamReader(e.FullPath))
        {
            Debug.Log(reader.ReadToEnd());
            reader.Close();
        }
    }
}
