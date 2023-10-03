using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private CircleCollider2D detectionCollider; // Collider de detección del enemigo.
    [SerializeField] private float moveSpeed = 3f; // Velocidad de movimiento del enemigo.
    [SerializeField] private Transform initialPosition; // Posición inicial del enemigo.
    private Transform player; // Referencia al jugador.

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Asegúrate de que el jugador tenga el tag "Player".
    }

    private void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador.
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (detectionCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            // El enemigo está dentro del área de detección, persigue al jugador.
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
        else
        {
            // El enemigo está fuera del área de detección, regresa a su posición inicial.
            Vector3 direction = (initialPosition.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}


