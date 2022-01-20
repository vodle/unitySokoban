using UnityEngine;
using UnityEngine.SceneManagement;
public class FinalPositionController : MonoBehaviour
{
    private static int gameScore = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(gameObject.tag))
        {
            gameScore++;
            gameObject.SetActive(false);
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            if (gameScore == gameObject.transform.parent.transform.childCount)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}