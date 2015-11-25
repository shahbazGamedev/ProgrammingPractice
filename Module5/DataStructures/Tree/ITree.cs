using LinkedList;

namespace Tree
{
    public interface ITree<T>
    {
        LinkedList<T> BreadthFirstSearch();

        LinkedList<T> DepthFirstSearch();
    }
}

