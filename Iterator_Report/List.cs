using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator_Report
{
    internal class List<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int size; // or count

        public List()
        {
            this.items = new T[DefaultCapacity];
            this.size = 0;
        }
        public int Capacity{ get { return items.Length; } }
        public int Count { get { return size; } }

        public T this[int index]        
        {
            get
            {
                if (index < 0 || index >= size)            
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }

        }
        public void Add(T item)     // 반복기 사용을 위해 추가기능 까지만 구현
        {
            if (size < items.Length)
            {
                items[size++] = item;
            }
            else
            {
                Grow();
                items[size++] = item;
            }
        }
        private void Grow()  
        {
            int newCapcity = items.Length * 2;          
            T[] newItems = new T[newCapcity];           
            Array.Copy(items, 0, newItems, 0, size);    
            items = newItems;                           
        }

        //======================================================
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
            private List<T> list;                        // 현재 리스트클래스의 리스트
            private int index;                           // 리스트의 인덱스
            private T current;                           // 이전에 대한 값을 저장하도록 설정

            internal Enumerator(List<T> list)            // 반복기의 초기화
            {
                this.list = list;
                this.index = 0;            
                this.current = default(T);
            }
            public T Current { get { return current; } }  // 출력값은 변경할수없도록 읽기 전용으로 설정

            object IEnumerator.Current                    // Current의 대해 예외처리 과정을 진행한다
            {
                get
                {
                    if (index < 0 || index >= list.Count) // 인덱스값이 음수이거나 크기에 벗어난 값일경우
                        throw new InvalidOperationException();
                    return Current;
                }
            }

            public bool MoveNext()                        // 다음 값으로 이동하는 기능으로 조건에 맞으면 true아니면 false의 논리형 bool를 사용한다 옆으로 이동한 값에 대한 판단만 하면된다
            {
                if (index < list.Count)         // 인덱스가 배열크기안에 있을경우
                {
                    current = list[index++];    // 반환해야될 값의 전껄반환 
                                                // 인덱스 값은 -1로 초기화 해서 시작 할수있지만 
                                                // 후위 연산자를 통해 0번부터 값을 출력할수있게 한다
                    return true;
                }
                else
                {
                    current = default(T);       // MoveNext가 크기 밖을 가르킬때 이전값을 반환하는 일을 막기위해 기본값을 출력하도록 설정
                    index = list.Count;
                    return false;
                }
            }

            public void Reset()                 // 반복 리셋기능
            {
                index = 0;
                current = default(T);
            }

            public void Dispose() { }           // 따로Disposeable에 있는 내용이라 별도로 빼서 설명함

        }
    }
}
