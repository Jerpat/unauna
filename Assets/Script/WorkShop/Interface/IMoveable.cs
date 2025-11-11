using UnityEngine;

public interface IMoveable
{
    bool isMoving { get; set; }

    void StartMove(Transform target);

    void StopMove();

    void Move(Vector3 direction);
}
