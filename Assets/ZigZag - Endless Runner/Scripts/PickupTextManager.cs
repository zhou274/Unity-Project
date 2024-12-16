using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MOSoft.ZigZag
{
    public class PickupTextManager : MonoBehaviour
    {
        public float speed;
        public Vector3 direction;
        public float fadeTime;

        public Transform cameraTransform;

        public GameObject pickupPrefab;
        public RectTransform canvasTransform;

        private static PickupTextManager instance;

        public static PickupTextManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<PickupTextManager>();
                }
                return instance;
            }
        }

        public void createText(Vector3 position, string text, Color color, bool isCriticalAnim)
        {
            GameObject go = (GameObject)Instantiate(pickupPrefab, position, Quaternion.identity);
            go.transform.SetParent(canvasTransform);
            go.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            go.GetComponent<PickupText>().initialize(speed, direction, fadeTime, isCriticalAnim);
            go.GetComponent<Text>().text = text;
            go.GetComponent<Text>().color = color;
        }
    }
}