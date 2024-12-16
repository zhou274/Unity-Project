using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MOSoft.ZigZag
{
    
    public class GameManager : MonoBehaviour
    {
        public Transform player;
        public Transform gameOverUI;
        public void restart()
        {
            SceneManager.LoadScene(1);
        }
        public void Close()
        {
            Application.Quit();
        }
        public void Continue()
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            gameOverUI.gameObject.SetActive(false);
            if(playerController.LastTile==null)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                player.position = playerController.lastPosition;
                player.GetComponent<Rigidbody>().isKinematic = false;
                playerController.isPlaying = true;
                playerController.isDead = false;
                playerController.direction = Vector3.zero;
                playerController.LastTile.position = playerController.LastTile.GetComponent<TileCollider>().startPosition;
                playerController.LastTile.GetComponent<Rigidbody>().isKinematic = true;
                playerController.LastTile.gameObject.SetActive(true);
            }
            
            
        }
    }
}
