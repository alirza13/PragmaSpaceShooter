using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private MeshRenderer mesh;
    private Vector3 rotationAxis;
    public float rotationAngle = 1.5f;
    public float moveSpeed = 1.5f;

    void Awake()
    {
        RandomizeRotationAxis();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
    }

    public void RandomizeRotationAxis()
    {
        Vector3[] axisArray = new Vector3[2] { Vector3.forward, Vector3.back };
        rotationAxis = axisArray[Random.Range(0, axisArray.Length)];
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
}
