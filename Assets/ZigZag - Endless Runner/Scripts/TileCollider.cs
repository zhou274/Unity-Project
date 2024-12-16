using UnityEngine;
using System.Collections;

namespace MOSoft.ZigZag
{
    public class TileCollider : MonoBehaviour
    {
        private const float fallDelay = 0.75f;
        public Vector3 startPosition;
        
        void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                TileManager.Instance.spawnTile();
                //StartCoroutine(fallDown());
            }
        }

        IEnumerator fallDown()
        {
            yield return new WaitForSeconds(fallDelay);
            GetComponent<Rigidbody>().isKinematic = false;

            yield return new WaitForSeconds(fallDelay * 3);
            switch (gameObject.name)
            {
                case "leftTile":
                    gameObject.SetActive(false);
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    TileManager.Instance.getLeftTiles.Push(gameObject);
                    break;
                case "topTile":
                    gameObject.SetActive(false);
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    TileManager.Instance.getTopTiles.Push(gameObject);
                    break;
            }
        }

        // Use this for initialization
        void Start()
        {
            startPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}