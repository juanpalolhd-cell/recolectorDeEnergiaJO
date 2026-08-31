using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]
public class MovimientoJugador : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad = 5f;
    [Header("Salto y gravedad")]
    [SerializeField] private float alturaSalto = 1.5f;
    [SerializeField] private float gravedad = -9.81f;
    private Vector2 entrada;
    private CharacterController controlador;
    private float velocidadVertical;
    private bool saltoSolicitado;
    private void Awake()
    {
        controlador = GetComponent<CharacterController>();
    }
    public void OnMove(InputValue valor)
    {
        entrada = valor.Get<Vector2>();
    }
    public void OnJump(InputValue valor)
    {
        if (valor.isPressed)
            saltoSolicitado = true;
    }
    private void Update()
    {
        bool enSuelo = controlador.isGrounded;
        if (enSuelo && velocidadVertical < 0f)
            velocidadVertical = -2f;
        if (saltoSolicitado && enSuelo)
            velocidadVertical = Mathf.Sqrt(
            alturaSalto * -2f * gravedad
            );
        saltoSolicitado = false;
        velocidadVertical += gravedad * Time.deltaTime;
        Vector3 movimiento = new Vector3(
        entrada.x * velocidad,
        velocidadVertical,
        entrada.y * velocidad
        );
        controlador.Move(movimiento * Time.deltaTime);
    }
}

