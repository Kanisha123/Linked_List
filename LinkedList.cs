using System;

namespace TestLibrary
{
  /// <summary>
  /// LinkedList - A class for creating and manipulating a doubly linked list of nodes containing generic data of type T.
  /// Assignment:     #1
  /// Course:         ADEV-3001
  /// Date Created:   September. 18, 2019
  /// 
  /// @author: Kanisha Patel
  /// @version 1.0
  /// </summary>
  internal class LinkedList<T> where T : IComparable<T> 
  {
    internal Node<T> Head { get; set; }
    internal Node<T> Tail { get; set; }
    internal int Size { get; set; }

    /// <summary>
    /// Constructor that initializes private field
    /// </summary>
    public LinkedList()
    {
      Size = 0;
      Head = null;
      Tail = null;
    }

    /// <summary>
    /// Method that returns node at the given position.
    /// </summary>
    private Node<T> GetPositionNode(int position)
    {
      if (Head == null || position <= 0 || position > Size)
      {
        throw new ApplicationException();
      }
      Node<T> current_Node = Head;
      int i = 1;
      while (i < position)
      {
        current_Node = current_Node.Next;
        i++;
      }
      return current_Node;
    }

    /// <summary>
    /// Method that returns the element in the head node.
    /// </summary>
    public T GetFirst()
    {
      if(IsEmpty())
      {
        throw new ApplicationException();
      }
      return Head.Element;
    }

    /// <summary>
    /// Method that set head node element to parameter value.
    /// </summary>
    public T SetFirst(T element)
    {
      if(IsEmpty())
      {
        throw new ApplicationException();
      }
      T oldElement = Head.Element;
      Head.Element = element;
      return oldElement;
    }

    /// <summary>
    /// Method that return the element in the tail node.
    /// </summary>
    public T GetLast()
    {
      if (IsEmpty())
      {
        throw new ApplicationException();
      }

      return Tail.Element;
    }

    /// <summary>
    /// Method that set tail node element to parameter value.
    /// </summary>
    public T SetLast(T element)
    {
      if (IsEmpty())
      {
        throw new ApplicationException();
      }
      T oldElement = Tail.Element;
      Tail.Element = element;
      return oldElement;
    }

    /// <summary>
    /// Method that adds new element to the tail of the list.
    /// </summary>
    public void AddLast(T element)
    {
      Node<T> objectNode = new Node<T>(element, Tail, null);
      if (IsEmpty())
      {
        Tail = objectNode;
        Head = Tail;
      }
      else
      {
        Tail.Next = objectNode;
      }
      Tail = objectNode;
      Size++;
    }

    /// <summary>
    /// Method that creates a new Node with the new element and adds it to the head of the list.
    /// </summary>
    public void AddFirst(T element)
    {
      Node<T> objectNode = new Node<T>(element, null, Head);
      if(IsEmpty())
      {
        Tail = objectNode;
      }
      else
      {
        Head.Previous = objectNode;
      }
      Head = objectNode;
      Size++;
    }

    /// <summary>
    /// Method that empty all elements from the list.
    /// </summary>
    public void Clear()
    {
      Head = null;
      Tail = null;
      Size = 0;
    }

    /// <summary>
    /// Method that return true if the list is empty, else return false.
    /// </summary>
    public bool IsEmpty() =>(Size == 0);

    /// <summary>
    /// Method that remove the head node.
    /// </summary>
    public T RemoveFirst()
    {
      if (IsEmpty())
      {
        throw new ApplicationException();
      }
      T oldHeadElement = Head.Element;
      if (Size == 1)
      {
        Head = null;
        Tail = null;
      }
      else
      {
        Head.Next.Previous = null;
        Head = Head.Next;
      }
      Size--;
      return oldHeadElement;
    }

    /// <summary>
    /// Method that remove the tail node.
    /// </summary>
    public T RemoveLast()
    {
      if (IsEmpty())
      {
        throw new ApplicationException();
      }
      T oldHeadElement = Tail.Element;
      if (Size == 1)
      {
        Head = null;
        Tail = null;
      }
      else
      {
        Tail = Tail.Previous;
        Tail.Next = null;
      }
      Size--;
      return oldHeadElement;
    }

    /// <summary>
    /// Method that return the element at the given position.
    /// </summary>
    public T Get(int position)
    {
      return GetPositionNode(position).Element;
    }

    /// <summary>
    /// Method that remove the node at the numeric position specified.
    /// </summary>
    public T Remove(int position)
    {
      T removedElement = default(T);
      if (Size == position)
      {
        removedElement = RemoveLast();
      }
      else if(position == 1)
      {
        removedElement = RemoveFirst();
      }
      else
      {

        Node<T> current_Node = GetPositionNode(position);
        removedElement = current_Node.Element;
        current_Node.Previous.Next = current_Node.Next;
        current_Node.Next.Previous = current_Node.Previous;
        Size--;
      }
      return removedElement;
    }

