﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public PointsManager ptm;

    [SerializeField]
    private GameObject[] players; //serialize this so that you can add players from editor

    private Dictionary<GameObject, Vector3> positions = new Dictionary<GameObject, Vector3>();
    private Dictionary<GameObject, Quaternion> rotations = new Dictionary<GameObject, Quaternion>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject gO in players)
        {
            positions.Add(gO, gO.transform.position); //add it to dictionary
            rotations.Add(gO, gO.transform.rotation); //add it to dictionary
        }
    }


    public void EndRound()
    {
        ResetPositions();
        ptm.addOppositePoints(this.gameObject); //give points to players still in it
    }

    void ResetPositions()
    {
        foreach (GameObject gO in players)
        {
            gO.transform.position = positions[gO];
            gO.transform.rotation = rotations[gO];
        }
    }
}
