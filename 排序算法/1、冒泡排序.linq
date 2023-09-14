<Query Kind="Program">
  <NuGetReference>System.Linq</NuGetReference>
  <NuGetReference>System.Linq.Expressions</NuGetReference>
</Query>

void Main()
{
	/*
		冒泡排序是一种简单的排序算法，它重复地走访过要排序的队列，一次比较两个元素，
		如果他们的顺序错误则把他们交换过来，走访队列的工作是重复地进行直到没有再需要交换
		这个算法的名字由来是因为越小的元素会经由交换慢慢浮到队列的顶端
	*/

	var list = new List<int> { 20,15,26,10,50,5,30,19,6,8,45,64 };
	
	SortList(list).Dump();
}

private List<int> SortList(List<int> arr)
{
	var count=0;
	var len=arr.Count;
	
	for (int i = 0; i < len; i++)
	{
		for (int j = 0; j < len - 1 - i; j++)
		{
			if (arr[j] > arr[j + 1])
			{
				count++;
				var temp = arr[j + 1];
				arr[j + 1] = arr[j];
				arr[j] = temp;
			}
		}
	}
	Console.WriteLine($"总共比较了{count}次。");
	
	return arr;
}