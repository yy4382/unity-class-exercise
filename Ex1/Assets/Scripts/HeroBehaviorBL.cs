using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviorBL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)) return;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 pos = transform.localPosition;
            if (pos.x > -50f && pos.y > -50f)
            {
                float s = Input.GetAxis("Vertical") * 0.1f;
                Vector3 size = new(s, s, s);
                transform.localScale += size;
                pos.x -= s * 10;
                pos.y -= s * 10;
                transform.localPosition = pos;

            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 pos = transform.localPosition;
            if (pos.x < -1f && pos.y < -1f)
            {
                float s = Input.GetAxis("Vertical") * 0.1f;
                Vector3 size = new(s, s, s);
                transform.localScale += size;
                pos.x -= s * 10;
                pos.y -= s * 10;
                transform.localPosition = pos;
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.localPosition = new Vector3(-1, -1, 0);
            }
        }
    }
}
