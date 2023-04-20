namespace Iterator_Report
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();

            for(int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            for (int i = 0; i <= 5; i++)
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



        }
    }
}