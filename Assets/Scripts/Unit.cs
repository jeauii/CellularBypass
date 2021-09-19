using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public static int count { get; set; }
    public static float energy { get; set; }

    public int capacity { get; protected set; }

    protected Queue<Packet> packets;

    private float lastTime;
    private TextMesh textMesh;

    protected void Start() {
        capacity = 4;
        ++count;
        packets = new Queue<Packet>();
        DebugStart();
    }

    protected void Update() {
        if (packets.Count > 0) {
            Packet packet = packets.Peek();
            float currTime = Time.realtimeSinceStartup;
                //Debug.Log(packet.speed);
            if (packet.speed * (currTime - lastTime) > 1) {
                ProcessPacket();
                lastTime = currTime;
            }
        } else {
            lastTime = Time.realtimeSinceStartup;
        }
        energy -= count * 0.25f * Time.deltaTime;
        DebugUpdate();
    }

    public void DebugStart() {
        GameObject obj = new GameObject("Text", typeof(TextMesh));
        obj.transform.SetParent(transform);
        textMesh = obj.GetComponent<TextMesh>();
        textMesh.color = Color.black;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.fontSize = 64;
        textMesh.characterSize = 0.05f;
    }

    public void DebugUpdate() {
        textMesh.text = packets.Count.ToString();
    }

    public virtual void ProcessPacket() {
        Packet packet = PopPacket();
        packet.Destroy();
    }

    public bool IsFull() {
        return packets.Count >= capacity;
    }

    public void PushPacket(Packet packet) {
        if (packet) {
            packets.Enqueue(packet);
        }
    }

    public Packet TopPacket() {
        return packets.Peek();
    }

    public Packet PopPacket() {
        return packets.Dequeue();
    }
}
