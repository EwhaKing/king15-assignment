using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LinqFaroShuffle
{
    public static class Extensions
    {
        // 두 IEnumerable<T> 컬렉션 번갈아 하나씩 섞어주는 메소드
        public static IEnumerable<T> InterleaveSequenceWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            var firstIter = first.GetEnumerator(); //첫번째 컬렉션 반복자
            var secondIter = second.GetEnumerator(); //두번째 컬렉션 반복자

            // 두 컬렉션 번갈아 하나씩 꺼내 리턴
            while (firstIter.MoveNext() && secondIter.MoveNext())
            {
                yield return firstIter.Current; // 첫번째 컬렉션 값
                yield return secondIter.Current; // 두번째 컬렉션 값
            }
        }
        
        // IEnumerable<T> 쿼리 실행 타이밍 로깅용 확장 메소드.. (ToArray시 실행)
        public static IEnumerable<T> LogQuery<T>(this IEnumerable<T> sequence, string tag)
        {
            using (var writer = File.AppendText("debug.log"))
            {
                writer.WriteLine($"Executing Query {tag}");
            }

            return sequence;
        }
    }
}
