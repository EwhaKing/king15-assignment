/*
Enumerable.ToArray<TSource>(IEnumerable<TSource>) 메서드
https://learn.microsoft.com/ko-kr/dotnet/api/system.linq.enumerable.toarray?view=net-9.0

ToArray 
- public static TSource[] ToArray<TSource> (this System.Collections.Generic.IEnumerable<TSource> source)
- IEnumerable<T> 형식의 데이터를 배열T[]로 복사해서 확정시켜주는 메소드
*/
using System;
using System.Linq;
using System.Collections.Generic;

class Package
{
    public string Company { get; set; }
    public double Weight { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Package> packages =
            new List<Package>
                { new Package { Company = "Coho Vineyard", Weight = 25.2 },
                new Package { Company = "Lucerne Publishing", Weight = 18.7 },
                new Package { Company = "Wingtip Toys", Weight = 6.0 },
                new Package { Company = "Adventure Works", Weight = 33.8 } };


        string[] companies = packages.Select(pkg => pkg.Company).ToArray();
        // 각 Package(pkg)에서 Company값만 뽑은 뒤(IEnumerable<string> 형태) -> ToArray()로 배열(string[])로 변환 후 companies에 넣음

        foreach (string company in companies)
        {
            Console.WriteLine(company);
        }
    }
}