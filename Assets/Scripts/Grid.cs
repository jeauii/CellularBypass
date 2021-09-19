using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int width { get; }
    public int height { get; }

    private bool[,] areActive;
    private GameObject[,] units;

    public Grid(int width, int height) {
        this.width = width;
        this.height = height;
        areActive = new bool[width, height];
        units = new GameObject[width, height];
    }

    public bool IsValid(int hindex, int vindex) {
        return hindex >= 0 && hindex < width &&
            vindex >= 0 && vindex < height;
    }

    public bool IsActive(int hindex, int vindex) {
         return IsValid(hindex, vindex) &&
            areActive[hindex, vindex];
    }

    public void Expand(int hindex, int vindex) {
        if (IsValid(hindex, vindex)) {
            areActive[hindex, vindex] = true;
        }
    }

    public GameObject GetUnit(int hindex, int vindex) {
        return IsActive(hindex, vindex) ? 
            units[hindex, vindex] : null;
    }

    public bool AddUnit(int hindex, int vindex, GameObject unit) {
        if (IsActive(hindex, vindex)) {
            if (units[hindex, vindex] == null) {
                units[hindex, vindex] = unit;
                return true;
            }
        }
        return false;
    }

    public GameObject RemoveUnit(int hindex, int vindex) {
        if (IsActive(hindex, vindex)) {
            if (units[hindex, vindex] != null) {
                GameObject unit = units[hindex, vindex];
                units[hindex, vindex] = null;
                return unit;
            }
        }
        return null;
    }
}
