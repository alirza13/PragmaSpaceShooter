using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private MeshRenderer mesh;
    private Vector3 rotationAxis;
    public float rotationAngle = 1.5f;
    public float moveSpeed = 1.5f;
    public float minX = -2.65f, maxX = 2.65f, minY = -5.6f, maxY = 5.6f;

    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material = mesh.materials[Random.Range(0, mesh.materials.Length)];

        Vector3[] axisArray = new Vector3[2] { Vector3.forward, Vector3.back };
        rotationAxis = axisArray[Random.Range(0, axisArray.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
    }

    void Rotate()
    {
        transform.Rotate(rotationAxis, rotationAngle);
    }

    void Move()
    {
        Vector3 position = transform.position;
        position.y -= moveSpeed * Time.deltaTime;

        transform.position = position;
    }

    void CheckBounds()
    {

    }
}
