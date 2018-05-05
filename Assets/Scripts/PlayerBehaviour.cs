using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
    public float sensibilidade = 10, h, v;
    private float x, y;
    public GameObject alvo;
    public Transform linkPoint;
    private Vector2 pontoInicio;

    void Update()
    {
        //Movimentação W A S D
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        x = h * sensibilidade * Time.deltaTime;
        y = v * sensibilidade * Time.deltaTime;

        transform.Translate(x, y, 0);
    }

    void FixedUpdate()
    {
        pontoInicio.x = linkPoint.position.x;
        pontoInicio.y = linkPoint.position.y;
        RaycastHit2D hit = Physics2D.Raycast(pontoInicio, Vector2.up);

        if (hit.collider != null)
        {
            Debug.DrawLine(pontoInicio, hit.point); //exibir a linha do raycast
            if (hit.collider.tag == "Enemy")
            {
                alvo = hit.collider.gameObject;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Destroy(alvo);
                }
            }
        }
    }
}