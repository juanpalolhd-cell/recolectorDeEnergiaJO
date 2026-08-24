using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float fuerzaSalto = 5f; // Nueva variable para la fuerza

    private Vector2 entrada;
    private Rigidbody rb; // Referencia al componente de físicas 3D

    private void Start()
    {
            // Obtenemos el Rigidbody al iniciar el juego
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue valor)
    {
        entrada = valor.Get<Vector2>();
    }

    // Esta función se ejecuta automáticamente al presionar Espacio
    public void OnJump(InputValue valor)
    {
        // Aplicamos un impulso físico vertical hacia arriba
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
    }

    private void Update()
    {
        Vector3 direccion = new Vector3(entrada.x, 0f, entrada.y);
        transform.Translate(
            direccion * velocidad * Time.deltaTime,
            Space.World
        );
    }
}
