/*
LINQ(Langauge-Integrated) 쿼리 작업 - 카드 반으로 나누고 하나씩 교차로 섞어 원래 덱 복원하는 예제
https://learn.microsoft.com/ko-kr/dotnet/csharp/tutorials/working-with-linq

LINQ: 데이터 필터링, 가공, 추출 도구 (SQL 같은 느낌, foreach 없어도 됨, ToArray(), ToList() 등의 메소드 호출시 지연 실행 지원)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using LinqFaroShuffle;

static IEnumerable <string> Suits()
{
    yield return "clubs";
    yield return "diamonds";
    yield return "hearts";
    yield return "spades";
}

static IEnumerable <string> Ranks()
{
    yield return "two";
    yield return "three";
    yield return "four";
    yield return "five";
    yield return "six";
    yield return "seven";
    yield return "eight";
    yield return "nine";
    yield return "ten";
    yield return "jack";
    yield return "queen";
    yield return "king";
    yield return "ace";
}

//Query for building the deck
/*var startingDeck = from s in Suits()
                        from r in Ranks()
                        select new { Suits = s, Rank = r };
    
    foreach (var card in startingDeck)
    {
        Console.WriteLine(card);
    }

    var top = startingDeck.Take(26);
    var bottom = startingDeck.Skip(26);
    var shuffle = top.InterleaveSequenceWith(bottom);

    foreach (var c in shuffle)
    {
        Console.WriteLine(c);
    } */

// Shuffling using InterleaveSequenceWith<T>();
/*public static bool SequenceEquals<T>
    (this IEnumerable<T> first, IEnumerable<T> second)
{
    var firstIter = first.GetEnumerator();
    var secondIter = second.GetEnumerator();

    while ((firstIter?.MoveNext() == true) && secondIter.MoveNext())
    {
        if ((firstIter.Current is not null) && !firstIter.Current.Equals(secondIter.Current))
        {
            return false;
        }
    }

    return true;
} */

/* var times = 0;
    shuffle = startingDeck;
    do
    {
        shuffle = shuffle.Take(26).InterleaveSequenceWith(shuffle.Take(26));

        foreach (var card in shuffle)
        {
            Console.WriteLine(card);
        }
        Console.WriteLine();
        times++;

    } while (!startingDeck.SequenceEquals(shuffle));

    Console.WriteLine(times); 
    */

    var suits = Suits();
    var ranks = Ranks();


    // LINQ query로 모든 카드 조합 만듦
    var startingDeck = (from s in suits.LogQuery("Suit Generation")
                        from r in ranks.LogQuery("Value Generation")
                        select new { Suit = s, Rank = r })
                        .LogQuery("Starting Deck")
                        .ToArray(); //IEnumerable -> 배열

    foreach (var c in startingDeck) //섞기전 덱 출력
    {
        Console.WriteLine(c);
    }

    Console.WriteLine();

    var times = 0;
    var shuffle = startingDeck;

    do
    {
        /*
        shuffle = shuffle.Take(26)
            .LogQuery("Top Half")
            .InterleaveSequenceWith(shuffle.Skip(26).LogQuery("Bottom Half"))
            .LogQuery("Shuffle")
            .ToArray();
        */

        //Bottom 먼저 출력
        shuffle = shuffle.Skip(26)
            .LogQuery("Bottom Half")
            .InterleaveSequenceWith(shuffle.Take(26).LogQuery("Top Half"))
            .LogQuery("Shuffle")
            .ToArray();

        foreach (var c in shuffle)
        {
            Console.WriteLine(c);
        }

        times++;
        Console.WriteLine(times);

    } while (!startingDeck.SequenceEqual(shuffle)); //초기 덱까지 반복


    