using UnityEngine;

public class InimigoController : MonoBehaviour
{
    public Transform target; // jogador
    public float radius = 2f;
    public float speed = 30f;

    private float angle = 0f;

    private void Start()
    {
        target = GameObject.Find("aircraft-a(Clone)").GetComponent<Transform>();
    }

    void Update()
    {
        angle += speed * Time.deltaTime;

        float rad = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius;

        transform.position = target.position + offset;
        transform.LookAt(target); // Faz o avião olhar para o jogador
    }
}
