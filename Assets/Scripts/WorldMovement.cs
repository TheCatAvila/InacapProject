using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    private float startPositionZ; // Posición inicial en el eje Z

    // Start is called before the first frame update
    void Start()
    {
        // Guardar la posición inicial del objeto en Z
        startPositionZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // Mover el objeto hacia atrás en el eje Z
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        // Verificar si el objeto ha llegado a la posición Z = -80
        if (transform.position.z <= -80f)
        {
            // Teletransportar el objeto a la posición inicial (startPositionZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, startPositionZ);
        }
    }
}
