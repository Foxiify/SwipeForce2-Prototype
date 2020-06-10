using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDestroyed : MonoBehaviour
{
    public ObjectType objectType = ObjectType.Can;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Destroyer")
        {
            switch (objectType)
            {
                case ObjectType.Ball:
                    LevelManager.instance.SpawnBall();
                    break;
                case ObjectType.Can:
                    break;
            }
        }
    }
}
public enum ObjectType
{
    Ball,
    Can
}
