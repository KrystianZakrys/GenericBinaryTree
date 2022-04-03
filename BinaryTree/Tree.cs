using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public interface Tree<T> where T : IComparable<T>
    {
        Node<T> GetRoot();
        void SetRoot(Node<T> root);
        void AddNode(T value);
        void Remove(T value);
        Node<T>? FindByValue(T value);
        T MinValue();
        int GetTreeDepth();      
    }
}
