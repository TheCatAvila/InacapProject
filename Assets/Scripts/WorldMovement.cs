using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    private float startPositionZ; // Posici�n inicial en el eje Z

    // Start is called before the first frame update
    void Start()
    {
        // Guardar la posici�n inicial del objeto en Z
        startPositionZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // Mover el objeto hacia atr�s en el eje Z
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // Verificar si el objeto ha llegado a la posici�n Z = -80
        if (transform.position.z <= -80f)
        {
            // Teletransportar el objeto a la posici�n inicial (startPositionZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, startPositionZ);
        }
    }
}
