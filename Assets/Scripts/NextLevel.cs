using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("PlayerTag"))
        {
            if(SceneManager.GetActiveScene().buildIndex==1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
            else
            {
                GameObject winScreen = GameObject.Find("Canvas").transform.Find("You Win").gameObject;
                winScreen.SetActive(true);
            }
        }
    }
}
