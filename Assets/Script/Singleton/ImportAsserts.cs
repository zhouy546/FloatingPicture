using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ImportAsserts : MonoBehaviour {
    public static ImportAsserts instance;
    public List<Sprite> ScreenProtectImages = new List<Sprite>();

	// Use this for initialization
	void Start () {
		
	}

    public IEnumerator initialization() {
        if (instance == null) {
            instance = this;
        }

      yield return  StartCoroutine(LoadSeq("jpg", "/UITextures/ScreenProtect/", ScreenProtectImages));
    }

    IEnumerator LoadSeq(string format,string path, List<Sprite> sprites)
    {
        List<Texture> texturesList = new List<Texture>();
        string streamingPath = Application.streamingAssetsPath + path;

        DirectoryInfo dir = new DirectoryInfo(streamingPath);

        GetAllFiles(dir,format,path);

        double startTime = (double)Time.time;

        foreach (string de in jpgName)
        {
            WWW www = new WWW(Application.streamingAssetsPath + path + de);
            yield return www;
            if (www != null)
            {
                Texture texture = www.texture;
                texture.name = de;
                texturesList.Add(texture);
                startTime = (double)Time.time - startTime;
            }
            if (www.isDone)
            {
                www.Dispose();
            }
        }

        foreach (var texture in texturesList)
        {
            Sprite sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            sprite.name = texture.name;
            sprites.Add(sprite);
        }
    }

    List<string> jpgName = new List<string>();
    /// <summary>
    /// get all file
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="format: jpg, png"></param>
    public void GetAllFiles(DirectoryInfo dir,string format,string thePath)
    {
        FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();   //初始化一个FileSystemInfo类型的实例
        foreach (FileSystemInfo i in fileinfo)              //循环遍历fileinfo下的所有内容
        {
            if (i is DirectoryInfo)             //当在DirectoryInfo中存在i时
            {
                GetAllFiles((DirectoryInfo)i, format, thePath);  //获取i下的所有文件
            }
            else
            {
                string str = i.FullName;        //记录i的绝对路径
                string path = Application.streamingAssetsPath + thePath;
                string strType = str.Substring(path.Length);
                //               Debug.Log(strType);
                if (strType.Substring(strType.Length - 3).ToLower() == format)
                {
                    if (jpgName.Contains(strType))
                    {
                    }
                    else
                    {
                        //Debug.Log(strType);
                        jpgName.Add(strType);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
