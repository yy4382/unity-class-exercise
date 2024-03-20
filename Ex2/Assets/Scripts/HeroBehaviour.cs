using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    public float speed = 20f;
    public bool mouseMode = true;
    public float lastSpawnTime = 0f;
    public GameManager gm = null;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(gm != null);
    }

    // Update is called once per frame
    void Update()
    {
        // rotate
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, 45f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -45f * Time.deltaTime);
        }


        // switch mode and speed
        if (Input.GetKeyDown(KeyCode.M))
        {
            mouseMode = !mouseMode;
            gm.ChangeMouseMode();
        }
        if (mouseMode)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;
        }
        else
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                speed += Input.GetAxis("Vertical") * 0.05f;
            }
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        // spawn egg
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time - lastSpawnTime > 0.2f)
            {
                lastSpawnTime = Time.time;
                GameObject bullet = Instantiate(Resources.Load("Prefabs/Egg"), transform.position, transform.rotation) as GameObject;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<PlaneBehaviour>().Touched();
        }
    }
}
