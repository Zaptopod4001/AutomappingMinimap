using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Eses.AutoMapper
{

    // Copyright 
    // Created by Sami S. 

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.

    // WHY?
    // This piece of code is here only to show my coding skills

    public class Save
    {

        // save path (NOTE: in project/Assets folder)
        public static string path = Application.dataPath + "/save/level0-minimap.sav";


        // Save / load mapdata

        public static void SaveMinimap(Cell[,] miniMap)
        {
            Serialize<Cell[,]>(miniMap, path);
        }

        public static Cell[,] LoadMinimap()
        {
            Cell[,] map = Deserialize<Cell[,]>(path);

            if (map != null)
            {
                return map;
            }

            return null;
        }



        // Generic de/serializers

        static void Serialize<T>(T data, string path)
        {
            var dir = Path.GetDirectoryName(path);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            FileStream file = File.Create(path);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(file, data);
            file.Close();

            Debug.Log("Saved file");
        }

        static T Deserialize<T>(string path)
        {
            T data = default(T);

            if (File.Exists(path))
            {
                FileStream file = File.Open(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();

                data = (T)bf.Deserialize(file);
                file.Close();
                Debug.Log("Loaded file");
            }
            else
            {
                Debug.LogError("No file to load!");
            }

            return data;
        }

    }

}