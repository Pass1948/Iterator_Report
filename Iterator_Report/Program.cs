namespace Iterator_Report
{
    internal class Program
    {
        /******************************************************
		 * 반복기 (Iterator)
		 * 
		 * 일반적으로 반복기(Iterator)란 다양하고 복잡한 컬렉션(or 자료구조)들의 구현방법과 상관없이
		 * 구조안의 각각에 요소(or 항목)에 접근하여 저장된 데이터들을 순회하는 과정(반복작업)을 가능하게 한다
		 * 반복기를 이용하여 반복작업 기능을 구현하는 방법을 행동디자인 패턴 or 반복기패턴이라 한다
		 * 
		 * 모든 구조에 호환이 가능하며 언어에 따라 그 역할들이 나뉘게 된다
		 * c++의 경우 다섯가지 반복자가 존재하는데 입력, 출력, 순방향, 양방향, 임의접근(연산)으로 
		 * 총 다섯가지 반복자가 가능한것에 비해 c#의 경우 출력과 순방향이 가능한 형태로 구현이 가능하다
		 * c#에서는 반복기가 여러 구조와 호환되는 특성때문에 기본적으로 인터페이스 형태로 구현되어있으면 
		 * 각각 구조를 반복작업이 가능하게 만들고 싶은때 반복기 인터페이스 불러와 그안에 기능을 만드는 구조에 맞게
		 * 구현을 해주는 방식으로 쓰이고 있다
		 * 
		 * 예를들어 연속 할당하는 List와 불연속 할당하는 LinkedList가 각각 데이터를 인덱스와 노드를
		 * 사용해서 할당하는데 이렇게 할당하는 방식, 단위 상관없이 오직 데이터에 접근이 가능하게 구현이 되며
		 * 배열안에 모든 요소에 접근하는 foreach문으로 반복이 가능하다
		 ******************************************************/
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();

            for(int i = 1; i <= 5; i++)
            {
                list.Add(i);
            }

          
            for (int i = 1; i <= 5; i++)
            {
                linkedList.AddLast(i);      // 데이터가 데이터의 뒤로 붙에 설정
            }

            Console.WriteLine("================List출력================");
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("================LinkedList출력================");
            foreach (int i in linkedList)
            {
                Console.WriteLine(i);
            }

            // Sort로 배열또는 리스트를 정렬하고 싶다면 매개변수에 IList<T>넣어서 사용하면 출력때 어느걸 사용하건 정령이 가능하게 된다
            // IList는 배열기반의 자료구조들을 다 담가고있음

        }

        // 밑에 있는 함수 두개는 c#기본으로 구현되어있음
        // 열거가능한 어떠한 자료구조든 평균값을 구할수있게 함수 구현
        public static double Average(IEnumerable<int> list) 
        {
            double sum = 0;
            int count = 0;
            foreach (int i in list)
            {
                sum += i;
                count++;
            }
            return sum / count;
        }

        // 어떠한 자료구조든 평균값을 구할수있게 함수 구현
        public static double Average(ICollection<int> list) 
        {
            double sum = 0;
            foreach (int i in list)
            {
                sum += i;
            }
            return sum / list.Count;
        } 
    }
}