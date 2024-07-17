using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    private SpriteRenderer sp;
    public Transform playerTransform;
    [SerializeField] private float orbitDistance = 1f;
    [SerializeField] private float orbitSpeed = 200f;
    [SerializeField] private float orbitAngle = 0f;
    [SerializeField] private float activeTime = 5f;
    [SerializeField] private float inactiveTime = 3f;
    private float timer = 0f;
    private bool isActive;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        if (playerTransform == null)
        {
            Debug.LogError("No se ha asignado un objeto objetivo para la órbita.");
            return;
        }
        transform.position = new Vector3(playerTransform.position.x + orbitDistance, playerTransform.position.y, playerTransform.position.z);
        isActive = true;
    }


    void Update()
    {

        if (isActive)
        {
            sp.enabled = true;
            timer += Time.deltaTime;
            if (timer > activeTime)
            {
                isActive = false;
                timer = 0f;
            }
        }
        else
        {
            sp.enabled = false;
            timer += Time.deltaTime;
            if (timer > inactiveTime)
            {
                isActive = true;
                timer = 0f;
            }
        }
        IncrementOrbitAngle();
    }
    void IncrementOrbitAngle()
    {
        orbitAngle += orbitSpeed * Time.deltaTime;

        // Calcular la nueva posición usando trigonometría
        float x = playerTransform.position.x + Mathf.Cos(orbitAngle * Mathf.Deg2Rad) * orbitDistance;
        float y = playerTransform.position.y + Mathf.Sin(orbitAngle * Mathf.Deg2Rad) * orbitDistance;

        // Actualizar la posición del objeto satélite
        transform.position = new Vector3(x, y, transform.position.z);
    }

}
