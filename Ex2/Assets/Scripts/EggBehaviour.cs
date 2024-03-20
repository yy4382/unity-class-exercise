using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EggBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm = null;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.eggOnScreen++;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(40f * Time.deltaTime * Vector3.up);
        CameraSupport s = Camera.main.GetComponent<CameraSupport>();
        if (s == null) return;
        CameraSupport.WorldBoundStatus status = s.CollideWorldBound(GetComponent<Renderer>().bounds);
        if (status != CameraSupport.WorldBoundStatus.Inside)
        {
            gm.eggOnScreen--;
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<PlaneBehaviour>().Hit();
            gm.eggOnScreen--;
            Destroy(gameObject);
        }
    }
}
