/* 
반복기 - 반복기 메서드를 사용하는 열거형 소스
https://learn.microsoft.com/ko-kr/dotnet/csharp/iterators#enumeration-sources-with-iterator-methods

IEnumerable<T> 구현할 때 직접 IEnumerator<T> 구현 안하고 yield return/yield break로 더 간단하게 반복기 메소드 작성 가능 (필요할 때 하나씩 꺼내쓸 수 있어 메모리 효율도 더 좋음)

yield return: 데이터 하나씩 반환 (MoveNext + Current 역할 자동처리)
yield break: 반복 중단
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    public IEnumerable<int> GetSetsOfNumbers()
    {
        int index = 0;
        while (index < 10)
            yield return index++;

        yield return 50;

        index = 100;
        while (index < 110)
            yield return index++;
    }

    //비동기 버전
    public async IAsyncEnumerable<int> GetSetsOfNumbersAsync()
    {
        int index = 0;
        while (index < 10)
            yield return index++;

        await Task.Delay(500);

        yield return 50;

        await Task.Delay(500);

        index = 100;
        while (index < 110)
            yield return index++;
    }

    //yield return만 사용
    public IEnumerable<int> GetFirstDecile()
    {
        int index = 0;
        while (index < 10)
            yield return index++;

        yield return 50;

        var items = new int[] {100, 101, 102, 103, 104, 105, 106, 107, 108, 109 };
        foreach (var item in items)
            yield return item;
    }


    //반복기 메소드 분할
    public IEnumerable<int> GetSingleDigitOddNumbers(bool getCollection)
    {
        if (getCollection == false)
            return new int[0];
        else
            return IteratorMethod();
    }

    private IEnumerable<int> IteratorMethod()
    {
        int index = 0;
        while (index < 10)
        {
            if (index % 2 == 1)
                yield return index;
            index++;
        }
    }

    static async Task Main(string[] args)
    {
        var program = new Program();

        Console.WriteLine("\nGetFirstDecile:");
        foreach (var num in program.GetFirstDecile())
            Console.WriteLine(num);

        Console.WriteLine("\nGetSingleDigitOddNumbers (True):");
        foreach (var num in program.GetSingleDigitOddNumbers(true))
                Console.WriteLine(num);

        Console.WriteLine("\nSampled Numbers (Interval 2) from 0~9:");
        foreach (var num in Enumerable.Range(0,10).Sample(2))
                Console.WriteLine(num);

    }

}

public static class Extensions
{
    //예제 (IoT 디바이스 센서 데이터 샘플링)
    public static IEnumerable<T> Sample<T>(this IEnumerable<T> sourceSequence, int interval)
    {
        int index = 0;
        foreach (T item in sourceSequence)
        {
            if (index++ % interval == 0)
                yield return item;
        }
    }

    //예제 - 비동기
    public static async IAsyncEnumerable<T> Sample<T>(this IAsyncEnumerable<T> sourceSequence, int interval)
    {
        int index = 0;
        await foreach (T item in sourceSequence)
        {
            if (index++ % interval == 0)
                yield return item;
        }
    }
}
