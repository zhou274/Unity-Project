using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MOSoft.ZigZag
{
    public class PlayerController : MonoBehaviour
    {
        public bool isDead;
        public float speed;

        public Vector3 lastDirection;
        public Vector3 direction;

        public GameObject particleSys;
        public Animator gameOverAnimator;

        public Text newHighScore;
        public Image background;

        private int score = 0;
        public Text scoreInGameText;

        public Text[] scoreTexts;

        public LayerMask whatisGround;
        public bool isPlaying = false;
        public Transform contactPoint;
        //todo
        public Vector3 lastPosition;
        public Transform LastTile;

        void Start()
        {
            isDead = false;
            direction = Vector3.zero;
            //PlayerPrefs.DeleteAll();
        }

        private bool isGrounded()
        {
            Collider[] colliders = Physics.OverlapSphere(contactPoint.position, .5f, whatisGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    return true;
                }
            }

            return false;
        }


        void Update()
        {
            
            if (!isGrounded() && isPlaying)
            {
                isPlaying = false;
                isDead = true;
                gameOver();
                Camera.main.transform.parent = null;
            }
            if(isGrounded() && isPlaying)
            {
                Camera.main.transform.parent = transform;
            }
            if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !isDead)
            {
                isPlaying = true;
                score++;
                scoreInGameText.text = score.ToString();
                lastDirection = direction;
                if (direction == Vector3.forward)
                {
                    direction = Vector3.left;
                }
                else
                {
                    direction = Vector3.forward;
                }
            }

            float amountToMove = speed * Time.deltaTime;
            transform.Translate(direction * amountToMove);

            //test pickup text message
            if (Input.GetKeyDown(KeyCode.T))
            {
                PickupTextManager.Instance.createText(transform.position, "+3", new Color32(255, 4, 238, 255), false);
            }
            //critical test pickup text message
            if (Input.GetKeyDown(KeyCode.C))
            {
                PickupTextManager.Instance.createText(transform.position, "-3", Color.red, true);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Pickup")
            {
                other.gameObject.SetActive(false);
                Instantiate(particleSys, transform.position, Quaternion.identity);
                score += 3;
                scoreInGameText.text = score.ToString();
                PickupTextManager.Instance.createText(other.transform.position, "+3", new Color32(255, 4, 238, 255), false);

            }
            //todo
            if(other.tag=="Tile")
            {
                LastTile = other.gameObject.transform;
                lastPosition = LastTile.Find("BornPoint").position;
                //lastPosition = other.gameObject.transform.Find("BornPoint").position;
            }
        }

        private void gameOver()
        {
            
            direction = Vector3.zero;
            gameOverAnimator.gameObject.SetActive(true);
            gameOverAnimator.SetTrigger("GameOver");
            scoreTexts[1].text = score.ToString();
            int bestScore = PlayerPrefs.GetInt("bestScore", 0);
            if (score > bestScore)
            {
                PlayerPrefs.SetInt("bestScore", score);
                newHighScore.gameObject.SetActive(true);
                background.color = new Color32(255, 118, 246, 255);
                foreach (Text text in scoreTexts)
                {
                    text.color = Color.white;
                }
            }
            scoreTexts[3].text = PlayerPrefs.GetInt("bestScore", 0).ToString();            
        }
    }
}