using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class life : MonoBehaviour
{
    Animator anim1;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim1 = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.tag == "death")
        {
            anim1.SetTrigger("death");
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
