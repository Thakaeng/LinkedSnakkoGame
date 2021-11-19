using UnityEngine;

internal class Node
{
    internal Transform snakePart;
    internal Vector3 lastPosition;
    internal Node prev;
    internal Node next;

    public Node(Transform sp)
    {
        snakePart = sp;
        prev = null;
        next = null;
    }
}