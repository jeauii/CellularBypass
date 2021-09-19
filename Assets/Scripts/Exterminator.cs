using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exterminator : Unit
{
    private new void Start() {
        base.Start();
        energy -= 5.0f;
    }

    public override void ProcessPacket() {
        Packet packet = PopPacket();
        energy -= 1.0f;
        packet.Destroy();
    }
}
