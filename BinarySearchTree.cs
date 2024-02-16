public class BST<E> where E : IComparable<E> {
    public class Node<E> {
        public Node<E> left;
        public Node<E> right;
        public E value;

        public Node(E value, Node<E> left, Node<E> right) {
            this.value = value;
            this.left = left;
            this.right = right;
        }
    }

    private Node<E> root;

    public BST() {
        root = null;
    }

    public void preOrder(Action<E> doIt) {
        preOrder(root, doIt);
    }

    private void preOrder(Node<E> subroot, Action<E> doIt) {
        if (subroot != null) {
            doIt(subroot.value);
            preOrder(subroot.left, doIt);
            preOrder(subroot.right, doIt);
        }
    }

    public void inOrder(Action<E> doIt) {
        inOrder(root, doIt);
    }

    private void inOrder(Node<E> subroot, Action<E> doIt) {
        if (subroot != null) {
            inOrder(subroot.left, doIt);
            doIt(subroot.value);
            inOrder(subroot.right, doIt);
        }
    }

    public void postOrder(Action<E> doIt) {
        postOrder(root, doIt);
    }

    private void postOrder(Node<E> subroot, Action<E> doIt) {
        if (subroot != null) {
            postOrder(subroot.left, doIt);
            postOrder(subroot.right, doIt);
            doIt(subroot.value);
        }
    }

    public bool isEmpty() {
        return root == null;
    }

    public bool add(E element) {
        bool added = false;
        if (isEmpty()) {
            root = new Node<E>(element, null, null);
            added = true;
        } else {
            added = add(root, element);
        }
        return added;
    }

    private bool add(Node<E> subroot, E element) {
        bool added = false;
        int compare = subroot.value.CompareTo(element);
        if (compare < 0) {
           if (subroot.right == null) {
               subroot.right = new Node<E>(element, null, null);
           } else {
               added = add(subroot.right, element);
           }
        } else if (compare > 0) {
            if (subroot.left == null) {
                subroot.left = new Node<E>(element, null, null);
            } else {
                added = add(subroot.left, element);
            }
        }
        return added;
    }

    public bool contains(E target) {
        return contains(root, target);
    }

    private bool contains(Node<E> subroot, E target) {
        bool found = false;
        int compare;
        if (subroot != null) {
            compare = subroot.value.CompareTo(target);
            if (compare == 0) {
                found = true;
            } else if (compare < 0) {
                found = contains(subroot.right, target);
            } else {
                found = contains(subroot.left, target);
            }
        }
        return found;
    }

    public int height() {
        return height(root);
    }

    private int height(Node<E> subroot) {
        int count = 0;
        if (subroot != null) {
            count = 1 + Math.Max(height(subroot.left), height(subroot.right));
        }
        return count;
    }

    public int size() {
        return size(root);
    }

    private int size(Node<E> subroot) {
        int count = 0;
        if (subroot != null) {
            count = 1 + size(subroot.left) + size(subroot.right);
        }
        return count;
    }

}