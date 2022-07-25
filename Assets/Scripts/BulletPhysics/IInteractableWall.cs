using UnityEngine;

public interface IInteractableWall 
{
    public void Damage(Vector3 damagePos, float arriveTime);
}

public interface IWallInteractor<T> where T : IInteractableWall
{
    public void DetermineWall(T interactableWall, Vector3 damagePos, float arriveTime);
}
