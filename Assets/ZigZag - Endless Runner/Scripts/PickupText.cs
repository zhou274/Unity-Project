using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MOSoft.ZigZag
{
    public class PickupText : MonoBehaviour
    {
        private float speed;
        private Vector3 direction;
        private float fadeTime;
        public AnimationClip critAnim;
        private bool isCriticalAnim;

        // Update is called once per frame
        void Update()
        {
            if (!isCriticalAnim)
            {
                float translation = speed * Time.deltaTime;
                transform.Translate(direction * translation);
            }
        }

        public void Start()
        {
            transform.LookAt(2 * transform.position - PickupTextManager.Instance.cameraTransform.position);
        }

        public void initialize(float speed, Vector3 direction, float fadeTime, bool isCriticalAnim)
        {
            this.speed = speed;
            this.direction = direction;
            this.fadeTime = fadeTime;
            this.isCriticalAnim = isCriticalAnim;

            if (isCriticalAnim)
            {
                //GetComponent<Animator>().SetTrigger("Critical");
                StartCoroutine(critical());
            }
            else
            {
                StartCoroutine(fadeOut());
            }
        }

        private IEnumerator critical()
        {
            yield return new WaitForSeconds(critAnim.length);
            isCriticalAnim = false;
            StartCoroutine(fadeOut());
        }

        private IEnumerator fadeOut()
        {
            float startAlpha = GetComponent<Text>().color.a;
            float rate = 1.0f / fadeTime;
            float progress = 0.0f;
            while (progress < 1.0)
            {
                Color tmpColor = GetComponent<Text>().color;
                GetComponent<Text>().color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, Mathf.Lerp(startAlpha, 0, progress));
                progress += rate * Time.deltaTime;
                yield return null;
            }
            Destroy(gameObject);
        }
    }
}