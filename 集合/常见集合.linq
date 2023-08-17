<Query Kind="Program" />

void Main()
{
	// 1、Array集合，包含相同数据类型的元素集合，在创建时需要指定长度并且不可改变
	int[] numbers = new int[2] { 1, 2 };
	int[] numbers1 = { 1,2 };
	// 这里是使用linq的Append方法重新赋值
	numbers1=numbers1.Append(3).ToArray();  
	numbers1.Dump();

	// 2、List列表是1种动态数据，长度可以在运行时添加和删除元素
	List<int> list = new List<int> { 1,2,3 };
	list.Add(4);
	list.Dump();

	// 3、Dictionary字典集合是一种键值对的集合，每个键关联1个值，字段可以按键或值排序
	Dictionary<string, int> dic = new Dictionary<string, int>
	{
		{ "apple",1 },
		{ "banana",2 },
		{ "orange",3 }
	};
	dic.Add("new",4);
	dic.Dump();

	// 4、HashSet集合是一组不包含重复元素的对象集合,类型也是固定的
	HashSet<int> hashSet = new HashSet<int> { 1,2,2,3 };
	// 重复的元素不会输出,会自动被集合过滤掉
	foreach (var item in hashSet)
	{
		Console.WriteLine(item);		
	}
	hashSet.Dump();
	
	// 5、Stack栈是一种后进先出的数据结构，类似于一个子弹的弹匣
	Stack<string> stack=new Stack<string>();
	stack.Push("apple");
	stack.Push("banana");
	stack.Push("orange");
	// 这里获取第一个会取到 最后一个添加的值orange
	Console.WriteLine(stack.Peek()); 
	
	// 6、Queue队列是一种先进先出的数据结构，类似于排队等服务的行列
	// 队列提供了enqueue和dequeue操作来添加和删除元素
	Queue<string> queue=new Queue<string>();
	queue.Enqueue("apple");
	queue.Enqueue("banana");
	queue.Enqueue("orange");
	// 这里会取到第一个元素apple
	Console.WriteLine(queue.Peek());

	// 7、HashTable--哈希表 key-value类型
	Hashtable hashTable = new Hashtable();
	hashTable.Add(5, "ccc");
	hashTable.Add(1, "aa");
	hashTable.Add(2, "aa");
	hashTable[32]="bbb";
	Hashtable.Synchronized(hashTable);
	hashTable.Dump();

	// 8、SortedDictionary排序字典 key-value类型，本质是HashTable，自动排序
	SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();
	sortedDictionary.Add(32, "234");
	sortedDictionary.Add(10, "oo");
	sortedDictionary[5]="ww";
	// 这里会对key进行排序
	sortedDictionary.Dump();

	SortedDictionary<string, string> sortedDictionary1 = new SortedDictionary<string, string>();
	sortedDictionary1.Add("aa", "234");
	sortedDictionary1.Add("dd", "oo");
	sortedDictionary1.Add("d", "oo");
	sortedDictionary1.Add("cc", "oo");
	sortedDictionary1["bb"] = "ww";
	// 这里会对key进行排序 string类型的也会排序
	sortedDictionary1.Dump();

	// 8、SortedList--排序列表，重复key不可用Add
	SortedList<int, string> sortedList = new SortedList<int, string>();
	sortedList.Add(1, "2");
	sortedList.Add(100, "2");
	sortedList.Add(18, "2");
	sortedList.Add(50, "2");
	sortedList.Add(40, "2");
	// 这里也会对key自动排序
	sortedList.Dump();

	// 9、SortedSet
	SortedSet<string> sortedSet = new SortedSet<string>();
	sortedSet.Add("20");
	sortedSet.Add("9");
	sortedSet.Add("30");
	sortedSet.Add("500");
	sortedSet.Add("184");
	// 这个目前来看是首字母保持升序，结果为 181、20、30、500、9
	sortedSet.Dump();

	// 10、ArrayList(泛型集合)数据类型可不一样，任何类型都做object处理，可以坐标访问，长度可变
	ArrayList arrList = new ArrayList();
	arrList.Add("张三");
	arrList.Add(1);
	arrList.Add(true);
	arrList.Add(3.00);
	arrList.Dump();
	
}

