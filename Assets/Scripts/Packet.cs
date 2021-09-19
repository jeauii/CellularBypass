using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packet : MonoBehaviour
{
    public enum Id { NULL, RED, YELLOW, CYAN, PURPLE }

    public float speed { get; private set; }
    public float energy { get; private set; }
    public bool virus { get; private set; }

    private Id[] identifiers;

    private void Start() {
        speed = 1.0f;
        energy = 1.0f;
        virus = false;
        identifiers = new Id[6];
    }

    private void Update() {

    }

    public Id GetId(int index) {
        if (index >= 0 && index < 6) {
            return identifiers[index];
        }
        return Id.NULL;
    }

    public void SetId(int index, Id id) {
        if (index >= 0 && index < 6) {
            identifiers[index] = id;
        }
    }

    public void Destroy() {
        Destroy(gameObject);
    }
}
