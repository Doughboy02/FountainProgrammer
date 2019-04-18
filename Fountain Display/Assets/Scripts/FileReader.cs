
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class FileReader : MonoBehaviour
{
    public string path;
    FileSystemWatcher file;
    public Image Panel;

    private void Start()
    {
        //Reader = new StreamReader(path);
        Panel.GetComponent<Image>().color = new Color(25, 100, 134);
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
            
            //Debug.Log(reader.ReadToEnd());
            ChangeCubeColor(reader.ReadToEnd());
            reader.Close();
            print("test");
        }
    }

    private void ChangeCubeColor(string color)
    {
        //Color obj = JsonConvert.DeserializeObject<Color>(color);
        var img = Panel.GetComponent<Image>();
        img.color = new Color(25, 100, 134);
        //Panel.GetComponent<Image>().color = new Color(obj.r, obj.g, obj.b, obj.a);
        print("test");
    }
      
}
