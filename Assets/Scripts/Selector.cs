using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Unit
{
    private Unit output0;
    private Unit output1;
    
    private Packet.Id[] receptors;

    private new void Start() {
        base.Start();
        energy -= 2.0f;
        receptors = new Packet.Id[6];
    }

    public void SetOutput(bool match, Unit output) {
        if (output) {
            if (match) output1 = output; else output0 = output;
        }
    }

    public void SetReceptor(int index, Packet.Id receptor) {
        if (index >= 0 && index < 6) {
            receptors[index] = receptor;
        }
    }

    public override void ProcessPacket() {
        Packet packet = TopPacket();
        Unit output = MatchesId(packet) ? output1 : output0;
        if (!output) return;
        if (!output.IsFull()) {
            PopPacket();
            output.PushPacket(packet);
            packet.transform.SetParent(output.transform);
        }
    }

    private bool MatchesId(Packet packet) {
        for (int i = 0; i < 6; ++i) {
            if (receptors[i] != Packet.Id.NULL) {
                if (receptors[i] != packet.GetId(i)) {
                    return false;
                }
            }
        }
        return true;
    }
}
