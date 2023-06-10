using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilkManager : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public Vector2 positionCible;
    public Animator animator;
    public bool target;

    private void Update()
    {
        ForDeplacement();
    }
    public void InDeplacement(Vector2 nouvellePositionCible)
    {
        positionCible = nouvellePositionCible;
    }
    void ForDeplacement()
    {
        Vector2 direction = positionCible - (Vector2)transform.position;

        // Normalise la direction et multiplie par la vitesse
        Vector2 movement = direction.normalized * speed * Time.deltaTime;

        // Déplace l'objet dans la direction de la cible
        transform.Translate(movement, Space.World);

        //rotation en fonction de la direction
        Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, movement);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mantis"))
        {
            StartCoroutine(DestroyGameObject(collision.gameObject));
        }
    }

    private IEnumerator DestroyGameObject(GameObject player)
    {
        speed = 0;
        target = true;
        animator.SetTrigger("Touch");
        player.GetComponent<UnityManager>().life -= 1f;
        player.GetComponent<UnityManager>().Stuning();

        yield return new WaitForSeconds(1f);

        Destroy(this);
    }
}
