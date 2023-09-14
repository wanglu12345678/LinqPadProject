<Query Kind="Program" />

void Main()
{
	/*
		原理：拿第二位和前面所有做比较
			  拿第三位和前面所有做比较
			  拿第四位和前面所有做比较
			  往复循环
			  如果前1个数比当前数大则会移动到后面，将当前比较的数插入到适合自己的索引为止
		
	*/
	var list = new List<int> { 20, 15, 26, 10, 50, 5, 30, 19, 6, 8, 45, 64 };

	SortList(list).Dump();
}

private List<int> SortList(List<int> arr)
{
	var len=arr.Count;
	int preIndex,current;
	for (int i = 1; i < len; i++)
	{
		// 这里preIndex表示为当前循环的前面索引的数
		preIndex=i-1;
		// current存储的是当前比较的值
		current = arr[i];
		// 当上一个数大于当前比较的数时，把前面较大的那个数挪到后面
		// 然后索引前移，拿当前数与前面的前面比较，直到preIndex小于0也就是比较到了最前面
		// 将current这个当前比较的数放到适合它自己的索引位置
		while (preIndex >= 0 && arr[preIndex] > current)
		{
			arr[preIndex+1]=arr[preIndex];
			Console.WriteLine(string.Join(',',arr));
			preIndex--;
		}
		
		arr[preIndex+1]=current;
	}
	
	return arr;
}