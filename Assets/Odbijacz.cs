using UnityEngine;

public class Odbijacz : MonoBehaviour
{
    public float odbicieSzybkosc = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 kierunek = (collision.transform.position - transform.position).normalized;

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = kierunek * odbicieSzybkosc;
        }
    }
}
