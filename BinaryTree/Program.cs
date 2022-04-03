

// See https://aka.ms/new-console-template for more information
using BinaryTree;
using System;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

var values = new List<int>() { 1, 2, 7, 3, 5, 10, 9 };
BinaryTree<int> tree = new BinaryTree<int>(values);

var node = tree.FindByValue(3);
int depth = tree.GetTreeDepth();

var root = tree.GetRoot();

Console.WriteLine(node?.Value.ToString() +' '+ depth);

Console.WriteLine("PreOrder Traversal:");
tree.TraversePreOrder(root);
Console.WriteLine();

Console.WriteLine("InOrder Traversal:");
tree.TraverseInOrder(root);
Console.WriteLine();

Console.WriteLine("PostOrder Traversal:");
tree.TraversePostOrder(root);
Console.WriteLine();

tree.Remove(7);
tree.Remove(2);

Console.WriteLine("PreOrder Traversal After Removing Operation:");
tree.TraversePreOrder(tree.GetRoot());
Console.WriteLine();

Console.ReadLine();