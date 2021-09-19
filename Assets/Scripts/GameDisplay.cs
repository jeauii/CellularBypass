using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDisplay : MonoBehaviour
{
    public float scale;
    public Vector3 offset;

    private Grid grid;
    private Packet[] packets;
    
    void Start() {

    }
    
    void Update() {
        if (grid == null) {
            return;
        }
        for (int i = 0; i < grid.width; ++i) {
            for (int j = 0; j < grid.height; ++j) {
                if (grid.IsActive(i, j)) {
                    GameObject unit = grid.GetUnit(i, j);
                    if (unit) {
                        unit.transform.position = GetPosition(i, j);
                    }
                }
            }
        }
        for (int i = 0; i < grid.width; ++i) {
            for (int j = 0; j < grid.height; ++j) {
                if (grid.IsActive(i, j)) {
                    Vector3 apos = GetPosition(i, j);
                    if (grid.IsActive(i + 1, j) &&
                        grid.IsActive(i, j + 1)) {
                        Vector3 bpos = GetPosition(i + 1, j);
                        Vector3 cpos = GetPosition(i, j + 1);
                        Debug.DrawLine(apos, bpos, Color.black, Time.deltaTime);
                        Debug.DrawLine(bpos, cpos, Color.black, Time.deltaTime);
                        Debug.DrawLine(cpos, apos, Color.black, Time.deltaTime);
                    }
                    if (grid.IsActive(i + 1, j) &&
                        grid.IsActive(i + 1, j - 1)) {
                        Vector3 bpos = GetPosition(i + 1, j);
                        Vector3 cpos = GetPosition(i + 1, j - 1);
                        Debug.DrawLine(apos, bpos, Color.black, Time.deltaTime);
                        Debug.DrawLine(bpos, cpos, Color.black, Time.deltaTime);
                        Debug.DrawLine(cpos, apos, Color.black, Time.deltaTime);
                    }

                }
            }
        }
    }

    public void SetDisplay(Grid grid) {
        this.grid = grid;
    }

    public Vector3 GetPosition(int hindex, int vindex) {
        int hdelta = hindex - grid.width / 2;
        int vdelta = vindex - grid.height / 2;
        float xpos = (hdelta + vdelta * 0.5f) * scale;
        float ypos = (vdelta * 0.5f * Mathf.Sqrt(3f)) * scale;
        Vector3 pos = new Vector3(xpos, ypos);
        return pos + offset;
    }
}
