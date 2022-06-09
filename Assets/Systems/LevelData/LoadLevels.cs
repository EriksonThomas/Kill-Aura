using System.Collections.Generic;
using UnityEngine;
public class Level
{
    public int level;
    public int normal;
    public int elite;
    public int boss;
}
public class LoadLevels : MonoBehaviour
{
    public TextAsset leveldata;
    public List<Level> levels = new List<Level>();
    void Start()
    {
        string[] data = leveldata.text.Split(new char[] {'\n'});
        
        for(int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] {','});
            Level l = new Level();
            int.TryParse(row[0], out l.level);
            int.TryParse(row[1], out l.normal);
            int.TryParse(row[2], out l.elite);
            int.TryParse(row[3], out l.boss);
            levels.Add(l);
        }
    }
}