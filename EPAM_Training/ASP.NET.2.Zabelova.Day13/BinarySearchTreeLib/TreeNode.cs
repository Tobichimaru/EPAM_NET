namespace BinarySearchTreeLib
{
    class TreeNode<T>
    {
        #region Constructors

        public TreeNode(T item, TreeNode<T> parent = null, TreeNode<T> left= null, TreeNode<T> rigth = null)
        {
            Item = item;
            Parent = parent;
            LeftChild = left;
            RightChild = rigth;
        }

        #endregion

        #region Properties

        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }
        public TreeNode<T> Parent { get; set; }
        public T Item { get; set; }

        #endregion
    }
}