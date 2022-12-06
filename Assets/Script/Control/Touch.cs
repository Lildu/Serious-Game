using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

public class Touch : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    [SerializeField] private Transform MenuSwipe;

    private Vector2 MovDirection = Vector2.zero;


    private void Start()
    {
        foreach (WallMovable wall in Resources.FindObjectsOfTypeAll(typeof(WallMovable)) as WallMovable[])
        {
            wall.MoveWall();
        }

    }
    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    public void OnSwipe(string swipe)
    {
        Debug.Log(swipe);
        switch (swipe)
        {
            case "Left":
                CameraManager.SwitchCameraLeft();
                MovDirection = Vector2.left;
                break;
            case "Right":
                CameraManager.SwitchCameraRight();
                MovDirection = Vector2.right;
                break;
        }

        foreach (WallMovable wall in Resources.FindObjectsOfTypeAll(typeof(WallMovable)) as WallMovable[])
        {
            wall.MoveWall();
        }

    }


    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
    
}
