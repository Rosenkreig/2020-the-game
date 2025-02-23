﻿using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogError ("More than one BuildManager in scene.");
            return;
        }
        instance = this;
    }

    
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI NodeUI;
    
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; }}
    
    
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        NodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        NodeUI.Hide();
    }
    public void SelectTurretToBuild (TurretBlueprint turret) 
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
    
}
