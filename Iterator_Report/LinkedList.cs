using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator_Report
{
    public class LinkedListNode<T>     
    {
        internal LinkedList<T> list;        
        internal LinkedListNode<T> prev;     
        internal LinkedListNode<T> next;     
        public T Value;            

        public LinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.Value = value;
        }

        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.Value = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.Value = value;
        }

        public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Prev { get { return prev; } }      
        public LinkedListNode<T> Next { get { return next; } }
        public T Item { get { return Value; } set { Value = value; } }    

    }

    public class LinkedList<T> : IEnumerable<T> // 반복기 사용을 위해 추가관련 기능들만 구현
    {
        private LinkedListNode<T> head;     
        private LinkedListNode<T> tail;     
        private int count;                  

        public LinkedList()
        {
            this.head = null;              
            this.tail = null;
            count = 0;
        }

        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get { return tail; } }
        public int Count { get { return count; } }

        public LinkedListNode<T> AddFirst(T value) 
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            if (head != null)           
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            else                      
            {
                head = newNode;        
                tail = newNode;
            }
            count++;
            return newNode;

        }
       
        public LinkedListNode<T> AddLast(T value)
        {
           
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
            if (tail != null)        
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            else                       
            {
                head = newNode;        
                tail = newNode;
            }
            count++;
            return newNode;
        }
        //====================================================
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private LinkedList<T> linkedlist;
            private LinkedListNode<T> node;
            private T current;

            internal Enumerator(LinkedList<T> linkedlist)
            {
                this.linkedlist = linkedlist;
                this.node = linkedlist.head;            // 노드의 처음은 헤드이기에 헤드로 설정
                this.current = default(T);
            }

            public T Current { get { return current; } }

            object IEnumerator.Current { get { return current; } }

            public void Dispose() { }

            public bool MoveNext()
            {
                if (node != null)
                {
                    current = node.Item;                // 해당노드의 데이터값
                    node = node.next;                   // 다음 노드에 이동 리스트처럼 인덱스에 후위 연산자로 크기를 올려 이동하는 식이 아니라 다음노드에 연결된 다음데이터로 이동하는식임
                    return true;
                }
                else
                {
                    current = default(T);               // node가 null일 경우 대부분 마지막 기본값을 출력하게 설정
                    return false;
                }
            }

            public void Reset()
            {
                this.node = linkedlist.head;             // 리셋하면 배열에 처음 헤드로 이동
                current = default(T);
            }
        }
    }
}
