using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : Unit
{
    private Unit output;

    private new void Start() {
        base.Start();
        energy -= 1.0f;
    }

    public void SetOutput(Unit output) {
        if (output) {
            this.output = output;
        }
    }

    public override void ProcessPacket() {
        if (!output) return;
        if (!output.IsFull()) {
            Packet packet = PopPacket();
            output.PushPacket(packet);
            packet.transform.SetParent(output.transform);
        }
    }
}
