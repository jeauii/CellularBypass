using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Central : Unit
{
    private new void Start() {
        base.Start();
        energy -= 8.0f;
    }

    public override void ProcessPacket() {
        Packet packet = PopPacket();
        energy += packet.energy;
        packet.Destroy();
    }
}
