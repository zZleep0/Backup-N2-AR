using UnityEngine;

public class BombaController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Caixa"))
        {
            Debug.Log("Bomba colidiu com a caixa");
            CarBehaviour car = GameObject.Find("aircraft-a(Clone)").GetComponent<CarBehaviour>();
            car.pontos += 25;

            car.qtdCaixas++;
            car.caixasTxt.text = "Caixas destruídas: " + car.qtdCaixas;

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
