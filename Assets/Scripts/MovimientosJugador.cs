using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    private Vector2 entrada;

    public void OnMove(InputValue valor)
    {
        entrada = valor.Get<Vector2>();
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