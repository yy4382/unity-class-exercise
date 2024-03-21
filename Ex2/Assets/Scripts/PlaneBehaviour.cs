using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp = 4;
    private Renderer cRenderer;

    void Start()
    {
        cRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hit()
    {
        hp--;

        // Set renderer alpha to 20% * hp
        float alpha = 0.25f * hp;
        Color color = cRenderer.material.color;
        color.a = alpha;
        cRenderer.material.color = color;

        // Check if hp is zero or less
        if (hp <= 0)
        {
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            gm.EnemyKill();
            Destroy(gameObject);
        }
    }
    public void Touched()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.touchedEnemy++;
        gm.GenerateEnemy();
        Destroy(gameObject);
    }
}
