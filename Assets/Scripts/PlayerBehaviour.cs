using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Map3();
    }

    //Map 3:
    public void Map3()
    {
        if (SceneManager.GetActiveScene().name == "Map 3")
        {
            Move3();
        }
    }

    public void Move3()
    {
        float speed = 5f;
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(horizontal, vertical, 0f) * Time.deltaTime;
        this.transform.position += movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("win"))
        {
            //some code
        }
    }
}
