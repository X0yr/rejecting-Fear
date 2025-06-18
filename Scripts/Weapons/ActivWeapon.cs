using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivWeapon : MonoBehaviour
{

    public static ActivWeapon Instance { get; private set; }
    [SerializeField] private Sword sword;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        FollowMousePosition();
    }


    public Sword GetActivWeapon()
    {
        return sword;
    }

    private void FollowMousePosition()
    {
        Vector3 mousePos = GameInput.Instance.GetMousePosition();
        Vector3 playerPosition = Player.Instance.GetPlayerPosition();

        if (mousePos.x < playerPosition.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
