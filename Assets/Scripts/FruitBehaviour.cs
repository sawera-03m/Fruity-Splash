using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehaviour : MonoBehaviour
{
    public GameObject fruitSliced;
    Rigidbody2D rb;
    public float startForce;

    // FIX: slice sound effect (assign Assets/Sounds/Slice.wav in Inspector)
    public AudioClip sliceSound;

    // FIX: neeche gir jaye to miss count karne ke liye
    bool hasBeenCounted = false;
    public float missYThreshold = -7f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    void Update()
    {
        // FIX: OnBecameInvisible() kabhi trigger nahi hota tha kyunki Renderer
        // is object pe nahi, child "GFX" object pe hai — Unity sirf usi
        // GameObject ko visibility message deta hai jispe Renderer laga ho.
        // Isliye ab position check kar rahe hain: jab fruit screen ke neeche
        // se guzar jaye (cut kiye bagair), to miss count hoga.
        if (!hasBeenCounted && transform.position.y < missYThreshold)
        {
            hasBeenCounted = true;
            if (GameManager.Instance != null)
                GameManager.Instance.LoseLife();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            hasBeenCounted = true; // taake Destroy hone se pehle Update() dobara miss count na kare

            Vector3 direction = (col.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            GameObject slicedFruit = Instantiate(fruitSliced, transform.position, rotation);
            Destroy(slicedFruit, 3f);

            // FIX: slice sound bajta hai
            if (sliceSound != null)
                AudioSource.PlayClipAtPoint(sliceSound, transform.position);

            // FIX: Fruit cut hone pe score add hota hai
            if (GameManager.Instance != null)
                GameManager.Instance.AddScore(1);

            Destroy(gameObject);
        }
    }
}
