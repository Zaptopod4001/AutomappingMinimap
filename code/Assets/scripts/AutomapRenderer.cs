using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public class AutomapRenderer : MonoBehaviour, IAutomapRenderer
    {

        [Header("View GridLayout")]
        public GridLayoutGroup grid;

        [Header("Sprites")]
        public GameObject tilePrefab;
        public List<Sprite> spriteTypes;
        public Sprite tilePlayer;
        public Sprite tileEmpty;

        // view
        Automap mapper;
        List<Image> mapImages;
        int width;
        int height;


        public void Init(Automap mapper)
        {
            this.mapper = mapper;
            this.width = mapper.Cells.GetLength(1);
            this.height = mapper.Cells.GetLength(0);

            // Tile size
            var rt = grid.transform as RectTransform;
            grid.cellSize = new Vector2(rt.rect.width / width, rt.rect.width / width);

            // Image count needed
            ClearOldTiles();
            CreateTiles();
            Render();
        }

        public void Render()
        {
            var count = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var pos = new Vector2Int(x, y);

                    // player 
                    if (mapper.PlayerPosition == pos)
                    {
                        mapImages[count].sprite = tilePlayer;
                    }

                    // walked
                    else if (mapper.Cells[y, x].mapped)
                    {
                        var kind = this.mapper.Cells[y, x].type;
                        mapImages[count].sprite = spriteTypes[kind];
                    }

                    // not walked
                    else if (!mapper.Cells[y, x].mapped)
                    {
                        mapImages[count].sprite = tileEmpty;
                    }

                    count++;
                }
            }
        }


        void CreateTiles()
        {
            int count = width * height;
            mapImages = new List<Image>();

            for (int i = 0; i < count; i++)
            {
                var clone = Instantiate(tilePrefab) as GameObject;
                var image = clone.GetComponent<Image>();

                mapImages.Add(image);
                clone.transform.SetParent(grid.transform, false);
            }
        }

        void ClearOldTiles()
        {
            foreach (Transform child in grid.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

    }


    interface IAutomapRenderer
    {
        void Init(Automap mapper);
        void Render();
    }

}

