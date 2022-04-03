using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public Node<T>? LeftChild { get; set; }
        public Node<T>? RightChild { get; set; }

        public Node(T value, Node<T>? leftChild, Node<T>? rightChild)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public Node(T value)
        {
            Value = value;
        }

        public void SetLeftChild(Node<T> leftChild)
        {
            LeftChild = leftChild;
        }

        public void SetRightChild(Node<T> rightChild)
        {
            RightChild = rightChild;
        }
    }
}
