using System;
namespace TestLibrary
{
  /// <summary>
  /// Node - A class that is the building block of several data structures including the linked list.
  /// Assignment:     #1
  /// Course:         ADEV-3001
  /// Date Created:   September. 18, 2019
  /// 
  /// @author: Kanisha Patel
  /// @version 1.0
  /// </summary>
  internal class Node<T>
  {
    internal T Element { get; set; }
    internal Node<T> Previous { get; set; }
    internal Node<T> Next { get; set; }

    /// <summary>
    /// constructor that takes an element, previousNode, nextNode and the default values for element, previousNode and nextNode is null.
    /// </summary>
    public Node(T element = default, Node<T> previousNode = null, Node<T> nextNode = null)
    {
      Element = element;
      Previous = previousNode;
      Next = nextNode;
    }

  }
}
