using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public int speed;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Movement();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Walls")
            return;
        if (collision.gameObject.name == "Map Wall")
            return;
        Rigidbody collisionObject = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 velocityOfPlayer = gameObject.GetComponent<Rigidbody>().velocity;
        collisionObject.AddForce(velocityOfPlayer);
    }

    private void Movement()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;
    }
}