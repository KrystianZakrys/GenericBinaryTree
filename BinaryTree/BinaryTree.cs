using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T> : Tree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; set; }

        public BinaryTree(List<T> values)
        {
            foreach (var value in values)
            {
                this.AddNode(value);
            }
        }       

        public void AddNode(T value)
        {
            Node<T>? before = null;
            Node<T>? after = this.Root;

            while(after != null)
            {
                before = after;
                if(value.CompareTo(after.Value) < 0)
                {
                    after = after.LeftChild;
                }
                else if (value.CompareTo(after.Value) > 0)
                {
                    after = after.RightChild;
                }
            }

            Node<T> newNode = new Node<T>(value);
            if(this.Root == null)
            {
                SetRoot(newNode);
            }
            else
            {
                if(value.CompareTo(before.Value) < 0)
                {
                    before.LeftChild = newNode;
                }
                else if(value.CompareTo(before.Value) > 0)
                {
                    before.RightChild = newNode;
                }                
            }
        }


        public Node<T>? FindByValue(T value)
        {
            return FindByValue(value, Root);
        }
        public Node<T>? FindByValue(T value, Node<T>? parent)
        {
            if (parent == null) { return null; }
            else
            {
                if(value.CompareTo(parent.Value) == 0)                 
                    return parent;                 
                else if(value.CompareTo(parent.Value) < 0)                
                    return FindByValue(value, parent.LeftChild);                
                else                
                    return FindByValue(value, parent.RightChild);                
            }
        }

        public T MinValue()
        {
            T min = this.Root.Value;
            Node<T> before = this.Root;
            
            while(before.LeftChild != null)
            {
                min = before.LeftChild.Value;
                before = before.LeftChild;
            }

            return min;
        }

        public T MinValueFromNode(Node<T> nodeFrom)
        {
            T min = nodeFrom.Value;
            Node<T> before = nodeFrom;

            while (before.LeftChild != null)
            {
                min = before.LeftChild.Value;
                before = before.LeftChild;
            }

            return min;
        }

        public int GetTreeDepth()
        {
            if (this.Root == null)
                return 0;

            return GetTreeDepth(this.Root);
        }

        public int GetTreeDepth(Node<T> parent)
        {
            return parent == null ?
               0 :
               Math.Max(GetTreeDepth(parent.LeftChild), 
               GetTreeDepth(parent.RightChild)) + 1;

        }

        public void TraversePreOrder(Node<T> parent)
        {
            if(parent != null)
            {
                Console.Write(parent.Value);
                TraversePreOrder(parent.LeftChild);
                TraversePreOrder(parent.RightChild);
            }
        }

        public void TraverseInOrder(Node<T> parent)
        {
            if(parent != null)
            {
                TraverseInOrder(parent.LeftChild);
                Console.Write(parent.Value);
                TraverseInOrder(parent.RightChild);
            }
        }

        public void TraversePostOrder(Node<T> parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.RightChild);
                TraversePostOrder(parent.LeftChild);
                Console.Write(parent.Value);
            }
        }

        public Node<T> GetRoot()
        {
            return this.Root;
        }

        public void SetRoot(Node<T> root)
        {
            this.Root = root;
        }

        //TODO: To be fixed.
        public void Remove(T value)
        {
            this.Root = RemoveNode(this.Root, value);
        }


        public Node<T> RemoveNode(Node<T> parent, T value)
        {
            if (parent == null) 
                return parent;

            if(value.CompareTo(parent.Value) < 0)
            {
                parent.LeftChild = RemoveNode(parent.LeftChild, value);
            }
            else if(value.CompareTo(parent.Value) > 0)
            {
                parent.RightChild = RemoveNode(parent.RightChild, value);
            }
            else
            {
                if(parent.LeftChild == null)
                {
                    return parent.RightChild;
                }
                else if(parent.RightChild == null)
                {
                    return parent.LeftChild;
                }

                parent.Value = MinValueFromNode(parent.RightChild);

                parent.SetRightChild(RemoveNode(parent.RightChild, parent.Value));
            }

            return parent;
        }       
    }
}
