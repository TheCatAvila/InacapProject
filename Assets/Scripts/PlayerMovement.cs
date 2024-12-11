using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int team_amount = 1; // Número de jugadores inicial
    private Rigidbody rb;
    private List<GameObject> players = new List<GameObject>(); // Lista de objetos de jugadores

    public GameObject playerPrefab; // Prefab para representar a cada jugador
    public float playerSpacing = 2f; // Espacio entre los jugadores (en el eje X)

    void Start()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();

        // Llamar a SetTeamAmount para crear los jugadores al inicio
        SetTeamAmount();
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

        // Aplicar movimiento al objeto principal
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, rb.velocity.z);

        // Mover todos los jugadores (objetos) junto con el objeto principal
        MovePlayers();
    }

    void SetTeamAmount()
    {
        // Borramos los jugadores anteriores, si los hubiera
        foreach (var player in players)
        {
            Destroy(player); // Eliminar los objetos de jugadores previos
        }
        players.Clear();

        // Crear un número de objetos Player según el valor de team_amount
        for (int i = 0; i < team_amount; i++)
        {
            AddPlayer(i);
        }
    }

    void MovePlayers()
    {
        // Aquí nos aseguramos de mover todos los jugadores hijos junto con el objeto principal
        foreach (var player in players)
        {
            player.transform.position = transform.position + player.transform.localPosition;
        }
    }

    // Método para agregar un jugador dinámicamente
    public void AddPlayer(int index)
    {
        // Instanciar el prefab para cada jugador
        GameObject player = Instantiate(playerPrefab);

        // Hacer el jugador hijo del objeto principal
        player.transform.SetParent(transform);

        // Posicionar al jugador al costado del objeto principal (en el eje X)
        player.transform.localPosition = new Vector3(index * playerSpacing, 0f, 0f); // Ajustar la separación entre jugadores

        // Agregar a la lista de jugadores
        players.Add(player);
    }

    // Método para eliminar un jugador dinámicamente
    public void RemovePlayer(int index)
    {
        if (index >= 0 && index < players.Count)
        {
            // Eliminar el jugador de la lista y destruir el objeto
            Destroy(players[index]);
            players.RemoveAt(index);

            // Reorganizar las posiciones de los jugadores restantes
            RepositionPlayers();
        }
    }

    // Método para reorganizar las posiciones de los jugadores restantes después de eliminar uno
    void RepositionPlayers()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].transform.localPosition = new Vector3(i * playerSpacing, 0f, 0f);
        }
    }
}
