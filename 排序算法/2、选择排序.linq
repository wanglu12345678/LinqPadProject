<Query Kind="Program" />

void Main()
{
	/*
		选择排序是一种简单直观的排序算法
		工作原理：在未排序序列中找到最小（大）元素，存放到排序序列的起始为止
		再从剩余未排序元素中继续寻找最小（大）元素，然后放到已排序序列的末尾。
		以此类推，直到所有元素均排序完毕
	*/
	var list = new List<int> { 20, 15, 26, 10, 50, 5, 30, 19, 6, 8, 45, 64 };

	SortList(list).Dump();
}

private List<int> SortList(List<int> arr)
{
	var len=arr.Count;
	int minIndex, temp;
	for (int i = 0; i < len - 1; i++)
	{
		minIndex = i;
		// 原理就是拿当前数去和后面的数做比较，小于当前数的存储索引
		// 一直找到最小的那个数和当前数做调换，循环最终得到排序后的数据
		for (var j = i + 1; j < len; j++)
		{
			if (arr[j] < arr[minIndex])
			{
				minIndex = j;
			}
		}
		temp = arr[i];
		arr[i] = arr[minIndex];
		arr[minIndex] = temp;
	}
	
	return arr;
}