using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTreeLib
{
    /// <summary>
    /// Represents collection of binary search tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : IEnumerable<T>
    {
        #region Fields

        private TreeNode<T> root;
        private Comparer<T> comparer;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes default binary tree
        /// </summary>
        public BinaryTree()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes default binary tree with custom comparision
        /// <param name="comparison">custom comparision</param>
        /// </summary>
        public BinaryTree(Comparison<T> comparison)
        {
            Initialize(comparison: comparison);
        }

        /// <summary>
        /// Initializes default binary tree with custom comparer
        /// <param name="comparer">custom comparer</param>
        /// </summary>
        public BinaryTree(IComparer<T> comparer)
        {
            Initialize(comparer: comparer);
        }

        /// <summary>
        /// Initializes default binary tree by collection of items
        /// </summary>
        /// <param name="collection">collection of items</param>
        public BinaryTree(IEnumerable<T> collection)
        {
            Initialize(collection);
        }

        /// <summary>
        /// Initializes default binary tree with custom comparision by collection of items
        /// </summary>
        /// <param name="collection">collection of items</param>
        /// <param name="comparison">custom comparision</param>
        public BinaryTree(IEnumerable<T> collection, Comparison<T> comparison)
        {
            Initialize(collection, comparison);
        }

        /// <summary>
        /// Initializes default binary tree with custom comparer by collection of items
        /// </summary>
        /// <param name="collection">collection of items</param>
        /// <param name="comparer">custom comparer</param>
        public BinaryTree(IEnumerable<T> collection, IComparer<T> comparer)
        {
            Initialize(collection, comparer: comparer);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Inserts item into the tree
        /// </summary>
        /// <param name="item">item to be added</param>
        public void Insert(T item)
        {
            if (ReferenceEquals(item, null)) throw new ArgumentNullException("item", "item is null");
            Insert(new TreeNode<T>(item));
        }

        /// <summary>
        /// Checks if the item whithin binary tree
        /// </summary>
        /// <param name="item">item to be found</param>
        /// <returns>true, if binary tree contatins this item, otherwise false</returns>
        public bool Contains(T item)
        {
            if (ReferenceEquals(item, null)) throw new ArgumentNullException("item", "item is null");
            return !ReferenceEquals(Find(root, item), null);
        }

        /// <summary>
        /// Checks if the tree is empty
        /// </summary>
        /// <returns>true, if empty, otherwise false</returns>
        public bool IsEmpty()
        {
            return ReferenceEquals(root, null);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderIterator().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Works this way:
        /// Iteratore the LeftChild node by recursively calling the in-order function.
        ///Display the Data part of the root (or current node).
        ///Iteratore the RightChild node by recursively calling the in-order function.
        /// </summary>
        /// <returns>iterator</returns>
        public IEnumerable<T> InOrderIterator()
        {
            return InOrderIterator(root);
        }

        /// <summary>
        /// Works this way:
        /// Display the Data part of the root (or current node).
        /// Iteratore the LeftChild node by recursively calling the pre-order function.
        /// Iteratore the RightChild node by recursively calling the pre-order function.
        /// </summary>
        /// <returns>iterator</returns>
        public IEnumerable<T> PreOrderIterator()
        {
            return PreOrderIterator(root);
        }

        /// <summary>
        /// Works this way:
        /// Iteratore the LeftChild node by recursively calling the post-order function.
        ///Iteratore the RightChild node by recursively calling the post-order function.
        ///Display the Data part of the root (or current node).
        /// </summary>
        /// <returns>iterator</returns>
        public IEnumerable<T> PostOrderIterator()
        {
            return PostOrderIterator(root);
        }

        #endregion

        #region Private Methods

        private void Insert(TreeNode<T> node)
        {
            TreeNode<T> tempParent = null;
            var current = root;
            while (!ReferenceEquals(current, null))
            {
                tempParent = current;
                current = comparer.Compare(node.Item, current.Item) < 0 ? current.LeftChild : current.RightChild;
            }
            node.Parent = tempParent;
            if (ReferenceEquals(tempParent, null)) root = node;
            else {
                if (comparer.Compare(node.Item, tempParent.Item) < 0)
                    tempParent.LeftChild = node;
                else tempParent.RightChild = node;
            }
        }
        
        private TreeNode<T> Find(TreeNode<T> node, T item)
        {
            var current = node;
            while (!ReferenceEquals(current, null) && comparer.Compare(current.Item, item) != 0)
                current = comparer.Compare(item, current.Item) < 0 ? current.LeftChild : current.RightChild;
            return current;
        }

        private IEnumerable<T> PreOrderIterator(TreeNode<T> node)
        {
            yield return node.Item;
            if (!ReferenceEquals(node.LeftChild, null))
                foreach (var el in PreOrderIterator(node.LeftChild))
                    yield return el;
            if (!ReferenceEquals(node.RightChild, null))
                foreach (var el in PreOrderIterator(node.RightChild))
                    yield return el;
        }

        private IEnumerable<T> InOrderIterator(TreeNode<T> node)
        {
            if (!ReferenceEquals(node.LeftChild, null))
                foreach (var el in InOrderIterator(node.LeftChild))
                    yield return el;
            yield return node.Item;
            if (!ReferenceEquals(node.RightChild, null))
                foreach (var el in InOrderIterator(node.RightChild))
                    yield return el;
        }

        private IEnumerable<T> PostOrderIterator(TreeNode<T> node)
        {
            if (!ReferenceEquals(node.LeftChild, null))
                foreach (var el in PostOrderIterator(node.LeftChild))
                    yield return el;
            if (!ReferenceEquals(node.RightChild, null))
                foreach (var el in PostOrderIterator(node.RightChild))
                    yield return el;
            yield return node.Item;
        }

        private void Initialize(IEnumerable<T> collection = null, Comparison<T> comparison = null, IComparer<T> comparer = null)
        {
            if (ReferenceEquals(comparer, null) && ReferenceEquals(comparison, null) && !((IList) typeof (T).GetInterfaces()).Contains(typeof(IComparable<T>)))
                throw new ArgumentException("Type is not comparable");

            if (!ReferenceEquals(comparer, null))
                this.comparer = Comparer<T>.Create(comparer.Compare);
            if (!ReferenceEquals(comparison, null))
                this.comparer = Comparer<T>.Create(comparison);
            if (ReferenceEquals(this.comparer, null))
                this.comparer = Comparer<T>.Default;
            
            if (!ReferenceEquals(collection, null))
            {
                foreach (var item in collection)
                    Insert(item);
            }
        }

        #endregion
    }
}