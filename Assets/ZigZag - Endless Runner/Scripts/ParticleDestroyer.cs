using UnityEngine;
using System.Collections;

namespace MOSoft.ZigZag
{
    public class ParticleDestroyer : MonoBehaviour
    {
        private ParticleSystem ps;

        // Use this for initialization
        void Start()
        {
            ps = GetComponent<ParticleSystem>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!ps.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
