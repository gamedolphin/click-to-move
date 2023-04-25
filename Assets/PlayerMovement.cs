using UnityEngine;
using Unity.Mathematics;
using System.Collections;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float minDistance = 1.0f;

    [SerializeField]
    private float rotateSpeed = 10.0f;

    [SerializeField]
    private float moveSpeed = 10.0f;

    [SerializeField]
    private float arriveDistance = 5f;

    [SerializeField]
    private Transform model;

    [SerializeField]
    private bool autoMove = false;

    private Vector2 currentTarget = Vector2.zero;

    private void Awake()
    {
        var input = GetComponent<PlayerInput>();
        input.OnPlayerClick += OnPlayerClick;

        currentTarget = transform.position;

        if (autoMove)
        {
            StartCoroutine(AutoMove());
        }
    }

    private IEnumerator AutoMove()
    {
        while(true)
        {
            currentTarget = new Vector2(UnityEngine.Random.Range(-10,10), UnityEngine.Random.Range(-5,5));
            yield return new WaitForSeconds(2);
        }
    }

    private void OnPlayerClick(Vector2 target)
    {
        currentTarget = target;
    }

    private void FixedUpdate()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        var currentTarget3D = new Vector3(currentTarget.x, currentTarget.y, transform.position.z);
        var diff = currentTarget3D - transform.position;
        var distance = diff.magnitude;

        if (distance < minDistance)
        {
            return;
        }

        var desired = diff.normalized;

        model.up = Vector3.RotateTowards(model.up, desired, rotateSpeed * Time.fixedDeltaTime, 0.0f);

        var maxSpeed = moveSpeed;

        if (distance < arriveDistance)
        {
            maxSpeed = math.remap(0,arriveDistance, 0, moveSpeed, distance);
        }

        transform.position += model.up.normalized * maxSpeed * Time.fixedDeltaTime;
        // transform.position = Vector2.Lerp(transform.position,
        //     currentTarget,
        //     moveSpeed * Time.fixedDeltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(currentTarget, 0.1f);
    }
}
