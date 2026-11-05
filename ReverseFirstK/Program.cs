using System.Collections;

namespace ReverseFirstK;

public class Program
{
     public static void Main(string[] args)
     {
     }

     /// <summary>
     /// Write a method void ReverseFirstK(Queue q, int k) that reverses the first k elements of the given queue. 
     /// You may only use stacks and queues (NOT deques) to do this. 
     /// </summary>
     /// <typeparam name="T"></typeparam>
     /// <param name="queue"></param>
     /// <param name="k"></param>
     /// <returns></returns>
     public static void ReverseFirstK<T>(Queue<T> queue, int k)
     {
          // if k > length, then just reverse the entire queue
          // if queue is null, throw an ArgumentNullException
          // if k < 0, throw an ArgumentException

          if(queue == null)
          {
               throw new ArgumentNullException();
          }
          if(k < 0)
          {
               throw new ArgumentException();
          }
          if(k > queue.Count)
          {
               k = queue.Count();
          }

          // 1) dequeue first k elements and push them on a stack
          
          Stack<T> stack = new Stack<T>();

          for(int i = 0; i < k; i++)
			{
                    T value = queue.Dequeue();
                    stack.Push(value);
			}

          // 2) pop elements from stack and enqueue on queue 
          
          while(stack.Count > 0)
          {
               T valueStack = stack.Pop();
               queue.Enqueue(valueStack);
          }

          // 3)  dequeue and enqueue q.length - k times
          
          int remaining = queue.Count - k;

          for(int i = 0; i < remaining; i++)
          {
               T valueDequeue = queue.Dequeue();
               queue.Enqueue(valueDequeue);
          }
     }
}

