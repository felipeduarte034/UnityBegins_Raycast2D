using UnityEngine;
using System.Collections;

public class PlayerBehaviourPlus : MonoBehaviour
{
    public float sensibilidade = 10, h, v;
    private float x, y;
    public GameObject alvo;
    public Transform begin;
    private Vector2 pontoInicio;
    private Vector2 directionLook;
    private Vector2 directionRay;
    public Vector3 mousePosition;

    void Update()
    {
        //Movimentação W A S D
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        x = h * sensibilidade * Time.deltaTime;
        y = v * sensibilidade * Time.deltaTime;
        transform.Translate(x, y, 0);

        //Rotação com o mouse - olhar para o mouse
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        directionLook.x = mousePosition.x - transform.position.x;
        directionLook.y = mousePosition.y - transform.position.y;
        transform.up = directionLook;
    }

    void FixedUpdate()
    {
        pontoInicio.x = begin.position.x;
        pontoInicio.y = begin.position.y;

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //Posição do mouse em relação a Camera
        directionRay.x = mousePosition.x - transform.position.x;
        directionRay.y = mousePosition.y - transform.position.y; //Direção, dada por um vetor (Geometria Analitica - Vetores)

        RaycastHit2D hit = Physics2D.Raycast(pontoInicio, directionRay);

        if (hit.collider != null)
        {
            Debug.DrawLine(pontoInicio, hit.point);
            
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