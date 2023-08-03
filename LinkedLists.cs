using System.Collections;

namespace Leetcode150;

public class ListNode
{
   public int val;
   public ListNode next;
   public ListNode(int val=0, ListNode next=null) 
   {
       this.val = val;
       this.next = next;
   }   
}

public class LinkedLists
{
    public ListNode ReverseList(ListNode head)
    {
        var current = head;
        ListNode newList = null;

        while (current != null)
        {
            var next = current.next;
            current.next = newList;
            newList = current;
            current = next;
        }

        return newList;
    }
    
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode newListHead = new ListNode();
        var newList = newListHead;
        
        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                newList.next = list1;
                list1 = list1.next;
            }
            else
            {
                newList.next = list2;
                list2 = list2.next;
            }
            newList = newList.next;
        }

        if (list1 != null) newList.next = list1;
        else if (list2 != null) newList.next = list2;
        
        return newListHead.next;
    }

    public bool HasCycle(ListNode head)
    {
        var first = head;
        var second = head;
        while (first != null && second != null && second.next != null)
        {
            first = first.next;
            second = second.next.next;
            if (first == second) return true;
        }

        return false;
    }
}