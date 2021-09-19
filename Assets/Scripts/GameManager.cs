using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameDisplay display;

    public GameObject pcktSupply;

    public GameObject unitCentral;
    public GameObject unitSelector;
    public GameObject unitExtermintor;
    public GameObject unitJoint;

    private int size;
    private Grid grid;
    private Packet[] packets;
    
    void Start() {
        display = GetComponent<GameDisplay>();
        grid = new Grid(15, 9);
        display.SetDisplay(grid);
        size = 0;
        Spawn();

        Invoke("Test", 1);
    }
    
    void Update() {
        if (grid == null) {
            return;
        }

    }
    
    public void Spawn() {
        for (int i = 0; i < grid.width; ++i) {
            for (int j = 0; j < grid.height; ++j) {
                grid.Expand(i, j);
                ++size;
            }
        }
        Unit.energy = 24.0f;
        GameObject objCentral = Instantiate(unitCentral);
        grid.AddUnit(grid.width / 2, grid.height / 2, objCentral);
        GameObject objJoint = Instantiate(unitJoint);
        grid.AddUnit(grid.width / 2, grid.height / 2 + 1, objJoint);
        Joint joint = objJoint.GetComponent<Joint>();
        Unit unit = grid.GetUnit(grid.width / 2, grid.height / 2).GetComponent<Unit>();
        joint.SetOutput(unit);
        
    }
    GameObject temp;
    Packet old;
    public void Test() {
        GameObject objJoint = grid.GetUnit(grid.width / 2, grid.height / 2 + 1);
        Joint joint = objJoint.GetComponent<Joint>();
        GameObject pckt1 = Instantiate(pcktSupply);
        GameObject pckt2 = Instantiate(pcktSupply);
        pckt1.transform.SetParent(objJoint.transform);
        pckt2.transform.SetParent(objJoint.transform);
        joint.PushPacket(pckt1.GetComponent<Packet>());
        joint.PushPacket(pckt2.GetComponent<Packet>());
        temp = pckt1;
        old = pckt1.GetComponent<Packet>();
        Invoke("Log", 1);
    }
    public void Log() {
        Debug.Log("Log");
        Debug.Assert(old == temp.GetComponent<Packet>());
    }
}
