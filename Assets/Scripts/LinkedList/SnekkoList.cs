using UnityEngine;

internal class SnekkoList
{
    internal Node head;
    internal int count = 0;

    internal Node GetLastNode(SnekkoList list)
    {
        Node temp = list.head;
        while(temp.next != null) temp = temp.next;
        return temp;
    }
    
    internal void InsertFront(SnekkoList list, Transform newSnakePart)
    {
        Node newNode = new Node(newSnakePart);
        newNode.next = list.head;
        newNode.prev = null;
        if(list.head != null) list.head.prev = newNode;
        list.head = newNode;
        count++;
    }

    internal void InsertLast(SnekkoList list, Transform newSnakePart)
    {
        Node newNode = new Node(newSnakePart);

        if(list.head == null)
        {
            newNode.prev = null;
            list.head = newNode;
            count = 1;
            return;
        }
        Node lastNode = GetLastNode(list);
        lastNode.next = newNode;
        newNode.prev = lastNode;

        count++;
    }
}
