using System;
using System.Collections.Generic;

namespace KPairSum
{
    public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
    {
        private (TElement, TPriority)[] heap = new (TElement, TPriority)[8];
        private int actualLength = 0;

        private IComparer<TPriority> comparer;

        public PriorityQueue(IComparer<TPriority> comparer = null) => this.comparer = comparer;

        public int Count => actualLength;

        public void Enqueue(TElement element, TPriority priority)
        {
            EnsureCapacity();
            heap[actualLength++] = (element, priority);
            BubbleUp();
        }

        public TElement Dequeue()
        {
            if (actualLength == 0)
            {
                throw new InvalidOperationException("Queue empty.");
            }

            var element = heap[0];
            Swap(0, --actualLength);
            BubbleDown();
            return element.Item1;
        }

        public IEnumerable<(TElement, TPriority)> UnorderedItems
        {
            get
            {
                (TElement, TPriority)[] items = new (TElement, TPriority)[actualLength];
                Array.Copy(heap, 0, items, 0, actualLength);
                return items;
            }
        }

        private void BubbleUp()
        {
            int elementPos = actualLength - 1;
            int parentPos;
            while ((parentPos = GetParentPos(elementPos)) != -1 && Compare(heap[parentPos].Item2, heap[elementPos].Item2) > 0)
            {
                Swap(parentPos, elementPos);
                elementPos = parentPos;
            }
        }

        private void BubbleDown()
        {
            int parentPos = 0;
            int leftChildPos = GetLeftChildPos(parentPos);
            int rightChildPos = GetRightChildPos(parentPos);

            while ((leftChildPos < actualLength && Compare(heap[parentPos].Item2, heap[leftChildPos].Item2) > 0)
                || (rightChildPos < actualLength && Compare(heap[parentPos].Item2, heap[rightChildPos].Item2) > 0))
            {
                int childToSwapPos = rightChildPos < actualLength
                    ? (Compare(heap[leftChildPos].Item2, heap[rightChildPos].Item2) < 0 ? leftChildPos : rightChildPos)
                    : leftChildPos;

                Swap(childToSwapPos, parentPos);
                parentPos = childToSwapPos;

                leftChildPos = GetLeftChildPos(parentPos);
                rightChildPos = GetRightChildPos(parentPos);
            }
        }

        private void Swap(int pos1, int pos2)
        {
            var temp = heap[pos1];
            heap[pos1] = heap[pos2];
            heap[pos2] = temp;
        }

        private int Compare(TPriority p1, TPriority p2)
        {
            return comparer != null ? comparer.Compare(p1, p2) : p1.CompareTo(p2);
        }

        private int GetLeftChildPos(int p)
        {
            return p * 2 + 1;
        }

        private int GetRightChildPos(int p)
        {
            return p * 2 + 2;
        }

        private int GetParentPos(int c)
        {
            return (c - 1) / 2;
        }

        private void EnsureCapacity()
        {
            if (heap.Length == actualLength)
            {
                // expand
                (TElement, TPriority)[] newHeap = new (TElement, TPriority)[heap.Length * 2];
                Array.Copy(heap, 0, newHeap, 0, heap.Length);
                heap = newHeap;
            }
        }
    }
}
