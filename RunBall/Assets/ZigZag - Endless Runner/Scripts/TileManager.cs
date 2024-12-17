using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MOSoft.ZigZag
{
    public class TileManager : MonoBehaviour
    {
        public GameObject currentTile;

        public GameObject[] tilePrefabs;

        private Stack<GameObject> leftTiles = new Stack<GameObject>();
        private Stack<GameObject> topTiles = new Stack<GameObject>();

        private static TileManager instance;

        public static TileManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<TileManager>();
                }
                return instance;
            }
        }

        void Start()
        {
            createTiles(100);

            for (int i = 0; i < 50; i++)
            {
                spawnTile();
            }
        }

        public void spawnTile()
        {
            if (leftTiles.Count == 0 || topTiles.Count == 0)
            {
                createTiles(10);
            }
            int randomIndex = Random.Range(0, tilePrefabs.Length);
            if (randomIndex == 0)
            {
                GameObject tmp = leftTiles.Pop();
                tmp.SetActive(true);
                tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
                currentTile = tmp;
            }
            else if (randomIndex == 1)
            {
                GameObject tmp = topTiles.Pop();
                tmp.SetActive(true);
                tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
                currentTile = tmp;
            }
            int spawnPickup = Random.Range(0, 10);
            if (spawnPickup == 0)
            {
                currentTile.transform.GetChild(1).gameObject.SetActive(true);
            }
        }

        public void createTiles(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject go = Instantiate(tilePrefabs[0]);
                go.name = "leftTile";
                go.SetActive(false);
                leftTiles.Push(go);

                go = Instantiate(tilePrefabs[1]);
                go.name = "topTile";
                go.SetActive(false);
                topTiles.Push(go);
            }
        }

        public Stack<GameObject> getLeftTiles
        {
            get
            {
                return leftTiles;
            }

            set
            {
                leftTiles = value;
            }
        }

        public Stack<GameObject> getTopTiles
        {
            get
            {
                return topTiles;
            }

            set
            {
                topTiles = value;
            }
        }
    }
}