using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// Velocidad de movimiento
	public float moveSpeed = 5f;

	// Referencia al Rigidbody del personaje
	private Rigidbody rb;

	void Start()
	{
		// Obtener el componente Rigidbody
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		// Velocidad inicial
		Vector3 velocity = Vector3.zero;

		// Detectar si se presiona la tecla "A" para mover a la izquierda
		if (Input.GetKey(KeyCode.A))
		{
			velocity = Vector3.left * moveSpeed;
		}

		// Detectar si se presiona la tecla "D" para mover a la derecha
		if (Input.GetKey(KeyCode.D))
		{
			velocity = Vector3.right * moveSpeed;
		}

		// Aplicar movimiento al Rigidbody
		rb.velocity = new Vector3(velocity.x, rb.velocity.y, rb.velocity.z);
	}
}