    /// <summary>
    /// Method that add new element after the node at the provided position.
    /// </summary>
    public void AddAfter(T element, int position)
    {
      if (Size == position)
      {
        AddLast(element);
      }
      else
      {
        Node<T> current_Node = GetPositionNode(position);
        Node<T> objectPrevious = current_Node;
        Node<T> objectNext = current_Node.Next;
        Node<T> objectNode = new Node<T>(element, objectPrevious, objectNext);
        current_Node.Next = objectNode;
        objectNext.Previous = objectNode;
        Size++;
      }
    }

    /// <summary>
    /// Method that add new element before the node at the provided position.
    /// </summary>
    public void AddBefore(T element, int position)
    {
      if (position == 1)
      {
        AddFirst(element);
      }
      else
      {
        Node<T> current_Node = GetPositionNode(position);
        Node<T> objectPrevious = current_Node.Previous;
        Node<T> objectNext = current_Node;
        Node<T> objectNode = new Node<T>(element, objectPrevious, objectNext);
        current_Node.Previous = objectNode;
        objectPrevious.Next = objectNode;
        Size++;
      }
    }

    /// <summary>
    /// Method that change specified node to element given in parameter.
    /// </summary>
    public T Set(T element, int position)
    {
      Node<T> current_Node = GetPositionNode(position);
      T replacedElement = current_Node.Element;
      
      current_Node.Element = element;
      
      return replacedElement;
    }

    /// <summary>
    /// Return the element in the node containing the element specified.
    /// </summary>
    public T Get(T element)
    {
      return GetElementNode(element).Element;
    }

    /// <summary>
    /// Return the node of the specified element.
    /// </summary>
    private Node<T> GetElementNode(T element)
    {
      if (IsEmpty())
      {
        throw new ApplicationException();
      }
      Node<T> current = Head;

      while (current != null && current.Element.CompareTo(element) != 0)
      {
        current = current.Next;
      }

      if (current == null)
      {
        throw new ApplicationException();
      }
      return current;
    }

    /// <summary>
    /// Add new element after the node containing the ‘oldelement’ specified.
    /// </summary>
    public void AddAfter(T element, T oldElement)
    {
      if (oldElement == default)
      {
        throw new ArgumentNullException();
      }
      Node<T> current_Node = GetElementNode(oldElement);
      if (current_Node.Next == null)
      {
        AddLast(element);
      }
      else
      {
        Node<T> objectPrevious = current_Node;
        Node<T> objectNext = current_Node.Next;
        Node<T> objectNode = new Node<T>(element, objectPrevious, objectNext);
        current_Node.Next = objectNode;
        objectNext.Previous = objectNode;
        Size++;
      }
    }

    /// <summary>
    /// Add new element before the node containing the ‘oldelement’ specified.
    /// </summary>
    public void AddBefore(T element, T oldElement)
    {
      if (oldElement == default)
      {
        throw new ArgumentNullException();
      }
      Node<T> current_Node = GetElementNode(oldElement);
      if (current_Node.Previous == null)
      {
        AddFirst(element);
      }
      else
      {
        Node<T> objectPrevious = current_Node.Previous;
        Node<T> objectNext = current_Node;
        Node<T> objectNode = new Node<T>(element, objectPrevious, objectNext);
        current_Node.Previous = objectNode;
        objectPrevious.Next = objectNode;
        Size++;
      }
    }

    /// <summary>
    /// Remove the node containing the element specified.
    /// </summary>
    public T Remove(T element)
    {
      Node<T> current_Node = GetElementNode(element);
      T removedElement = current_Node.Element;
      if (current_Node.Next == null)
      {
        RemoveLast();
      }
      else if (current_Node.Previous == null)
      {
        RemoveFirst();
      }
      else
      {
        current_Node.Previous.Next = current_Node.Next;
        current_Node.Next.Previous = current_Node.Previous;
        Size--;
      }
      return removedElement;
    }

    /// <summary>
    /// Change the element on the node containing the oldelement with the element passed and return the old element.
    /// </summary>
    public T Set(T element, T oldElement)
    {
      if (oldElement == default)
      {
        throw new ArgumentNullException();
      }
      Node<T> current_Node = GetElementNode(oldElement);
      T replacedElement = current_Node.Element;
      current_Node.Element = element;

      return replacedElement;
    }

    /// <summary>
    /// Add the element into the linked list in natural ascending order.
    /// </summary>
    internal void Insert(T element)
    {
        Node<T> temp = Head;

        while (temp != null && element.CompareTo(temp.Element) == 1)
        {
          temp = temp.Next;
        }

        if (temp == null)
        {
          AddLast(element);
        }
        else
        {
        // NOT use this... because ... it loops again
        if (temp.Previous == null)
        {
          AddFirst(element);
        }
        else
        {
          Node<T> objectPrevious = temp.Previous;
          Node<T> objectNode = new Node<T>(element, objectPrevious, temp);
          temp.Previous = objectNode;
          objectPrevious.Next = objectNode;
          Size++;
        }
        //AddBefore(element, temp.Element);
      }
      
    }

    /// <summary>
    /// Sort the elements into ascending order.
    /// </summary>
    internal void SortAscending()
    {
      LinkedList<T> sorted = new LinkedList<T>();

      Node<T> curr = Head;

      while (curr != null)
      {
        sorted.Insert(curr.Element);
        curr = curr.Next;
      }

      Head = sorted.Head;
      Tail = sorted.Tail;

    }
  }
}