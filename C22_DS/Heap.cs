using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C22_DS
{
    interface IHeap
    {
       void DisplayHeap();
    }
    public class MaxHeap : IHeap
    {
        private List<int> heap = new List<int>();


        public void Insert(int value)
        {

            heap.Add(value);
            HeapifyUp(heap.Count - 1);
        }
        private void HeapifyUp(int index)
        {


            while (index > 0)
            {

                int parentIndex = (index - 1) / 2;
                if (heap[index] <= heap[parentIndex]) break;
                (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);
                index = parentIndex;
            }
        }
        public int Peek()
        {

            if (heap.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }


            return heap[0];
        }


        public int ExtractMax()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }
            int maxValue = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            return maxValue;
        }
        public void HeapifyDown(int index)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int largestIndex = index;
            if (leftChildIndex < heap.Count && heap[leftChildIndex] > heap[largestIndex])
            {
                largestIndex = leftChildIndex;
            }
            if (rightChildIndex < heap.Count && heap[rightChildIndex] > heap[largestIndex])
            {
                largestIndex = rightChildIndex;
            }
            if (largestIndex != index)
            {
                (heap[index], heap[largestIndex]) = (heap[largestIndex], heap[index]);
                HeapifyDown(largestIndex);
            }
        }
        public void DisplayHeap()
        {
            Console.WriteLine("Heap elements:");
            foreach (var item in heap)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
    public class MinHeap : IHeap
    {
        private List<int> heap = new List<int>();
        public void Insert(int value)
        {
            heap.Add(value);
            HeapifyUp(heap.Count - 1);
        }
        public void HeapifyUp(int index) {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (heap[index] >= heap[parentIndex]) break;
                (heap[index], heap[parentIndex]) = (heap[parentIndex], heap[index]);
                index = parentIndex;
            }
        }
        public int Peek()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }
            return heap[0];
        }
        public int ExtractMin()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }
            int minValue = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            return minValue;
        }
        public void HeapifyDown(int index)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int smallestIndex = index;
            if (leftChildIndex < heap.Count && heap[leftChildIndex] < heap[smallestIndex])
            {
                smallestIndex = leftChildIndex;
            }
            if (rightChildIndex < heap.Count && heap[rightChildIndex] < heap[smallestIndex])
            {
                smallestIndex = rightChildIndex;
            }
            if (smallestIndex != index)
            {
                (heap[index], heap[smallestIndex]) = (heap[smallestIndex], heap[index]);
                HeapifyDown(smallestIndex);
            }
        }
        public void DisplayHeap()
        {
            Console.WriteLine("Heap elements:");
            foreach (var item in heap)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}