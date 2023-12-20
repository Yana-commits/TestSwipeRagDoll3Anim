using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 10;
    [SerializeField] private SimpleTouchPad touchPad;

    private Vector3 velocity;
    private GameSate gameSate = GameSate.Stop;

    public RagDollControl ragDollControl = null;
    public GameSate GameSate { get => gameSate; set => gameSate = value; }
    public Action<string> OnFall;

    private void Update()
    {
        if (GameSate == GameSate.Play)
        {
            Look();
            CheckPosition();
        }

    }
    private void FixedUpdate()
    {
        if (GameSate == GameSate.Play)
            Move(touchPad.GetDirection());

        else
            Move(Vector2.zero);
    }
    private void Look()
    {
        if (velocity != Vector3.zero)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, velocity, 10 * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    private void Move(Vector2 _direction)
    {
        velocity = new Vector3(_direction.x, 0f, _direction.y) * speed;

        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

        animator.SetFloat("Speed", velocity.magnitude);
    }
    private void CheckPosition()
    {
        var pos = this.gameObject.transform.position;
        if (pos.y < 0.1f || pos.x < -5.2 || pos.x > 5.2 || pos.z < -3.7 || pos.z > 11.7)
        {
            ragDollControl.MakePhysical(animator);
            OnFall?.Invoke("Невдахо!");
        }
    }
}
